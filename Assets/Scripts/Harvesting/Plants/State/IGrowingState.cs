public interface IGrowingState
{
    void Enter(IGrowingStateMachine stateMachine);
    void Exit(IGrowingStateMachine stateMachine);
}