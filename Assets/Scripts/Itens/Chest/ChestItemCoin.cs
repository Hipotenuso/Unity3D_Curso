using System.Collections.Generic;
using Itens;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestitemBase
{
    public int coinNumber = 5;
    public GameObject coinObject;
    public ItemManager itemManager;
    public Ease ease = Ease.OutBack;
    public float easeDuration = .3f;
    public float tweenEndTime = .5f;
    public Vector2 randomRange = new Vector2(-2f, 2f);
    private List<GameObject> itens = new List<GameObject>();

    void Awake()
    {
        itemManager = FindAnyObjectByType<ItemManager>();
    }
    public override void ShowItem()
    {
        base.ShowItem();
        CreateItens();
    }


    [NaughtyAttributes.Button]
    private void CreateItens()
    {
        for(int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position + Vector3.forward * Random.Range(randomRange.x, randomRange.y) + Vector3.right * Random.Range(randomRange.x, randomRange.y);
            item.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            itens.Add(item);
        }
    }

    [NaughtyAttributes.Button]
    public override void Collect()
    {
        base.Collect();
        foreach(var i in itens)
        {
            i.transform.DOMoveY(2f, tweenEndTime).SetRelative();
            i.transform.DOScale(0, tweenEndTime/2).SetDelay(tweenEndTime / 2);
            itemManager.AddByType(ItemType.Coin);
        }
    }
}
