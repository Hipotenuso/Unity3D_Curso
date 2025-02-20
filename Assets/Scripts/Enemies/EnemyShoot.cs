using Enemy;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        public StaffBase staffBase;

        protected override void Init()
        {
            base.Init();

            staffBase.StartShooting();
        }
    }

}
