using UnityEngine;

public class Moving : PlayerState
{
    public Moving(GameObject _player, PlayerNew _playerNew) : base(_player, _playerNew)
    {
        stateName = STATE.Moving;
    }

    public override void Enter()
    {
        Debug.Log("Entrou no estado Moving");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Rodando Moving...");

        // Movimentação do jogador
        playerNew.PlayerNewMoviment();

        // Se o jogador parar de se mover, volta para Idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            nextState = new Idle(owner, playerNew);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        Debug.Log("Saindo do estado Moving");
        base.Exit();
    }
}
