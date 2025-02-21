using UnityEngine;

namespace Itens
{
    public class ItemCSoul : ItemCBase
    {
        public Collider _collider;

        void Awake()
        {
            itemManager = FindAnyObjectByType<ItemManager>();
            if(_collider == null)
            {
                _collider = GetComponent<Collider>();
            }
        }

        void Start()
        {
            _collider.enabled = true;
        }
        protected override void Collect()
        {
            base.Collect();
            _collider.enabled = false;
        }
    }
}
