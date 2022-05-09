using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PlacableWall : Sprite
    {
        MyGame myGame = MyGame.current;

        LevelUI gameUI;

        bool followMouse = true;

        Block BlockA;
        Block BlockB;

        public PlacableWall(float pX, float pY, int pRotation, LevelUI pGameUI) : base("WallTexture.png", false, false)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            rotation = pRotation;
            gameUI = pGameUI;

            AddRigidBody();
        }

        void Update()
        {
            if (followMouse == true)
            {
                if (rotation == 0)
                {
                    SetXY(Input.mouseX, Input.mouseY);
                    BlockA._position = new Vec2(x+1, y - 37.5f);
                    BlockB._position = new Vec2(x+1, y + 39.5f);
                }
                else if (rotation == 90)
                {
                    SetXY(Input.mouseX, Input.mouseY);
                    BlockA._position = new Vec2(x - 38.5f, y);
                    BlockB._position = new Vec2(x + 39f, y);
                }

                if (Input.GetKeyDown(Key.BACKSPACE))
                {
                    ReturnToInventory();
                }

                if (Input.GetMouseButtonDown(0))
                {
                    followMouse = false;
                    //BlockA.canCollide = true;
                    //BlockB.canCollide = true;
                }
            }
        }

        void AddRigidBody()
        {
            BlockA = new Block(37.5f, new Vec2(100, 150), new Vec2(), false, false, 999);
            BlockB = new Block(37.5f, new Vec2(100, 200), new Vec2(), false, false, 999);

            myGame.LateAddChild(BlockA);
            myGame.LateAddChild(BlockB);

            myGame._movers.Add(BlockA);
            myGame._movers.Add(BlockB);
        }

        void ReturnToInventory()
        {
            if (rotation == 0) gameUI.hWallsAmount++;
            else if (rotation == 90) gameUI.vWallsAmount++;

            LateDestroy();
        }
    }
}