using Godot;
using System;


public class Enemy : Actor
{

	public override void _Ready()
	{
		base._Ready();
		SetPhysicsProcess(false);
		velocity.x = -speed.x;
		
	}

	public void _on_StompDetector_body_entered(PhysicsBody2D body){

		if (body.GlobalPosition.y > ((Node2D) GetNode("StompDetector")).GlobalPosition.y){return;}

		((CollisionShape2D)GetNode("CollisionShape2D")).Disabled = true;
		QueueFree();

	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		velocity.y += gravity*delta;
		if (IsOnWall()){
			velocity.x *= -1.0f;
		}
		velocity.y = MoveAndSlide(velocity, FLOOR_NORMAL).y;
	}


}
