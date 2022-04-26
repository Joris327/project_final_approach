using System;
using GXPEngine;

namespace GXPEngine
{
    public class LevelBase : Sprite
    {
        //this class in intended to function as a blueprint to make the other levels off of.
        //it should not ever be invoked

        LevelManager levelManager;
        readonly Button mainMenuButton = new Button(764, 32, "square.png");
        readonly Player player = new Player(200, 200);

        public LevelBase(LevelManager pLevelManager) : base("colors.png", false, false)
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