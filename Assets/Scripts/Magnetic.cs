using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public PlayerNew playerNew;
    public float dist = .2f;
    public float coinSpeed;

    void Awake()
    {
        playerNew = FindAnyObjectByType<PlayerNew>();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, playerNew.transform.position) > dist)
        {
            coinSpeed++;
            transform.position = Vector3.MoveTowards(transform.position, playerNew.transform.position, Time.deltaTime * coinSpeed);
        }
    }
}
