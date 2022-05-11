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
        MyGame myGame = MyGame.current;
        Sound explosion;

        public Enemy(float pX, float pY) : base("spritesheet_robot.png", 4, 2)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            SetScaleXY(0.3f, 0.3f);
            SetFrame(0);
            SetCycle(0, 4);
            this.collider.isTrigger = true;
        }

        void Update()
        {
            if(myGame.soundOn == true)
            {
                explosion = new Sound("explosion.mp3");
            } else
            {
                explosion = new Sound("");
            }
            Animate(0.1f);
        }

        void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                //Console.WriteLine("Hit");
                explosion.Play(false, 0, 0.75f);
                this.LateDestroy();
            }
        }
    }
}