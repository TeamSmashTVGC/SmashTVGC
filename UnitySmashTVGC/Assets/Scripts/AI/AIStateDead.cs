using UnityEngine;
using System.Collections;

public class AIStateDead : AIState
{
    public AIStateDead(Brain aBrain) : base(aBrain) { }

    public override void OnEnterState()
    {
        brain.Dead();
    }
}
