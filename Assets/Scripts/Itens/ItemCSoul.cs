using UnityEngine;

namespace Itens
{
    public class ItemCSoul : ItemCBase
    {

        void Awake()
        {
            itemManager = FindAnyObjectByType<ItemManager>();
            _collider = GetComponent<Collider>();
        }
        protected override void Collect()
        {
            base.Collect();
            itemManager.AddByType(ItemType.Coin);
            _collider.enabled = false;
        }
    }
}
