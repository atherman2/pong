using Godot;
using System;
using System.Runtime.Serialization;

public partial class Ball : RigidBody2D
{
	[Export] private Timer restartTimer;
	[Export] private float xDirection, yDirection, velocity;
	[Signal] public delegate void ScoredEventHandler(ScoreBoundary.ScoreSideObject scoreSideObject);
	private Vector2 respawnPoint;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		respawnPoint = Position;
		BodyEntered += OnBodyEntered;
		restartTimer.Timeout += OnTimeOut;
		ContactMonitor = true;
		MaxContactsReported = 3;
		LinearVelocity = new Vector2(xDirection * velocity, yDirection * velocity);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(Node body)
	{
		if(body is Paddle)
		{
			xDirection = -xDirection;
			LinearVelocity = new Vector2(xDirection * velocity, yDirection * velocity);
		}
		else if(body is Boundary)
		{
			yDirection = -yDirection;
			LinearVelocity = new Vector2(xDirection * velocity, yDirection * velocity);
		}
		else if(body is ScoreBoundary)
		{
			Respawn();
			ScoreBoundary scoreBoundaryHit = (ScoreBoundary) body;
			EmitSignal(SignalName.Scored, scoreBoundaryHit.GetScoreSideObject());
			xDirection = -xDirection;
		}
	}

	public void OnTimeOut()
	{
		LinearVelocity = new Vector2(xDirection * velocity, yDirection * velocity);
	}

	public void Respawn()
	{
		PhysicsServer2D.BodySetState
		(
			GetRid(),
			PhysicsServer2D.BodyState.Transform,
			Transform2D.Identity.Translated(respawnPoint)
		);
		LinearVelocity = Vector2.Zero;
		PhysicsServer2D.BodySetState
		(
			GetRid(),
			PhysicsServer2D.BodyState.LinearVelocity,
			Vector2.Zero
		);
		restartTimer.Start();
	}
}
