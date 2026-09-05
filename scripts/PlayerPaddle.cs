using Godot;
using System;

public partial class PlayerPaddle : CharacterBody2D
{
	private const float Speed = 400.0f;

    private float GetYDir()
    {
        return Input.GetActionStrength("down") - Input.GetActionStrength("up");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 dir = new Vector2(0, GetYDir());
        Velocity = dir * Speed;

        MoveAndSlide();
    }
}
