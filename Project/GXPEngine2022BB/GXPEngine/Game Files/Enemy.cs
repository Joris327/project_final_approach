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
        public Enemy(float pX, float pY) : base("barry.png", 7, 1)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            SetFrame(7);
            this.collider.isTrigger = true;
        }

        void OnCollision(GameObject other)
        {
            if (other is Block)
            {
                //Console.WriteLine("Hit");
                this.LateDestroy();
            }
        }
    }
}
