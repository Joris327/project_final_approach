using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    public class GameUI : Canvas
    {
        MyGame myGame = MyGame.current;

        readonly LevelManager levelManager;

        public int hWallsAmount;
        public int vWallsAmount;

        int mouseX = Input.mouseX;
        int mouseY = Input.mouseY;

        public GameUI(LevelManager pLevelManager, int pHWallsAmount, int pVWallsAmount) : base(1280, 720, false)
        {
            levelManager = pLevelManager;
            hWallsAmount = pHWallsAmount;
            vWallsAmount = pVWallsAmount;
        }

        void Update()
        {
            mouseX = Input.mouseX;
            mouseY = Input.mouseY;

            graphics.Clear(Color.Empty);

            if (Input.GetKey(Key.SPACE)) DrawMouseCoords();

            DrawInventory();

            if (mouseY < height &&
                mouseY > height - 64 &&
                Input.GetMouseButtonDown(0))
            {
                if (mouseX < width / 2 - 80 &&
                    mouseX > width / 2 - 150 &&
                    hWallsAmount > 0)
                {
                    PlacebleWall wallh = new PlacebleWall(mouseX, mouseY, 0, this);
                    levelManager.LateAddChild(wallh);
                    --hWallsAmount;
                }
                else if (mouseX < width / 2 - 10 &&
                         mouseX > width / 2 - 80 &&
                         vWallsAmount > 0)
                {
                    PlacebleWall wallv = new PlacebleWall(mouseX, mouseY, 90, this);
                    levelManager.LateAddChild(wallv);
                    --vWallsAmount;
                }
            }
        }

        void DrawInventory()
        {
            DrawSprite(new InventoryBar(myGame.width / 2, myGame.height - 32));

            graphics.DrawString(hWallsAmount.ToString(), SystemFonts.DefaultFont, Brushes.Blue, width / 2 - 105, height - 32);
            graphics.DrawString(vWallsAmount.ToString(), SystemFonts.DefaultFont, Brushes.Blue, width / 2 - 35, height - 32);
        }

        void DrawMouseCoords()
        {
            graphics.DrawString(mouseX.ToString() + " " + mouseY.ToString(), SystemFonts.DefaultFont, Brushes.White, 100, 100);
        }
    }
}