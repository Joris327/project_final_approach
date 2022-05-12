using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PlacableWall : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;
        readonly LevelUI levelUI;

        bool followMouse = true;

        Block BlockA;
        Block BlockB;

        bool obstructed = false;
        bool obstructedlastFrame = false;

        public PlacableWall(float pX, float pY, int pRotation, LevelUI pGameUI) : base("WallTexture.png", false, true)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            rotation = pRotation;
            levelUI = pGameUI;

            AddRigidBody();
        }

        void Update()
        {
            if (followMouse == true)
            {
                FollowMouse();

                if (CheckIfObstructed() == false && Input.GetMouseButtonDown(0))
                {
                    followMouse = false;
                    levelUI.holdingObject = false;

                    if (myGame.soundOn == true)
                    {
                        Sound placeWall = new Sound("place metal wall.mp3");
                        placeWall.Play();
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    ReturnToInventory();
                    levelUI.holdingObject = false;
                }
            }
            else
            {
                CheckReturnToInventory();
            }
        }

        void CheckReturnToInventory()
        {
            if (levelManager.levelComplete) return;

            int mouseX = Input.mouseX;
            int mouseY = Input.mouseY;
            bool mouseOverlaps = false;

            if (rotation == 0)
            {
                if (mouseX < x + width/2 &&
                    mouseX > x - width/2 &&
                    mouseY > y - height/2 &&
                    mouseY < y + height/2)
                {
                    mouseOverlaps = true;
                }
            }
            else if (rotation == 90)
            {
                if (mouseX < x + height / 2 &&
                    mouseX > x - height / 2 &&
                    mouseY > y - width / 2 &&
                    mouseY < y + width / 2)
                {
                    mouseOverlaps = true;
                }
            }

            if (mouseOverlaps == true)
            {
                SetColor(255, 255, 0);
                if (Input.GetMouseButtonDown(0)) ReturnToInventory();
            }
            else
            {
                SetColor(255, 255, 255);
            }
        }

        bool CheckIfObstructed()
        {
            obstructed = false;

            if (obstructedlastFrame)
            {
                obstructedlastFrame = false;
                return true;
            }

            if (rotation == 0)
            {
                if (myGame.LeftXBoundary > x - width / 2 ||
                    myGame.RightXBoundary < x + width / 2 ||
                    myGame.TopYBoundary > y - height / 2 ||
                    myGame.BottomYBoundary < y + height / 2)
                {
                    obstructed = true;
                }
            }
            else if (rotation == 90)
            {
                if (myGame.LeftXBoundary > x - height/2 ||
                    myGame.RightXBoundary < x + height/2 ||
                    myGame.TopYBoundary > y - width/2 ||
                    myGame.BottomYBoundary < y + height/2)
                {
                    obstructed = true;
                }
            }

            if (obstructed == true)
            {
                SetColor(255, 0, 0);
                return true;
            }
            else
            {
                SetColor(255, 255, 255);
                return false;
            }
        }

        void FollowMouse()
        {
            if (rotation == 0)
            {
                SetXY(Input.mouseX, Input.mouseY);
                BlockA._position = new Vec2(x + 1, y - 39);
                BlockB._position = new Vec2(x + 1, y + 39);
            }
            else if (rotation == 90)
            {
                SetXY(Input.mouseX, Input.mouseY);
                BlockA._position = new Vec2(x - 39, y);
                BlockB._position = new Vec2(x + 39, y);
            }

            if (Input.GetKeyDown(Key.BACKSPACE))
            {
                ReturnToInventory();
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
            if (rotation == 0) levelUI.vWallsAmount++;
            else if (rotation == 90) levelUI.hWallsAmount++;

            BlockA.LateDestroy();
            BlockB.LateDestroy();

            int indexA = -1;
            int indexB = -1;

            foreach(Block b in myGame._movers)
            {
                if (b == BlockA) indexA = myGame._movers.IndexOf(b);
                else if (b == BlockB) indexB = myGame._movers.IndexOf(b);
            }

            if (indexA != -1) myGame._movers.RemoveAt(indexA);
            if (indexB!= -1) myGame._movers.RemoveAt(indexB-1);

            LateDestroy();
        }

        void OnCollision(GameObject other)
        {
            Console.WriteLine("collided");

            if (other is PlacableWall || other is StaticWall || other is Enemy || other is Player || other is PlayerArm || other is Crate || other is Platform)
            {
                obstructed = true;
                obstructedlastFrame = true;
                SetColor(255, 0, 0);
            }
        }
    }
}