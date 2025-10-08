using UnityEngine;

public abstract class BaseState
{

    public BasicEnemy Enemy;
    // Reference to the state machine using this state
    public StateMachine stateMachine;

    // Called when the state starts
    public abstract void Enter();

    // Called every frame while this state is active
    public abstract void Execute(); // Renamed from 'perform' for clarity

    // Called when the state ends
    public abstract void Exit();
}
