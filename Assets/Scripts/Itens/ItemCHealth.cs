using UnityEngine;

namespace Itens
{
    public class ItemCHealth : ItemCBase
    {
        public GameObject player;
        public float regen;
        protected override void OnCollect()
        {
            base.OnCollect();
            var life = player.GetComponent<healthBase>();
            //life._currentLife += regen;
        }
    }
}
