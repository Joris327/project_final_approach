using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        LevelManager levelManager;
        readonly Button mainMenuButton = new Button(764, 32, "square.png");
        readonly Player player = new Player(200, 200);

        public Level1(LevelManager pLevelManager) : base("colors.png", false, false)
        {
            levelManager = pLevelManager;

            AddChild(mainMenuButton);
            LateAddChild(player);
        }

        void Update()
        {
            if (mainMenuButton.CheckIfPressed() == true)
            {
                levelManager.LoadMainMenu();
            }
        }
    }
}