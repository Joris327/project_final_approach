using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    public class InventoryBar : Sprite
    {
        public InventoryBar(float pX, float pY) : base("Empty_UUI.png", false, false)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
        }
    }
}