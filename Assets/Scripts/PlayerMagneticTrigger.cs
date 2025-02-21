using Itens;
using UnityEngine;

public class PlayerMagneticTrigger : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemCSoul i = other.transform.GetComponent<ItemCSoul>();
        if(i != null)
        {
            i.gameObject.AddComponent<Magnetic>();
        }
    }
}
