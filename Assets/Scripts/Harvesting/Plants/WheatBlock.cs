using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WheatBlock : MonoBehaviour, ISize
{
    public Vector3 Size => _collider.size;

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }
}
