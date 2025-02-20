using UnityEngine;

namespace Boss
{
    public abstract class BossState : StateMachineBase<BossState>
    {
        protected BossBase bossBase;

        public BossState(GameObject _boss, BossBase _bossBase) : base(_boss)
        {
            bossBase = _bossBase;
        }
    }
}
