using UnityEngine;

namespace Boss
{
    public class BossStateMachine
    {
        private BossState currentState;
        private BossBase boss;

        public BossStateMachine(BossBase _boss)
        {
            boss = _boss;
        }

        public void SetState(BossState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            if (currentState != null)
            {
                BossState nextState = currentState.Process();
                if (nextState != currentState)
                {
                    SetState(nextState);
                }
            }
        }
    }
}

