using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityBase : MonoBehaviour
{
    protected PlayerNew player;

    protected Inputs inputs;

    void OnValidate()
    {
        if(player == null) player = GetComponent<PlayerNew>();
    }

    void Start()
    {

        inputs = new Inputs();
        inputs.Enable();

        Init();
        OnValidate();
        RegisterListeners();
    }

    private void OnEnable()
    {
        if(inputs != null)
            inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    void OnDestroy()
    {
        RemoveListeners();
    }

    protected virtual void Init() {}
    protected virtual void RegisterListeners() {}
    protected virtual void RemoveListeners() {}
}
