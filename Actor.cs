using Godot;
using System;

public class Actor : KinematicBody2D
{
    
    protected Vector2 FLOOR_NORMAL = Vector2.Up;
    
    protected Vector2 velocity = new Vector2(0,0);
    [Export]
    protected float gravity = 3000;
    [Export]
    protected Vector2 speed = new Vector2(300,1000);


    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        
        
    }
}
