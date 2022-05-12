using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

namespace GXPEngine
{
    public class Enemy : AnimationSprite
    {
        readonly MyGame myGame = MyGame.current;

        Sound explosion = new Sound("explsoion.mp3");

        EnemyExplosion enemyExplosion;

        public Enemy(float pX, float pY) : base("spritesheet_robot.png", 4, 2)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            SetScaleXY(0.3f, 0.3f);
            SetFrame(0);
            SetCycle(0, 4);
            this.collider.isTrigger = true;
            enemyExplosion = new EnemyExplosion(x, y);
        }

        void Update()
        {
            Animate(0.1f);
        }

        void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                if (myGame.soundOn == true)
                {
                    explosion.Play(false, 0, 0.75f);
                }

                myGame.LateAddChild(enemyExplosion);
                this.LateDestroy();
            }
        }
    }
}