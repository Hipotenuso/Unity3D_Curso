using UnityEngine;

public abstract class PlayerState : StateMachineBase<PlayerState>
{
    protected PlayerNew playerNew;

    public enum STATE
    {
        Idle, Moving, Jumping, Attacking
    }

    public STATE stateName;

    public PlayerState(GameObject _player, PlayerNew _playerNew) : base(_player)
    {
        playerNew = _playerNew;
    }
}

