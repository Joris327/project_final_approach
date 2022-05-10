using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class AmmoDisplay : AnimationSprite
    {
        LevelManager levelManager = LevelManager.current;

        public AmmoDisplay() : base("Ammo_Spritesheet.png", 4, 1)
        {
            SetCycle(0);
        }

        void Update()
        {
            switch (levelManager.ammo)
            {
                case 3:
                    SetCycle(0);
                    break;
                case 2:
                    SetCycle(1);
                    break;
                case 1:
                    SetCycle(2);
                    break;
                default:
                    SetCycle(3);
                    break;
            }
        }
    }
}
