using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class StarAnim : AnimationSprite
    {
        public bool animate = false;

        public StarAnim(float pX, float pY) : base("star_spritesheet.png", 5, 4, -1, false, false)
        {
            SetXY(pX, pY);
        }

        void Update()
        {
            //Console.WriteLine("updating");
            if (currentFrame < 19 && animate == true) Animate();
        }
    }
}
