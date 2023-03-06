using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Wheat : MonoBehaviour, ISlicing, IGrowingStateMachine, ISize
{
    [SerializeField] private Vector3 _size;
    [SerializeField] private WheatBlock _wheatBlockPrefab;

    public event Action Sliced;
    public Vector3 Size => _size;
    public GameObject Owner => gameObject;
    public IGrowingState CurrentState { get; private set; }

    public void Slice()
    {
        Instantiate(_wheatBlockPrefab, transform.position, Quaternion.identity);
        Sliced?.Invoke();
    }

    public void SetState(IGrowingState state)
    {
        CurrentState?.Exit(this);
        CurrentState = state;
        CurrentState.Enter(this);
    }
}