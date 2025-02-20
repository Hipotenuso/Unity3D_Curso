using UnityEngine;

namespace Boss
{
    public class BossWalk : BossState
    {
        public BossWalk(GameObject _boss, BossBase _bossBase) : base(_boss, _bossBase) { }

        public override void Enter()
        {
            //Debug.Log("Boss começou a se mover!");
            base.Enter();
        }

        public override void Update()
        {
           bossBase.GoToRandomPoint();
        }

        public override void Exit()
        {
            Debug.Log("Boss parou de se mover.");
            base.Exit();
        }
    }
}
