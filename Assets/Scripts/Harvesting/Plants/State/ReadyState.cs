using UnityEngine;

public class ReadyState : IGrowingState
{
    private Collider _collider;

    public void Enter(IGrowingStateMachine stateMachine)
    {
        _collider = stateMachine.Owner.GetComponent<Collider>();
        _collider.enabled = true;
    }

    public void Exit(IGrowingStateMachine stateMachine)
    {
        _collider.enabled = false;
    }
}