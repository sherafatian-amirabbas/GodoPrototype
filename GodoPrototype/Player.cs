using Godot;
using System;
using Newtonsoft.Json;


namespace GodoPrototype
{
    public class Player : KinematicBody2D
    {
        Vector2 motion = new Vector2();


        float defaultAngle = 0.0F;
        float defaultSpeedForward = 1.0F;
        float defaultSpeedBackward = -0.7F;

        float currentAngle = 0.0F;
        float currentThrottle = 0.0F;

        float minAngle = -1.0F;
        float maxAngle = 1.0F;

        float angleIncreaseBy = 0.05F;


        WSMessage wsMsg = new WSMessage();
        bool isMessageQueued = true;


        private string URL = "ws://192.168.50.1:8887/wsDrive";
        private WebSocketClient ws;


        public override void _Ready()
        {
            ws = new WebSocketClient();
            GD.Print("connection: " + ws.ConnectToUrl(URL) + "!");

            ws.Connect("connection_established", this, "_connected");
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


            if (Input.IsActionPressed("ui_right"))
            {
                motion.x = 100;

                currentAngle += angleIncreaseBy;
                currentAngle = Math.Min(maxAngle, currentAngle);
                SendMessage(currentAngle, currentThrottle);
            }
            else if (Input.IsActionPressed("ui_left"))
            {
                motion.x = -100;

                currentAngle -= angleIncreaseBy;
                currentAngle = Math.Max(minAngle, currentAngle);
                SendMessage(currentAngle, currentThrottle);
            }
            else
                motion.x = 0;

            if (Input.IsActionPressed("ui_up"))
            {
                motion.y = -100;
                SendMessage(currentAngle, defaultSpeedForward);
            }
            else if (Input.IsActionPressed("ui_down"))
            {
                motion.y = +100;
                SendMessage(currentAngle, defaultSpeedBackward);
            }
            else
                motion.y = 0;


            if (Input.IsActionJustReleased("ui_up") || Input.IsActionJustReleased("ui_down"))
            {
                currentAngle = 0;
                currentAngle = 0;
                SendMessage(currentAngle, currentAngle);
            }


            MoveAndSlide(motion);
        }

        public void SendMessage(float angle, float throttle)
        {
            wsMsg.angle = angle;
            wsMsg.throttle = throttle;
            var msg = wsMsg.stringify();
            var err = ws.GetPeer(1).PutPacket(msg.ToUTF8());
            GD.Print("put package - " + err);

            isMessageQueued = true;
        }
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
