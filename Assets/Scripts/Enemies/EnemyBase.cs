using UnityEngine;
using DG.Tweening;
using Animation;
using System.Collections;
using Unity.VisualScripting;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageble
    {
        public Collider _collider;
        public FlashColor flashColor;
        public ParticleSystem _particleSystem;
        [SerializeField] private Animationbase _animationBase;
        public float startLife = 10;
        [SerializeField] private float _currentLife;
        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public float delayToDeath = 1.5f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;
        public bool lookAtPlayer = false;
        private PlayerNew _playerNew;

        private void Awake()
        {
            Init();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }
        private void Start()
        {
            _playerNew = GameObject.FindAnyObjectByType<PlayerNew>();
        }

        protected virtual void Init()
        {
            ResetLife();
            if(startWithBornAnimation)
                BornAnimation();
        }
        protected virtual void kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if(_collider != null) _collider.enabled = false;
            Destroy(gameObject, delayToDeath);
            PlayAnimationByTrigger(AnimationType.Death);
        }

        public void OnDamage(float f)
        {
            if(flashColor != null) flashColor.Flash();
            if(_particleSystem != null) _particleSystem.Emit(3);

            transform.position -= transform.forward;

            _currentLife -= f;
            if(_currentLife <= 0)
            {
                kill();
                _particleSystem.Play();
                StartCoroutine(StopParticles());
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        IEnumerator StopParticles()
        {
            yield return new WaitForSeconds(1.6f);
            _particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        #endregion

        //debug

        public virtual void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }
            if(lookAtPlayer)
            {
                transform.LookAt(_playerNew.transform.position);
            }
        }

        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage);
        }
        public void Damage(float damage, Vector3 dir)
        {
            OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);
        }

        void OnCollisionEnter(Collision collision)
        {
            PlayerNew p = collision.transform.GetComponent<PlayerNew>();
            if(p != null)
            {
                p.healthBase.Damage(1);
            }
        }
    }
    
}
