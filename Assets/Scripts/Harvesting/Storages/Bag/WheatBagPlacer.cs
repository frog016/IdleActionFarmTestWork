using UnityEngine;

public class WheatBagPlacer : MonoBehaviour
{
    [SerializeField] private WheatBag _bag;
    [SerializeField] private Transform _pivot;

    private void OnEnable()
    {
        _bag.ContentChanged += OnContentChanged;
    }

    private void OnDisable()
    {
        _bag.ContentChanged -= OnContentChanged;
    }

    private void OnContentChanged(WheatBlock item, ContentAction action)
    {
        switch (action)
        {
            case ContentAction.Add:
                PlaceBlock(item);
                break;
            case ContentAction.Pop:
                RemoveBlock(item);
                break;
        }
    }

    private void PlaceBlock(WheatBlock item)
    {
        var lastPosition = _bag.Count == 0 ? Vector3.zero : _bag.Last.transform.localPosition;
        item.transform.parent = _pivot;
        item.transform.localPosition = lastPosition + Vector3.Scale(_pivot.up, item.Size);
    }

    private void RemoveBlock(WheatBlock item)
    {
        item.transform.parent = null;
    }
}