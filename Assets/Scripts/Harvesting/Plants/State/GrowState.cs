using DG.Tweening;
using UnityEngine;

public class GrowState : IGrowingState
{
    private readonly float _growTime;

    public GrowState(float growTime)
    {
        _growTime = growTime;
    }

    public void Enter(IGrowingStateMachine stateMachine)
    {
        var owner = stateMachine.Owner.transform;
        owner.localScale = Vector3.zero;
        GrowUp(stateMachine);
    }

    public void Exit(IGrowingStateMachine stateMachine)
    {
    }

    private void GrowUp(IGrowingStateMachine stateMachine)
    {
        var owner = stateMachine.Owner.transform;
        var tweener = owner.DOScale(Vector3.one, _growTime);
        tweener.SetAutoKill(true);
        tweener.onComplete += () => Next(stateMachine);
    }

    private static void Next(IGrowingStateMachine stateMachine)
    {
        stateMachine.SetState(new ReadyState());
    }
}