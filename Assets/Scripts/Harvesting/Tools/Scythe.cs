using UnityEngine;

public class Scythe : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public void Enable(bool state)
    {
        _collider.enabled = state;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<Wheat>(out var wheat))
            wheat.Slice();
    }
}
