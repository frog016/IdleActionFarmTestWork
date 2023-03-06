using UnityEngine;

public interface IGrowingStateMachine
{
    GameObject Owner { get; }
    IGrowingState CurrentState { get; }
    void SetState(IGrowingState state);
}