using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    public class Inventory : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager;
        readonly Canvas inventoryUI = new Canvas(300,300,false);

        int hWallsAmount;
        int vWallsAmount;

        public Inventory(int pX, int pY, LevelManager pLevelManager, int pHWallsAmount=0, int pVWallsAmount=0) : base("inventory_placeholder.png", false, false)
        {
            SetXY(pX, pY);
            inventoryUI.SetXY(450, 530);

            levelManager = pLevelManager;

            hWallsAmount = pHWallsAmount;
            vWallsAmount = pVWallsAmount;

            levelManager.LateAddChild(inventoryUI);
        }

        void Update()
        {
            DrawInventoryUI();

            //if (Input.mouseX < )
        }

        void DrawInventoryUI()
        {
            inventoryUI.graphics.Clear(Color.Empty);
            inventoryUI.graphics.DrawString(hWallsAmount.ToString(), SystemFonts.DefaultFont, Brushes.Blue, width/4, width/2);
            inventoryUI.graphics.DrawString(vWallsAmount.ToString(), SystemFonts.DefaultFont, Brushes.Blue, width/2.1f, width/2);
        }
    }
}
