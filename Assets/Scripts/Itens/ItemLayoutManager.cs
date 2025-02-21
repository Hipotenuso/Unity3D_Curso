using System.Collections.Generic;
using UnityEngine;

namespace Itens
{   
    public class ItemLayoutManager : MonoBehaviour
    {
        public ItemLayout prefabLayout;
        public ItemLayout prefabLayout2;
        public ItemManager itemManager;

        public List<ItemLayout> itemLayouts;

        public Transform container;
        void Awake()
        {
            if(itemManager == null)
            {
                itemManager = FindAnyObjectByType<ItemManager>();
            }
        }
        void Start()
        {
            CrateItens();
        }

        private void CrateItens()
        {
            foreach(var setup in itemManager.itemSetups)
            {
                ItemLayout prefabE;

                
                if (setup.itemType == ItemType.Coin)
                {
                    prefabE = prefabLayout2;  
                }
                else
                {
                    prefabE = prefabLayout;  
                }

                
                var item = Instantiate(prefabE, container);
                item.OnLoad(setup);  
                itemLayouts.Add(item);  
            }
        }
    }
}
