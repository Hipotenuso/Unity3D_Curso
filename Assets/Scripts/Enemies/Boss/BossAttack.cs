using UnityEngine;

namespace Boss
{
    public class BossAttack : BossState
    {
        public BossAttack(GameObject _boss, BossBase _bossBase) : base(_boss, _bossBase) { }

        public override void Enter()
        {
            Debug.Log("Boss começou o ataque!");
            base.Enter();
        }

        public override void Update()
        {
            Debug.Log("Boss atacando!");
            // Simula dano ao jogador ou outra ação

            nextState = new BossIdle(owner, bossBase);
            stage = EVENT.EXIT;
        }

        public override void Exit()
        {
            Debug.Log("Boss terminou o ataque.");
            base.Exit();
        }
    }
}
