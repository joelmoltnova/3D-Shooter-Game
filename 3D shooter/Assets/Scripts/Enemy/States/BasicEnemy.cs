using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(StateMachine))]
public class BasicEnemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;

    public float sightDistance = 20f;
    public float fieldOfView =   85f;
    public NavMeshAgent Agent => agent;
    public Path path;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();

        if (path == null)
        {
            Debug.LogWarning("Path not assigned on " + name);
        }

        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool canSeePlayer()
    {
        if ( player != null )
        {
            // is player close enough to be seen
            if(Vector3.Distance(transform.position,player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(targetDirection,transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position, targetDirection);
                    Debug.DrawRay(ray.origin,ray.direction * sightDistance);
                }

            }

        }
        return true;


    }
}
