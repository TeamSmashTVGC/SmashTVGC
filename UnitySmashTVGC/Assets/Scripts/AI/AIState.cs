using UnityEngine;
using System.Collections;

public class AIState
{
    public readonly Brain brain;

    // Delegate for on state enter behaviour, this is called once state is switched at the beginning
    public delegate void delegateEnter();
    public delegateEnter EnterState;

    // Delegate for on state update behaviour, this is called every frame until the state is exited
    public delegate void delegateUpdate();
    public delegateUpdate UpdateState;

    // Delegate for on state exit behaviour, this is called at the end before the state is exited
    public delegate void delegateExit();
    public delegateUpdate ExitState;

    public delegate void delegateOnTriggerEnter(Collider other);
    public delegateOnTriggerEnter TriggerEnterState;

    public delegate void delegateOnTriggerEnter2D(Collider2D other);
    public delegateOnTriggerEnter2D TriggerEnterState2D;

    // Constructs this state with a brain
    public AIState(Brain aBrain)
    {
        EnterState = OnEnterState;
        UpdateState = OnUpdateState;
        ExitState = OnExitState;
        TriggerEnterState = OnTriggerEnterState;
        TriggerEnterState2D = OnTriggerEnterState2D;

        brain = aBrain;
    }

    // Is called when a transition starts and the state machine starts to evaluate this state
    public virtual void OnEnterState()
    {
        //Debug.Log("Entered into state" + this.ToString());
    }

    // Is called on each Update frame between OnEnable and OnDisable callbacks
    public virtual void OnUpdateState()
    {
        //Debug.Log("Updating state " + this.ToString());
    }

    // Is called when a transition ends and the state machine finishes evaluating this state
    public virtual void OnExitState()
    {
        //Debug.Log("Exit out of state " + this.ToString());
    }

    // Is called when a collision trigger happens
    public virtual void OnTriggerEnterState(Collider other)
    {
        //Debug.Log("Trigger entered state " + this.ToString());
    }
    public virtual void OnTriggerEnterState2D(Collider2D other)
    {
        //Debug.Log("Trigger entered state " + this.ToString());
    }
}
