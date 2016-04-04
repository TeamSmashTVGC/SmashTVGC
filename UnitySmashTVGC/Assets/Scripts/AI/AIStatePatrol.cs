using UnityEngine;
using System.Collections;

public class AIStatePatrol : AIState
{
    // Idle properties
    public float patrolRate = 1f;
    public float patrolTime = 0f;  // patrol clocker

    // Keep track of our waypoints
    public int waypointCount;
    public int waypointIndex;

    public AIStatePatrol(Brain aBrain) : base(aBrain) { }
    
    public override void OnEnterState()
    {
        // If waypoints are equal 0, then patrol by time
        if (waypointCount == 0)
        {
            patrolTime = Time.time + patrolRate;
        }
    }

    public override void OnUpdateState()
    {
        brain.Patrol();
    }

    public override void OnExitState()
    {
        // If waypoints are specified go to the next waypoint
        if (waypointCount > 0)
        {
            waypointIndex = (waypointIndex + 1) % waypointCount;
        }
    }
}
