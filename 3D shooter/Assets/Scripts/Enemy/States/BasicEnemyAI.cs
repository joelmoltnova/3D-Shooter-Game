using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> waypoints;
    public GameObject player;

    [Header("Vision Settings")]
    public float sightDistance = 20f;       // How far the enemy can see
    public float fieldOfView = 90f;         // How wide the enemy can see
    public float rayOriginHeight = 1.5f;    // Height of the “eyes” for raycast
    public bool showDebugRay = true;        // Show a red line in scene for debugging
    public LayerMask obstacleMask;          // What blocks sight

    [Header("Chase Settings")]
    public float investigateTime = 2f;      // How long the enemy waits at last seen position
    private float investigateTimer = 0f;    // Countdown while investigating
    private Vector3 lastKnownPlayerPos;     // Store last known player position

    private int currentWaypoint = 0;        // Track which patrol point to go to
    private float waypointThreshold = 1f;   // Distance to switch to next patrol point

    private enum State { Patrol, Chase, Investigate }
    private State currentState = State.Patrol;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (waypoints.Count > 0)
            agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                if (CanSeePlayer())
                {
                    currentState = State.Chase;
                    lastKnownPlayerPos = player.transform.position; // store position
                }
                break;

            case State.Chase:
                Chase();
                if (CanSeePlayer())
                {
                    lastKnownPlayerPos = player.transform.position; // update last seen
                }
                else
                {
                    // Lost sight, start investigating
                    currentState = State.Investigate;
                    investigateTimer = investigateTime;
                    agent.SetDestination(lastKnownPlayerPos); // move to last seen
                }
                break;

            case State.Investigate:
                // Wait at last known position
                if (CanSeePlayer())
                {
                    currentState = State.Chase; // saw player again
                    lastKnownPlayerPos = player.transform.position;
                }
                else
                {
                    // Check if reached last known spot
                    if (!agent.pathPending && agent.remainingDistance <= waypointThreshold)
                    {
                        investigateTimer -= Time.deltaTime;
                        if (investigateTimer <= 0f)
                            currentState = State.Patrol; // resume patrol
                    }
                }
                break;
        }
    }

    void Patrol()
    {
        if (waypoints.Count == 0 || agent.pathPending) return;

        if (agent.remainingDistance <= waypointThreshold)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    void Chase()
    {
        if (player != null)
            agent.SetDestination(player.transform.position);
    }

    bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 origin = transform.position + Vector3.up * rayOriginHeight;
        Vector3 target = player.transform.position + Vector3.up * 1f;
        Vector3 direction = target - origin;

        if (showDebugRay)
            Debug.DrawRay(origin, direction, Color.red);

        float distance = direction.magnitude;
        if (distance > sightDistance) return false;

        float angle = Vector3.Angle(transform.forward, direction);
        if (angle > fieldOfView / 2f) return false;

        if (Physics.Raycast(origin, direction.normalized, out RaycastHit hit, sightDistance))
        {
            if (((1 << hit.collider.gameObject.layer) & obstacleMask) != 0) // blocked by wall
                return false;

            if (hit.collider.CompareTag("Player"))
                return true;
        }

        return false;
    }
}
