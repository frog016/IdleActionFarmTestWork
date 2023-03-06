using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class TextObserver : MonoBehaviour
{
    protected TextMeshProUGUI _changeableText;

    private string _initialText;

    private void OnEnable()
    {
        _changeableText = GetComponent<TextMeshProUGUI>();
        _initialText = _changeableText.text;
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    protected abstract void Subscribe();

    protected abstract void Unsubscribe();

    protected void ChangeValue(object value)
    {
        _changeableText.text = _initialText + value;
    }
}
