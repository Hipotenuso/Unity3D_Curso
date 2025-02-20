using UnityEngine;

namespace Boss
{
    public class BossCubeTest : BossBase
    {
        public float smashDamage = 5f;

        public override void Start()
        {
            base.Start(); // Chama o Start() do BossBase
        }

        public void Smash()
        {
            Debug.Log("O Cubo pulou");
        }
    }
}
