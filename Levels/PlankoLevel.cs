using Godot;
using System;

public partial class PlankoLevel : Node2D
{
	public int Score = 0;
	[Export]
	public Label ScoreValue;

	[Export]
	public Label RestartMessage;

	[Export]
	public PackedScene PlayerScene;

	[Export]
	public Node2D PlayerDisk;

	
    bool EnabledRestart = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		RestartMessage.Hide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ScoreValue.Text = $"Score: {Score}";
		RestartMessage.Visible = EnabledRestart;

        if (Input.IsActionJustPressed("drop_disk") && EnabledRestart)
		{
			CallDeferred("SpawnNewPlayer");
            EnabledRestart = false;

        }

    }
		void SpawnNewPlayer()
	{
        RigidBody2D newPlayer = PlayerScene.Instantiate<RigidBody2D>();

        newPlayer.Position = new Vector2(330, 25);

        PlayerDisk.AddChild(newPlayer);

        

    }


    public void IncreaseScore(int scoreIncrease)
	{
		
			if (!EnabledRestart)
			{

				Score += scoreIncrease;
				EnabledRestart = true;

			}
        


    }
}

	

