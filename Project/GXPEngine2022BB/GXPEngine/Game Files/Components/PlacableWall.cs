using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PlacableWall : Sprite
    {
        LevelUI gameUI;

        bool followMouse = true;

        public PlacableWall(float pX, float pY, int pRotation, LevelUI pGameUI) : base("WallTexture.png")
        {
            SetOrigin(0, 37.5f);
            SetXY(pX, pY);
            rotation = pRotation;
            gameUI = pGameUI;

            AddRigidBody();
        }

        void Update()
        {
            if (followMouse == true)
            {
                if (rotation == 0) SetXY(Input.mouseX - 37.5f, Input.mouseY - 37.5f);
                if (rotation == 90) SetXY(Input.mouseX + 37.5f, Input.mouseY - 37.5f);


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

        void AddRigidBody()
        {
            LateAddChild(new Block(37.5f, new Vec2(36.5f, 0), new Vec2(), true, false));
            LateAddChild(new Block(37.5f, new Vec2(36.5f, 76), new Vec2(), true, false));
        }
    }
}