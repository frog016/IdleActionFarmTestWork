using UnityEngine;

[RequireComponent(typeof(Collider), typeof(WheatBag))]
public class WheatBlockCollector : MonoBehaviour
{
    private WheatBag _bag;

    private void Awake()
    {
        _bag = GetComponent<WheatBag>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<WheatBlock>(out var block))
            _bag.Add(block);
    }
}
