using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        Intro,
        Gameplay,
        Pause,
        Win,
        Lose
    }

    //public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        //nit();
    }

    //private void Init()
    //{
        //stateMachine = new StateMachine<GameStates>();
        //stateMachine.Init();
        //stateMachine.RegisterStates(GameStates.Intro, new GMStateIntro());
        //stateMachine.RegisterStates(GameStates.Gameplay, new StateBase());
        //stateMachine.RegisterStates(GameStates.Pause, new StateBase());
        //stateMachine.RegisterStates(GameStates.Win, new StateBase());
        //stateMachine.RegisterStates(GameStates.Lose, new StateBase());

        //stateMachine.SwitchState(GameStates.Intro);
    //}
}
