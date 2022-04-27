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

        public LevelBase(LevelManager pLevelManager) : base("colors.png", false, false)
        {
            levelManager = pLevelManager;

            AddChild(mainMenuButton);
            LateAddChild(new Player(200, 200, levelManager));
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