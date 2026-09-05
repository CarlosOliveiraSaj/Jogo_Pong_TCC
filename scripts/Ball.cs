using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    //Definição da velocidade
	private const float Speed = 600.0f;

    public override void _Ready()
    {
        /*
        Vetor velocidade que faz com que a bola inicialmente se dirija a esquerda
        e mantenha velocidade constante até entrar em contato com as raquetes (paddles) 
        ou com a parede.
        */ 
        Velocity = new Vector2(-Speed, 0);
    }

    public override void _PhysicsProcess(double delta)
    {
        //Verifica se o objeto bola colide com algum outro objeto da cena
        KinematicCollision2D col = MoveAndCollide(Velocity * (float)delta);

        //Calcula e define a nova posição do vetor velocidade
        if (col != null)
        {
            Vector2 normal = col.GetNormal();

            Velocity = Velocity.Bounce(normal);
        }
    }
}
