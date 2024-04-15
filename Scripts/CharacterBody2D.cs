using Godot;
using System;

namespace Dotnet_Playground.Scripts;

public partial class CharacterBody2D : Godot.CharacterBody2D {
	[Export(PropertyHint.Range, "0,1000,0.1,or_greater")]
	private float _speed = 300.0f;

	[Export(PropertyHint.Range, "0,1000,0.1,or_greater")]
	public float MySpeed {
		get => _speed;
		set {
			// won't actually be called in the editor inspector.
			_speed = value;
			GD.Print(value); 
		}
	}

	[Export(PropertyHint.Range, "0,1000,0.1,or_greater")]
	private float _acceleration = 300.0f;
	
	[Signal]
	public delegate void MySignalEventHandler();
	
	public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector2 targetVelocity = direction * _speed;
		if (!direction.IsZeroApprox()) {
			velocity = velocity.MoveToward(targetVelocity, _acceleration * (float)delta);
		} else {
			velocity = velocity.MoveToward(Vector2.Zero, _acceleration * (float)delta);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
