using UnityEngine;

public class BossArea : MonoBehaviour
{
    public GameObject Boss;
    public Collider AggroSpawn;

    public void Start()
    {
        Boss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerNew p = other.transform.GetComponent<PlayerNew>();
        if(p != null)
        {
            Boss.SetActive(true);
        }
    }
}