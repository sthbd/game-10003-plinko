using Godot;
using System;

public partial class Bucket : Area2D
{
	[Export]
    public int BucketScore = 0;

    [Export]
	public PlankoLevel PlankoLevelNode;

	private Label scoreLabel;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		scoreLabel = GetNode<Label>("ScoreLabel");

		scoreLabel.Text = $"{BucketScore}";


		BodyEntered += Bucket_BodyEntered;
    }

    private void Bucket_BodyEntered(Node2D body)
    {
		if (body.IsInGroup("player"))
				{
			PlankoLevelNode.IncreaseScore(BucketScore);

			Player playerDisk = (Player)body;
			playerDisk.Dead  =  true;
        }
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
