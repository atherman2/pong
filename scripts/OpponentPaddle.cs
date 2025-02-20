using Godot;
using System;

public partial class OpponentPaddle : Paddle
{
	[Export] private float velocity;
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
		LinearVelocity = VelocityOnInput();
    }

    public Vector2 VelocityOnInput()
	{
		float yDirection = Input.GetAxis("moveUp2", "moveDown2");
		return new Vector2(0, yDirection * velocity);
	}
}
