using System;
using GXPEngine;
using System.Collections.Generic;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        public static LevelManager current;
        readonly MyGame myGame = MyGame.current;

        Button mainMenuButton;
        Button reloadButton;

        public LevelManager() : base()
        {
            current = this;

            LoadMainMenu();
        }

        void Update()
        {
            if (mainMenuButton != null && mainMenuButton.CheckIfPressed() == true)
            {
                LoadMainMenu();
            }

            if (reloadButton != null && reloadButton.CheckIfPressed() == true)
            {
                LoadLevel(1);
            }
        }

        public void LoadMainMenu()
        {
            RemoveAllLevels();
            MainMenu mainMenu = new MainMenu();
            LateAddChild(mainMenu);
        }

        public void LoadLevel(int index)
        {
            RemoveAllLevels();

            reloadButton = new Button(myGame.width - 32, 32, "checkers.png");
            LateAddChild(reloadButton);

            mainMenuButton = new Button(myGame.width - 94, 32, "square.png");
            AddChild(mainMenuButton);

            LateAddChild(new LevelUI(2, 2));

            switch (index)
            {
                case 1:
                    LateAddChild(new Level1());
                    break;
                case 2:
                    LateAddChild(new Level2());
                    break;
                default:
                    LoadMainMenu();
                    break;
            }
        }

        public void RemoveAllLevels()
        {
            foreach(GameObject levelObject in this.GetChildren())
            {
                levelObject.LateDestroy();
            }

            foreach (Block b in myGame._movers)
            {
                b.LateDestroy();
            }

            myGame._movers.Clear();
        }
    }
}