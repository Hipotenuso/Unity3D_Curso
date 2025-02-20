using UnityEngine;

namespace Boss
{
    public class BossIdle : BossState
    {
        public BossIdle(GameObject _boss, BossBase _bossBase) : base(_boss, _bossBase) { }

        public override void Enter()
        {
            //Debug.Log("Boss entrou no estado Idle");
            base.Enter();
        }

        public override void Update()
        {
            //Debug.Log("Boss está parado...");

            if (Time.time > 1.5)
            {
                nextState = new BossWalk(owner, bossBase);
                stage = EVENT.EXIT;
            }
        }

        public override void Exit()
        {
            //Debug.Log("Boss saindo do estado Idle");
            base.Exit();
        }
    }
}
