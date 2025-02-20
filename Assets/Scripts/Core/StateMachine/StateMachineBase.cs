using UnityEngine;

public abstract class StateMachineBase<T> where T : StateMachineBase<T>
{
    public enum EVENT { ENTER, UPDATE, EXIT }

    public EVENT stage;
    protected GameObject owner;
    protected T nextState;  // Definir nextState do mesmo tipo que T

    public StateMachineBase(GameObject _owner)
    {
        owner = _owner;
        stage = EVENT.ENTER;  // Começa sempre no ENTER
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public T Process()
    {
        if (stage == EVENT.ENTER) Enter();
        else if (stage == EVENT.UPDATE) Update();
        else
        {
            Exit();
            return nextState;
        }
        return (T)this;  // Faz um cast explícito para garantir que retorna o tipo correto
    }
}
