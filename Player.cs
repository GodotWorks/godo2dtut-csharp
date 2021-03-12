using Godot;
using System;

public class Player : Actor
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]

    float stompImpluse = 1000.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_EnemyDetector_area_entered(Area2D area){

        velocity = calculateStompVelocity(velocity,stompImpluse);

    }

    public Vector2 calculateStompVelocity(Vector2 linearVelocity, float stompImpulse){
    
            Vector2 newVelocity = linearVelocity;
            newVelocity.y = -stompImpluse;
            return newVelocity;
    }


    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        Boolean isJumpInterrupted = Input.IsActionJustReleased("jump") & velocity.y < 0.0f;
        Vector2 direction = getDirection();

        GD.Print(isJumpInterrupted);
        velocity = calculateMoveVelocity(velocity,speed,direction, isJumpInterrupted);
        velocity = MoveAndSlide(velocity, FLOOR_NORMAL);

    }

    public Vector2 getDirection()
    {
        return new Vector2(Input.GetActionStrength("move_right")- Input.GetActionStrength("move_left"),
        (Input.IsActionJustPressed("jump") & IsOnFloor()) ? -1.0f : 1.0f);
    }

    public Vector2 calculateMoveVelocity(Vector2 linearVelocity, Vector2 speed, Vector2 direction, Boolean isJumpInterrupted)
    {
        Vector2 newVelocity = linearVelocity;
        newVelocity.x = speed.x * direction.x;
        newVelocity.y += gravity * GetPhysicsProcessDeltaTime();

        if (direction.y == -1.0f){
            newVelocity.y = speed.y * direction.y;
        }
        if (isJumpInterrupted){
            newVelocity.y = 0.0f;
        }
        return  newVelocity;

    }
}
