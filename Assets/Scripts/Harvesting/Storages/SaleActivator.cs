using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Seller))]
public class SaleActivator : MonoBehaviour
{
    [SerializeField] private float _flyDuration;
    [SerializeField] private float _pickUpDelay;
    [SerializeField] private Transform _salePointTransform;

    private Seller _seller;
    private Coroutine _saleCoroutine;

    private void Awake()
    {
        _seller = GetComponent<Seller>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<WheatBag>(out var bag))
            _saleCoroutine = StartCoroutine(PickUpBlocks(bag));
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<WheatBag>(out var bag) && _saleCoroutine != null)
            StopCoroutine(_saleCoroutine);
    }

    private IEnumerator PickUpBlocks(WheatBag bag)
    {
        while (bag.Pop(out var block))
        {
            var deletedBlock = block;
            var tweener = block.transform.DOMove(_salePointTransform.position, _flyDuration);
            tweener.SetAutoKill(true);
            tweener.OnComplete(() =>
            {
                _seller.ReceiveMoniesInPosition(_salePointTransform.position);
                Destroy(deletedBlock.gameObject);
            });

            yield return new WaitForSeconds(_pickUpDelay);
        }
    }
}
