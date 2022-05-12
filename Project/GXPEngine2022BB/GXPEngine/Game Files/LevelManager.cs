using System;
using GXPEngine;
using System.Collections.Generic;
using System.Drawing;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        public static LevelManager current;
        readonly MyGame myGame = MyGame.current;

        Button mainMenuButton;
        Button reloadButton;
        Button nextLevelButton;

        public int currentLevel = 0;

        public int ammo = 3;

        public List<LevelUI> _levelUI = new List<LevelUI>();

        public Canvas _lineContainer = null;

        public bool mainMenu = true;

        public bool levelComplete = false;

        int reloads = 0;

        public LevelManager() : base()
        {
            current = this;

            LoadMainMenu();
        }

        void Update()
        {
            if (mainMenuButton != null && mainMenuButton.CheckIfPressed() == true)
            {
                myGame.gameStarted = false;
                LoadMainMenu();
            }

            if (reloadButton != null && reloadButton.CheckIfPressed() == true || Input.GetKeyDown(Key.BACKSPACE))
            {
                LoadLevel(currentLevel);
                reloads++;
            }

            if (nextLevelButton != null)
            {
                if (EnemiesPresent() == true)
                {
                    //nextLevelButton.SetColor(255, 0, 0);
                    nextLevelButton.color = 0x888888; //light gray
                }
                else if (nextLevelButton.CheckIfPressed() == true)
                {
                    if (currentLevel + 1 == 11)
                    {
                        LoadMainMenu();
                    }
                    else LoadLevel(currentLevel + 1);

                    reloads = 0;

                }
                else nextLevelButton.SetColor(255, 255, 255);

                if (reloadButton != null && reloadButton.CheckIfHovered() == true) reloadButton.SetCycle(1);
                else if (reloadButton != null) reloadButton.SetCycle(0);

                if (nextLevelButton != null && nextLevelButton.color != 0x888888 && nextLevelButton.CheckIfHovered() == true) nextLevelButton.SetCycle(1);
                else if (reloadButton != null) nextLevelButton.SetCycle(0);

                if (mainMenuButton != null && mainMenuButton.CheckIfHovered() == true) mainMenuButton.SetCycle(1);
                else if (reloadButton != null) mainMenuButton.SetCycle(0);

                if (myGame.gameStarted ==true && EnemiesPresent() == false) ShowLevelEndScreen();

                if (reloads >= 3) nextLevelButton.color = 0xffffff;
            }
        }

        int levelCompleteDelay = 30;

        void ShowLevelEndScreen()
        {
            levelCompleteDelay--;
            if (levelCompleteDelay > 0) return;

            if (levelComplete == false) AddChild(new LevelCompleted(ammo+1));
            levelComplete = true;
        }

        bool EnemiesPresent()
        {
            if (FindObjectOfType(typeof(Enemy)) != null) return true;
            else return false;
        }

        public void LoadControls()
        {
            RemoveAllLevels();
            SettingsMenu controls = new SettingsMenu();
            LateAddChild(controls);
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

            levelComplete = false;
            levelCompleteDelay = 30;

            switch (index)
            {
                case 1:
                    myGame.gameStarted = true;
                    AddChild(new Level1());
                    LevelUI levelUI1 = new LevelUI(0, 0);
                    AddChild(levelUI1);
                    _levelUI.Add(levelUI1);
                    myGame.mainMusicPlaying = false;
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
                    myGame.gameStarted = true;
                    AddChild(new Level1());
                    LevelUI levelUId = new LevelUI(0, 0);
                    AddChild(levelUId);
                    _levelUI.Add(levelUId);
                    myGame.mainMusicPlaying = false;
                    break;
            }

            reloadButton = new Button(myGame.width - 105, 50, "RedoSpriteSheet.png", true, 2, 1);
            AddChild(reloadButton);

            mainMenuButton = new Button(myGame.width - 210, 50, "XStyleSheet.png", true, 2, 1);
            AddChild(mainMenuButton);

            nextLevelButton = new Button(myGame.width - 315.5f, 50, "NextLevelSpriteSheet.png", true, 2, 1);
            AddChild(nextLevelButton);
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

        public void LoadStory()
        {
            RemoveAllLevels();
            Story story = new Story();
            LateAddChild(story);
        }
    }
}