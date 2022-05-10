using Godot;
using System;
using Newtonsoft.Json;


namespace GodoPrototype
{
    public class Player : KinematicBody2D
    {
        Vector2 motion = new Vector2();


        float defaultAngle = 0.5F;
        float defaultSpeedForward = 1.0F;
        float defaultSpeedBackward = -0.7F;

        float currentAngle = 0.0F;
        float currentThrottle = 0.0F;

        float minAngle = -1.0F;
        float maxAngle = 1.0F;

        float angleIncreaseBy = 0.05F;


        WSMessage wsMsg = new WSMessage();
        bool isMessageQueued = true;


        //private string URL = "ws://donkey-new392:8887/wsDrive";
        private string URL = "ws://192.168.1.9:8887/wsDrive";
        //private string URL = "ws://192.168.137.153:8887/wsDrive";
        private WebSocketClient ws;


        Vector2 startingPos;

        public override void _Ready()
        {
            ws = new WebSocketClient();
            GD.Print("connection: " + ws.ConnectToUrl(URL) + "!");

            ws.Connect("connection_established", this, "_connected");

            startingPos = this.Position;
        }

        public void _connected(string proto = "")
        {
            GD.Print("connection established !!");
        }


        public override void _Process(float delta)
        {
            if (isMessageQueued)
            {
                ws.Poll();
                GD.Print($"message sent: { wsMsg.stringify() }");

                isMessageQueued = false;
            }


            bool isLeftOrRightReleased = false;
            var movementSpeed = 100;
            if (Input.IsActionPressed("ui_right"))
            {
                motion.x = movementSpeed;

                currentAngle = defaultAngle;
                SendMessage();
                
            }
            else if (Input.IsActionPressed("ui_left"))
            {
                motion.x = -movementSpeed;

                currentAngle = -defaultAngle;
                SendMessage();
            }
            else
            {
                currentAngle = 0;
                motion.x = 0;
                isLeftOrRightReleased = true;
            }


            bool isUpOrDownReleased = false;

            if (Input.IsActionPressed("ui_up"))
            {
                motion.y = -movementSpeed;
                currentThrottle = defaultSpeedForward;
                SendMessage();
            }
            else if (Input.IsActionPressed("ui_down"))
            {
                motion.y = movementSpeed;
                currentThrottle = defaultSpeedBackward;
                SendMessage();
            }
            else
            {
                currentThrottle = 0;
                motion.y = 0;
                isUpOrDownReleased = true;
            }


            if (isLeftOrRightReleased && isUpOrDownReleased)
            {
                // back to the center
                var inBoundaryOffset = 5;
                var backToCenterMovementSpeed = 250;

                float x = 0;
                var isXInBoundary = Math.Abs(this.Position.x - startingPos.x) <= inBoundaryOffset;
                if (this.Position.x > startingPos.x)
                {
                    // object is on right
                    x = isXInBoundary ? 0 : -backToCenterMovementSpeed;
                }
                else if (this.Position.x < startingPos.x)
                {
                    // object is on left
                    x = isXInBoundary ? 0 : backToCenterMovementSpeed;
                }
                
                
                float y = 0;
                var isYInBoundary = Math.Abs(this.Position.y - startingPos.y) <= inBoundaryOffset;
                if (this.Position.y > startingPos.y)
                {
                    // object is on bottom
                    y = isYInBoundary ? 0 : -backToCenterMovementSpeed;
                }
                else if (this.Position.y < startingPos.y)
                {
                    // object is on top
                    y = isYInBoundary ? 0 : backToCenterMovementSpeed;
                }
                

                motion.x = x;
                motion.y = y;
            }
            

            if (Input.IsActionJustReleased("ui_up") || Input.IsActionJustReleased("ui_down"))
            {
                currentAngle = 0;
                currentThrottle = 0;
                SendMessage();
            }


            MoveAndSlide(motion);
        }

        public void SendMessage()
        {
            wsMsg.angle = currentAngle;
            wsMsg.throttle = currentThrottle;
            var msg = wsMsg.stringify();
            var err = ws.GetPeer(1).PutPacket(msg.ToUTF8());
            GD.Print("put package - " + err);

            isMessageQueued = true;
        }


        public class WSMessage
        {
            public float angle { get; set; }
            public float throttle { get; set; }
            public bool recording { get; set; }
            public string drive_mode => "user";


            public string stringify()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}