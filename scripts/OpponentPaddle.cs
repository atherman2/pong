using Godot;
using System;

public partial class OpponentPaddle : Paddle
{
	[Export] private Ball ball;
	[Export] private double coolDown, remainingCoolDown;
	[Export] private float outDatedBallDirection, velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		UpdateCoolDown(delta);
    }

	public void UpdateCoolDown(double delta)
	{
		if(remainingCoolDown > 0.0)
		{
			remainingCoolDown -= delta;
		}
		else
		{
			UpdateBallPursuit();
			remainingCoolDown = coolDown - delta;
		}
	}

	public void UpdateBallPursuit()
	{
		LinearVelocity = new Vector2(0, velocity * outDatedBallDirection);
		outDatedBallDirection = Math.Sign(ball.Position.Y - Position.Y);
	}
}
