using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PlacebleWall : Sprite
    {
        GameUI gameUI;

        bool followMouse = true;

        public PlacebleWall(int pX, int pY, int pRotation, GameUI pGameUI) : base("inventory_placeholder.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            rotation = pRotation;
            gameUI = pGameUI;
        }

        void Update()
        {
            if (followMouse == true)
            {
                SetXY(Input.mouseX, Input.mouseY);
                if (Input.GetKeyDown(Key.BACKSPACE))
                {
                    if (rotation == 0) gameUI.hWallsAmount++;
                    else if (rotation == 90) gameUI.vWallsAmount++;

                    LateDestroy();
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                followMouse = false;
            }
        }
    }
}
