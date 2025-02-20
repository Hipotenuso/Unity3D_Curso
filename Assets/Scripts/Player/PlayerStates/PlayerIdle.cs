using UnityEngine;

public class Idle : PlayerState
{
    public Idle(GameObject _player, PlayerNew _playerNew) : base(_player, _playerNew)
    {
        stateName = STATE.Idle;
    }

    public override void Enter()
    {
        Debug.Log("Entrou no estado Idle");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Rodando Idle...");

        // Se o jogador apertar uma tecla de movimento, mudar para Moving
        if (Input.GetAxis("Horizontal") != 0)
        {
            nextState = new Moving(owner, playerNew);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        Debug.Log("Saindo do estado Idle");
        base.Exit();
    }
}
