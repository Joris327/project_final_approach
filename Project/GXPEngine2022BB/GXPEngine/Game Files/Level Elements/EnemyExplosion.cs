using System;
using GXPEngine;

namespace GXPEngine
{
    public class EnemyExplosion : AnimationSprite
    {
        public EnemyExplosion(float pX, float pY) : base("enemy_dead_spritesheet.png", 4, 5)
        {
            SetOrigin(width / 2, height / 2);
            SetScaleXY(0.3f, 0.3f);
            SetXY(pX, pY);
        }

        void Update()
        {
            Animate();
            if (currentFrame == 19) this.LateDestroy();
        }
    }
}