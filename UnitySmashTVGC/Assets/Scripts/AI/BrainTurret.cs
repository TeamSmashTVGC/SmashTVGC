using UnityEngine;
using System.Collections;

public class BrainTurret : Brain {

    public override void Init()
    {
        base.Init();
        NPCWeapon weapon = root.GetComponent<NPCWeapon>();
        if (weapon != null)
        {
            attackState.attackRate = weapon.attackRate;
        }
    }

    /// <summary>
    /// Idle for a time then go back to patrolling
    /// </summary>
    public override void Idle()
    {
        base.Idle();

        // If time is past the idle time, go back to patrol
        if (Time.time > idleState.idleTime)
        {
            // Go back to patrolling
            ChangeState(patrolState);
        }
    }


    /// <summary>
    /// Patrol then go back to idle
    /// </summary>
    public override void Patrol()
    {
        base.Patrol();

        // If time is past the idle time, go back to patrol
        if (Time.time > patrolState.patrolTime)
        {
            // Go back to patrolling
            ChangeState(idleState);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Call the current state to update any trigger behaviours as well
            currentState.TriggerEnterState2D(collider);
            ChangeState(attackState);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Call the current state to update any trigger behaviours as well
            currentState.TriggerEnterState(collider);
            ChangeState(attackState);
        }
    }


    /// <summary>
    /// Shoot at the enemy until he's dead or you're dead
    /// </summary>
    public override void Attack()
    {
        if (Time.time > attackState.attackTime)
        {
            attackState.attackTime = Time.time + attackState.attackRate;

            // Go back to patrolling
            base.Attack();
            npcWeapon.Attack();
        }
    }
}
