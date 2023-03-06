using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private readonly int _walkHash = Animator.StringToHash("Walk");
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(_walkHash, _movement.Velocity.magnitude);
    }
}
