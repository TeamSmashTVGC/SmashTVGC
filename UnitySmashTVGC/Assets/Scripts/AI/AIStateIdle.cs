using UnityEngine;
using System.Collections;

public class AIStateIdle : AIState
{
    // Idle properties
    public float idleRate = 1f;
    public float idleTime = 0f;  // idle clocker

    public AIStateIdle(Brain aBrain) : base(aBrain) { }

    public override void OnEnterState()
    {
        // Restart idle counter
        idleTime = Time.time + idleRate;
    }

    public override void OnUpdateState()
    {
        brain.Idle();
    }
}
