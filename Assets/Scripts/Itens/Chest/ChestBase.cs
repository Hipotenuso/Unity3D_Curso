using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Itens
{
    public class ChestBase : MonoBehaviour
    {
        public KeyCode keyCode = KeyCode.O;
        public Animator _animator;
        public GameObject notification;
        public float delayToCollectCoins;
        public float startScale;
        public float tweenDuration = .3f;
        public Ease tweenEase = Ease.OutBack;
        public string TriggerToOpen = "Open";
        public bool chestOpened = false;

        [Space]
        public ChestitemBase chestitemBase;


        private void Start()
        {
            startScale = notification.transform.localScale.x;
            HideNotification();
        }

        [NaughtyAttributes.Button]
        private void OpenChest()
        {
            if(chestOpened) return;

            _animator.SetTrigger(TriggerToOpen);
            HideNotification();
            chestOpened = true;
            Invoke(nameof(ShowItem), .2f);
            Invoke(nameof(CollectItem), delayToCollectCoins);
        }

        private void ShowItem()
        {
            chestitemBase.ShowItem();
        }

        private void CollectItem()
        {
            chestitemBase.Collect();
        }


        void OnTriggerEnter(Collider other)
        {
            PlayerNew p = other.transform.GetComponent<PlayerNew>();
            if(p != null)
            {
                ShowNotification();
            }
        }
        void OnTriggerExit(Collider other)
        {
            PlayerNew p = other.transform.GetComponent<PlayerNew>();
            if(p != null)
            {
                HideNotification();
            }
        }


        [NaughtyAttributes.Button]
        private void ShowNotification()
        {
            notification.SetActive(true);
            notification.transform.localScale = Vector3.zero;
            notification.transform.DOScale(startScale, tweenDuration);
        }

        [NaughtyAttributes.Button]
        private void HideNotification()
        {
            notification.transform.DOScale(Vector3.zero, tweenDuration);
            StartCoroutine(DesativeChest());
        }

        IEnumerator DesativeChest()
        {
            yield return new WaitForSeconds(tweenDuration);
            notification.SetActive(false);
        }
        void Update()
        {
            if(Input.GetKeyDown(keyCode) && notification.activeSelf)
            {
                OpenChest();
            }
        }
    }
}
