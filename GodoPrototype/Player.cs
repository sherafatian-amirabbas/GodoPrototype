using Godot;
using System;


namespace GodoPrototype
{
    public class Player : Godot.KinematicBody2D
    {
        Vector2 motion = new Vector2();


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            if (Input.IsActionPressed("ui_right"))
                motion.x = 100;
            else if (Input.IsActionPressed("ui_left"))
                motion.x = -100;
            else
                motion.x = 0;

            if (Input.IsActionPressed("ui_up"))
                motion.y = -100;
            else if (Input.IsActionPressed("ui_down"))
                motion.y = +100;
            else
                motion.y = 0;


            MoveAndSlide(motion);
        }
    }
}
