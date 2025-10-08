using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    public int waypointIndex = 0;
    [SerializeField] private float waypointThreshold = 0.2f;

    public override void Enter()
    {
        // Set initial destination
        if (Enemy.path != null && Enemy.path.waypoints.Count > 0)
        {
            waypointIndex = 0;
            Enemy.Agent.SetDestination(Enemy.path.waypoints[waypointIndex].position);
        }
    }

    public override void Execute()
    {
        PatrolCycle();
    }

    public override void Exit()
    {
        
        Enemy.Agent.ResetPath();
    }

    private void PatrolCycle()
    {
        if (Enemy.path == null || Enemy.path.waypoints.Count == 0) return;

        // Check if close to current waypoint
        if (!Enemy.Agent.pathPending && Enemy.Agent.remainingDistance < waypointThreshold)
        {
            // Move to next waypoint
            waypointIndex = (waypointIndex + 1) % Enemy.path.waypoints.Count;
            Enemy.Agent.SetDestination(Enemy.path.waypoints[waypointIndex].position);
        }
    }
}
