using UnityEngine;

public abstract class EntityState
{
    //COTROLS ALL STATES//

    //EntityState is an abstract Blueprunt and is used as a template for ALL States, functions only work if they inherit Entity Class//

    // Create a State Machine Ocject for Machine Work
    protected StateMachine stateMachine;
    protected string animBoolName;

    //Player object to change states based on players current state
    protected Player player;

    protected Animator anim; //can call on the Player variable and dynamically set anim variable.
    protected Rigidbody2D rb;
    protected PlayerInputSet input;

    //Constructor for Class Instance
    public EntityState(Player player, StateMachine stateMachine, string animBoolName)
    {
        this.player = player;
    this.stateMachine = stateMachine;
    this.animBoolName = animBoolName;
        anim = player.anim;
        rb = player.rb;
        input = player.input;
    
    }

    public virtual void Enter()
    {
        //every time a state is changed, Enter will be called
        anim.SetBool(animBoolName, true);

    }

    public virtual void Update()
    {
        //logic of the state
        anim.SetFloat("yVelocity", rb.velocityY);
    }

    public virtual void Exit() {
        // every time a state ends, exit will be called to change to a new state
        anim.SetBool(animBoolName, false);
    }
}
