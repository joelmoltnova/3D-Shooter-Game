using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    // Example: PatrolState as default
    public PatrolState patrolState;

    void Update()
    {
        activeState?.Execute();
    }

    public void Initialise()
    {
        // Create PatrolState instance
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
            activeState.Exit();

        activeState = newState;

        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.Enemy = GetComponent<BasicEnemy>();
            activeState.Enter();
        }
    }
}
