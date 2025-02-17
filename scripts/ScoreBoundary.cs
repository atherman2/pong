using Godot;
using System;

public partial class ScoreBoundary : StaticBody2D
{
	public enum ScoreSide
	{
		PLAYER,
		OPPONENT
	}
	private ScoreSideObject scoreSideObject;
	public partial class ScoreSideObject : Node
	{
		private ScoreSide scoreSide;
		public ScoreSideObject(ScoreSide scoreSide)
		{
			this.scoreSide = scoreSide;
		}
		public ScoreSide GetScoreSide()
		{
			return scoreSide;
		}
	}

	[Export] private ScoreSide scoreSide;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		scoreSideObject = new ScoreSideObject(scoreSide);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public ScoreSideObject GetScoreSideObject()
	{
		return scoreSideObject;
	}

	public void OnBodyEntered(Node body)
	{
		GD.Print($"{body.Name}");
	}
}
