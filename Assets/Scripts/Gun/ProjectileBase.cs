using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float currentSpeed;
    public float timeToDestroy;
    public float speed = 50f;
    public float side = 1;
    public int damageAmount;
    public List<string> tagsToHit;
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        foreach(var t in tagsToHit)
        {
            if(collision.transform.tag == t)
            {
                var damageble = collision.transform.GetComponent<IDamageble>();
                if(damageble != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    dir.y = 0;
                    damageble.Damage(damageAmount, dir);
                }

                break;
            }
        }
        Destroy(gameObject);
    }
}
