using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class CrateDestruction : AnimationSprite
    {
        public CrateDestruction(float pX, float pY) : base("crate_destroyed_spritesheet.png", 4, 5, -1, false, false)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            SetScaleXY(0.75f, 0.75f);
        }

        void Update()
        {
            Animate();
            if (currentFrame == 17) Destroy();
        }
    }
}
