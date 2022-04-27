using System;
using GXPEngine;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        MyGame myGame = MyGame.current;

        Button mainMenuButton;
        GameUI gameUI;

        public LevelManager() : base()
        {
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
            MainMenu mainMenu = new MainMenu(this);
            LateAddChild(mainMenu);
        }

        public void LoadLevel(int number)
        {
            RemoveAllLevels();

            mainMenuButton = new Button(myGame.width - 32, 32, "square.png");
            AddChild(mainMenuButton);

            gameUI = new GameUI(this, 2, 2);
            LateAddChild(gameUI);

            switch (number)
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
        }

        void LoadLevel1()
        {
            Level1 level1 = new Level1(this);
            LateAddChild(level1);
        }
    }
}