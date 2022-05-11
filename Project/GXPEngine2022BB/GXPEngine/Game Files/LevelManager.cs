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
        Button nextLevelButton;

        int currentLevel = 0;

        public int ammo = 3;

        public LevelManager() : base()
        {
            current = this;

            LoadLevel(6);
        }

        void Update()
        {
            if (mainMenuButton != null && mainMenuButton.CheckIfPressed() == true)
            {
                LoadMainMenu();
            }

            if (reloadButton != null && reloadButton.CheckIfPressed() == true || Input.GetKeyDown(Key.BACKSPACE))
            {
                LoadLevel(currentLevel);
            }

            if (nextLevelButton != null)
            {
                /*
                if (FindObjectOfType(typeof(Enemy)) != null)
                {
                    nextLevelButton.SetColor(255, 0, 0);
                }
                else if (nextLevelButton.CheckIfPressed() == true) LoadLevel(currentLevel + 1);
                else nextLevelButton.SetColor(255, 255, 255);
                */
                if (nextLevelButton.CheckIfPressed() == true) LoadLevel(currentLevel + 1);
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

            currentLevel = index;

            ammo = 3;

            bool mainMenu = false;

            switch (index)
            {
                case 1:
                    AddChild(new Level1());
                    AddChild(new LevelUI(0,0));
                    break;
                case 2:
                    AddChild(new Level2());
                    AddChild(new LevelUI(0,0));
                    break;
                case 3:
                    AddChild(new Level3());
                    AddChild(new LevelUI(0,1));
                    break;
                case 4:
                    AddChild(new Level4());
                    AddChild(new LevelUI(1,2));
                    break;
                case 5:
                    AddChild(new Level5());
                    AddChild(new LevelUI(2, 1));
                    break;
                case 6:
                    AddChild(new Level6());
                    AddChild(new LevelUI(1, 0));
                    break;
                default:
                    LoadMainMenu();
                    mainMenu = true;
                    break;
            }

            

            if (mainMenu == false) //prevents the buttons on the top right appearing on the main menu when loading from this method.
            {
                reloadButton = new Button(myGame.width - 32, 32, "checkers.png");
                AddChild(reloadButton);

                mainMenuButton = new Button(myGame.width - 94, 32, "square.png");
                AddChild(mainMenuButton);

                nextLevelButton = new Button(myGame.width - 160, 32, "colors.png");
                AddChild(nextLevelButton);
            }
        }

        void RemoveAllLevels()
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