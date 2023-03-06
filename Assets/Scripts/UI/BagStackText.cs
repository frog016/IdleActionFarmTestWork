using UnityEngine;

public class BagStackText : TextObserver
{
    [SerializeField] private WheatBag _bag;

    private string Text => $"{_bag.Count + 1}/{_bag.Capacity}";

    protected override void Subscribe()
    {
        ChangeValue($"{_bag.Count}/{_bag.Capacity}");
        _bag.ContentChanged += OnContentChanged;
    }

    protected override void Unsubscribe()
    {
        _bag.ContentChanged -= OnContentChanged;
    }

    private void OnContentChanged(WheatBlock wheat, ContentAction content)
    {
        ChangeValue(Text);
    }
}
