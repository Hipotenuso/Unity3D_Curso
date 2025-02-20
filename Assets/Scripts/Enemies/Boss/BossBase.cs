using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public abstract class BossBase : MonoBehaviour
    {
        [Header("Boss Stats")]
        public float maxHealth = 100f;
        public float currentHealth;
        public float damage = 10f;
        public float moveSpeed = 3f;
        public float attackRange = 5f; // Adicionando o campo de alcance de ataque
        private int _index = 0;
        public float minDistance = 1f;
        public List<Transform> waypoints;

        public BossStateMachine stateMachine;

        public virtual void Awake()
        {
            stateMachine = new BossStateMachine(this);
        }

        public virtual void Start()
        {
            stateMachine.SetState(new BossIdle(gameObject, this));
        }


        public virtual void Update()
        {
            // Atualiza a máquina de estados
            stateMachine.Update();
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            Debug.Log(gameObject.name + " tomou " + amount + " de dano! Vida restante: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public virtual void Move(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }

        protected virtual void Die()
        {
            Debug.Log(gameObject.name + " morreu!");
            Destroy(gameObject);
        }
         
        public void GoToRandomPoint()
        {
            StartCoroutine(GoToPointCoroutine(waypoints[Random.Range(0, waypoints.Count)]));
        }

        IEnumerator GoToPointCoroutine(Transform t)
        {
            if(Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
            {
                _index++;
                if(_index >= waypoints.Count)
                {
                    _index = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * moveSpeed);
            //transform.LookAt(waypoints[_index].transform.position);
            yield return new WaitForEndOfFrame();
        }
    }
}
