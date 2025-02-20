using UnityEngine;
using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;

namespace Boss
{
    public class BossAggro : MonoBehaviour
    {
        private BossBase bossBase;
        public ProjectileBase prefabProjectile;
        public Transform positionToShoot;
        public PlayerNew playerNew;
        public float speed = 2;
        public float startAnimationDuration;
        public Ease startAnimationEase = Ease.OutBack;
        
        private bool canShoot = true; // Controla quando pode disparar
        public float shootDelay = 1f; // Tempo de atraso entre disparos

        private void Start()
        {
            bossBase = GetComponentInParent<BossBase>(); // Obtém a referência do BossBase
            playerNew = FindAnyObjectByType<PlayerNew>();
        }

        private void Update()
        {
            AttackPlayer();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("boss surgiu");
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        private void AttackPlayer()
        {     
            transform.LookAt(playerNew.transform.position);
            
            // Verifica se pode disparar (sem disparar múltiplas vezes)
            if (canShoot)
            {
                Tiro();
                StartCoroutine(AttackDelay());
            }
        }

        private void Tiro()
        {
            var projectile = Instantiate(prefabProjectile);
            projectile.transform.position = positionToShoot.position;
            projectile.transform.rotation = positionToShoot.rotation;
            projectile.speed = speed;
            Debug.Log("disparo efetuado");
        }

        // Corrotina para controlar o tempo entre disparos
        IEnumerator AttackDelay()
        {
            canShoot = false; // Impede o disparo até o tempo de atraso passar
            yield return new WaitForSeconds(shootDelay); // Espera pelo tempo de atraso
            canShoot = true; // Permite o próximo disparo
        }
    }
}
