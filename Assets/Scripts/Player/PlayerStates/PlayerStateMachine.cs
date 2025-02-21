using UnityEngine;

namespace player.playerState
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerState currentState;

        void Start()
        {
            // Começa no estado Idle
            currentState = new PlayerIdleState(gameObject, GetComponent<PlayerNew>());
        }

        void Update()
        {
            // Processa o estado atual e troca caso necessário
            currentState = currentState.Process();
        }
    }
}
