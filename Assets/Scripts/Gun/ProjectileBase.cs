using TMPro;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float currentSpeed;
    public float timeToDestroy;
    public float speed = 50f;
    public float side = 1;
    public int damageAmount;
    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
