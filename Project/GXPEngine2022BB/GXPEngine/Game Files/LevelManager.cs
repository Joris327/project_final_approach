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

        public List<LevelUI> _levelUI = new List<LevelUI>();

        public Canvas _lineContainer = null;

        public LevelManager() : base()
        {
            current = this;

            LoadLevel(0);
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
                if (FindObjectOfType(typeof(Enemy)) != null)
                {
                    nextLevelButton.SetColor(255, 0, 0);
                }
                else if (nextLevelButton.CheckIfPressed() == true) LoadLevel(currentLevel + 1);
                else nextLevelButton.SetColor(255, 255, 255);

                //if (nextLevelButton.CheckIfPressed() == true) LoadLevel(currentLevel + 1);
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
            _levelUI.Clear();

            currentLevel = index;

            ammo = 3;

            bool mainMenu = false;

            switch (index)
            {
                case 1:
                    AddChild(new Level1());
                    LevelUI levelUI1 = new LevelUI(0, 0);
                    AddChild(levelUI1);
                    _levelUI.Add(levelUI1);
                    break;
                case 2:
                    AddChild(new Level2());
                    LevelUI levelUI2 = new LevelUI(0, 0);
                    AddChild(levelUI2);
                    _levelUI.Add(levelUI2);
                    break;
                case 3:
                    AddChild(new Level3());
                    LevelUI levelUI3 = new LevelUI(0, 1);
                    AddChild(levelUI3);
                    _levelUI.Add(levelUI3);
                    break;
                case 4:
                    AddChild(new Level4());
                    LevelUI levelUI4 = new LevelUI(1, 2);
                    AddChild(levelUI4);
                    _levelUI.Add(levelUI4);
                    break;
                case 5:
                    AddChild(new Level5());
                    LevelUI levelUI5 = new LevelUI(2, 1);
                    AddChild(levelUI5);
                    _levelUI.Add(levelUI5);
                    break;
                case 6:
                    AddChild(new Level6());
                    LevelUI levelUI6 = new LevelUI(1, 1);
                    AddChild(levelUI6);
                    _levelUI.Add(levelUI6);
                    break;
                case 7:
                    AddChild(new Level7());
                    LevelUI levelUI7 = new LevelUI(1, 2);
                    AddChild(levelUI7);
                    _levelUI.Add(levelUI7);
                    break;
                case 8:
                    AddChild(new Level8());
                    LevelUI levelUI8 = new LevelUI(1, 1);
                    AddChild(levelUI8);
                    _levelUI.Add(levelUI8);
                    break;
                case 9:
                    AddChild(new Level9());
                    LevelUI levelUI9 = new LevelUI(3, 3);
                    AddChild(levelUI9);
                    _levelUI.Add(levelUI9);
                    break;
                case 10:
                    AddChild(new Level10());
                    LevelUI levelUI10 = new LevelUI(3, 2);
                    AddChild(levelUI10);
                    _levelUI.Add(levelUI10);
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