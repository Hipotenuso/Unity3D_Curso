using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Itens
{
    public enum ItemType
    {
        Coin,
        Life_pack
    }

    public class ItemManager : MonoBehaviour
    {
        public List<ItemSetup> itemSetups;
        public static ItemManager Instance;

        public SOInt souls;
        public TextMeshProUGUI uiTextSouls;
        public Slider slider;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            Reset();
        }
        private void Reset()
        {
            foreach(var i in itemSetups)
            {
                i.soInt.value = 0;
            }
        }
        public void AddByType(ItemType itemtype, int amount = 1)
        {
            if(amount < 0) return;
            itemSetups.Find(i => i.itemType == itemtype).soInt.value += amount;
        }
        public void RemoveByType(ItemType itemType, int amount = 1)
        {
            if(amount < 0) return;
            var item = itemSetups.Find(i => i.itemType == itemType);
            item.soInt.value -= amount;

            if(item.soInt.value < 0) item.soInt.value = 0;
        }
        public ItemSetup GetByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.itemType == itemType);
        }

        [NaughtyAttributes.Button]
        private void AddCoin()
        {
            AddByType(ItemType.Coin);
        }

        [NaughtyAttributes.Button]
        private void AddLifePack()
        {
            AddByType(ItemType.Life_pack);
        }
 
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }

    
    
}