using UnityEngine;
using System.Collections;

public class AIStateAlert : AIState
{
    public AIStateAlert(Brain aBrain) : base(aBrain) {}

    public override void OnUpdateState()
    {
        brain.Alert();
    }
}
