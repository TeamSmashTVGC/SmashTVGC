using UnityEngine;
using System.Collections;

public class AIStateHide : AIState
{
    public AIStateHide(Brain aBrain) : base(aBrain) { }

    public override void OnEnterState()
    {
        brain.Hide();
    }

    public override void OnUpdateState()
    {
        brain.ShowOnCondition();
    }
}
