using UnityEngine;
using DG.Tweening;
using System.Collections;

public class DestructableScenarioBase : MonoBehaviour
{
    public healthBase _healthBase;
    public int dropCoins = 3;
    public Transform dropPosition;
    public GameObject prefabCoinPhysics;
    public float shakeDuration = .1f;
    public int shakeForce = 5;

    private void OnValidate()
    {
        if(_healthBase == null) _healthBase = GetComponent<healthBase>();
    }
    private void Awake()
    {
        OnValidate();
        _healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(healthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up, shakeForce);
        DropCoins();
    }

    [NaughtyAttributes.Button]
    private void DropCoins()
    {
        var i = Instantiate(prefabCoinPhysics);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, .3f).SetEase(Ease.OutBack).From();
    }

    private void DropGroupOfCoins()
    {
        StartCoroutine(DropGroupOfCoinsCoroutine());
    }

    IEnumerator DropGroupOfCoinsCoroutine()
    {
        for(int i = 0; i < dropCoins; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }
}
