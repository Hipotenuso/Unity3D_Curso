using Unity.VisualScripting;
using UnityEngine;

namespace Itens
{
    public class ItemCBase : MonoBehaviour
    {
        public ItemType itemType;
        public Animator animator;
        
        public ItemManager itemManager;
        public string compareTag = "Tag";
        public float delayToDesapear;

        [Header("Sounds")]
        public AudioSource audioSource;

        void Awake()
        {
            if(itemManager == null)
            {
                itemManager = FindAnyObjectByType<ItemManager>();
            }
            
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.CompareTag(compareTag))
            {
                Collect();
                
            }
        }
        protected virtual void Collect()
        {
            OnCollect();
            //animator.SetBool("Desapear", true);
            Destroy(gameObject, delayToDesapear);
        }
        protected virtual void OnCollect()
        {
            if (audioSource != null) audioSource.Play();
            itemManager.AddByType(itemType);
        }
    }
}