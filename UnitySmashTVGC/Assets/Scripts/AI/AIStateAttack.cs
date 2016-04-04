using UnityEngine;
using System.Collections;

public class AIStateAttack : AIState
{
    // Attack properties
    public float attackRate = 1f;
    public float attackTime = 0f;  // attack clocker

    public AIStateAttack(Brain aBrain) : base(aBrain) {}
    
    public override void OnUpdateState()
    {
        brain.Attack();
    }
}
