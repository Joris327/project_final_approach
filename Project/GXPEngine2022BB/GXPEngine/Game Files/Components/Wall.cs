using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Wall : Sprite
    {
        public Wall(int pX, int pY, int pRotation) : base("inventory_placeholder.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            rotation = pRotation;
        }
    }
}
