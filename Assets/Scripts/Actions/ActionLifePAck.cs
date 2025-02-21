using UnityEngine;
using Itens;

public class ActionLifePAck : MonoBehaviour
{
    public SOInt soInt;
    public PlayerNew playerNew;
    public ItemManager itemManager;
    public KeyCode lifePackInput;

    void Awake()
    {
        itemManager = FindAnyObjectByType<ItemManager>();
        playerNew = FindAnyObjectByType<PlayerNew>();
    }

    void Start()
    {
        soInt = itemManager.GetByType(ItemType.Life_pack).soInt;
    }

    private void RecoverLife()
    {
        if(soInt.value > 0)
        {
            itemManager.RemoveByType(ItemType.Life_pack);
            Debug.Log("cura");
            playerNew.healthBase.ResetLife();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(lifePackInput))
        {
            RecoverLife();
        }
    }
}
