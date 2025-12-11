using Godot;
using System;

public partial class Player : RigidBody2D
{
    [Export]
   public Camera2D GameCamera;

    public bool Dead = false;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Freeze = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)

	{
		if (Freeze)
		{

            // copy the new position to be the mouse position
            Vector2 newPosition = Position;

            // set the X positon to be the mouse positon 

            newPosition.X = GetViewport().GetMousePosition().X;



            // set the positon as the new positon 
            Position = newPosition;

            if (Input.IsActionJustPressed("drop_disk")) 

            {
                Freeze = false;

            }
        }
        
    }
}
