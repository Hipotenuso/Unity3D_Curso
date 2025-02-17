using System;
using Unity.VisualScripting;
using UnityEngine;

public class States
{
    public enum STATE
    {
        Stopped, Moving
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE stateName;
    protected EVENT stage;
    protected GameObject player;
    protected PlayerNew myPlayer;
    protected States nextState;
    protected Animator animator;

    public States(GameObject _player, PlayerNew _myPlayer)
    {
        player = _player;
        myPlayer = _myPlayer;
    }

    public States()
    {
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public States Process()
    {
        if(stage == EVENT.ENTER)
        {
            Enter();
        }
        else if(stage == EVENT.UPDATE)
        {
            Update();
        }
        else
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public static implicit operator State(States v)
    {
        throw new NotImplementedException();
    }
}

public class Idle : States
{
    public Idle(GameObject _player, PlayerNew _myPlayer) : base(_player, _myPlayer)
    {
        stateName = STATE.Stopped;
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        Debug.Log("Rodando Idle");
        nextState = new Moving(player, myPlayer);
        stage = EVENT.EXIT;
        
    }

    public override void Exit()
    {
        
        base.Exit();
    }
}

public class Moving : States
{
    public Moving(GameObject _player, PlayerNew _myPlayer) : base(_player, _myPlayer)
    {
        stateName = STATE.Moving;
    }

    public override void Enter()
    {
        Debug.Log("Entrou em Moving");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Rodando moving");
        //myPlayer.PlayerMoviment();
    }

    public override void Exit()
    {
        base.Exit();
    }
}