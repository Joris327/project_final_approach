using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class Sparks : AnimationSprite
    {
        public Sparks(float pX, float pY, int protation) : base("Ricochet.png", 3, 3)
        {
            SetScaleXY(0.5f, 0.5f);
            SetXY(pX, pY);
            rotation = protation;
            SetFrame(0);
        }

        void Update()
        {
            Animate();
            if (currentFrame == 8) this.LateDestroy();
        }
    }
}
