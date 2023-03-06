using System.Collections;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private Scythe _scythe;
    [SerializeField] private Animator _animator;

    public bool InProcess { get; private set; }

    private readonly int _harvestHash = Animator.StringToHash("Harvest");

    public void HarvestWheat()
    {
        InProcess = true;
        _scythe.Enable(true);
        _scythe.gameObject.SetActive(true);
        _animator.SetBool(_harvestHash, true);
        StartCoroutine(EndHarvest());
    }

    private IEnumerator EndHarvest()
    {
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).IsName("Harvest"));
        var currentAnimation = _animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(currentAnimation.length / ( 2 * currentAnimation.speed));
        _scythe.Enable(false);
        yield return new WaitForSeconds(currentAnimation.length / (2 * currentAnimation.speed));
        _animator.SetBool("Harvest", false);
        _scythe.gameObject.SetActive(false);
        InProcess = false;
    }
}
