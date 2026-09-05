using Godot;
using System;

public partial class EnemyPaddle : CharacterBody2D
{
	private Node2D _ball;
    private const float Speed = 400.0f; 

    public override void _Ready()
    {
        _ball = GetParent().GetNode<Node2D>("ball");
    }

    public override void _PhysicsProcess(double delta)
    {
        //Calcula a direção vertical baseada na posição da bola
        float direction = 0;
        if (_ball.GlobalPosition.Y > GlobalPosition.Y)
            direction = 1; // Bola está abaixo, desce
        else if (_ball.GlobalPosition.Y < GlobalPosition.Y)
            direction = -1; // Bola está acima, sobe

        //Define a velocidade baseada na direção
        Velocity = new Vector2(0, direction * Speed);

        //Move um CharacterBody e faz a leitura de colisões automaticamente
        MoveAndSlide();
    }
}
