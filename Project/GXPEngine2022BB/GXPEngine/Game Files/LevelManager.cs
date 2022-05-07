using System;
using GXPEngine;
using System.Collections.Generic;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        public static LevelManager current;
        MyGame myGame = MyGame.current;

        Button mainMenuButton;

        public LevelManager() : base()
        {
            current = this;

            LoadMainMenu();
        }

        void Update()
        {
            if (mainMenuButton != null)
            {
                if (mainMenuButton.CheckIfPressed() == true)
                {
                    LoadMainMenu();
                }
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

            mainMenuButton = new Button(myGame.width - 32, 32, "square.png");
            AddChild(mainMenuButton);
            LateAddChild(new LevelUI(2, 2));

            switch (index)
            {
                case 1:
                    LoadLevel1();
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

        void LoadLevel1()
        {
            Level1 level1 = new Level1();
            LateAddChild(level1);
        }
    }
}