using DG.Tweening;
using UnityEngine;

public class MoneyText : TextObserver
{
    [SerializeField] private Wallet _wallet;

    private Vector3 _startPosition;

    protected override void Subscribe()
    {
        _startPosition = GetComponent<RectTransform>().position;
        ChangeValue(_wallet.Balance);
        _wallet.BalanceChanged += ChangeAndAnimate;
    }

    protected override void Unsubscribe()
    {
        _wallet.BalanceChanged -= ChangeAndAnimate;
    }

    private void ChangeAndAnimate(int balance)
    {
        ChangeValue(balance);
        var tweener = _changeableText.transform.DOShakePosition(1f);
        tweener.onComplete += () => transform.position = _startPosition;
    }
}
