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

        public int reloads = 0;
        readonly int reloadsMax = 5;

        public int score = 0;

        public int hwallsamount = 0;
        public int vwallsamount = 0;

        public bool holding = false;

        public readonly Sound winmusic = new Sound("you won extra lenth.mp3");

        public SoundChannel winchannel;

        public LevelManager() : base()
        {
            current = this;

            LoadMainMenu();
        }

        void Update()
        {
            if (mainMenuButton != null )
            {
                if (mainMenuButton.CheckIfPressed() == true)
                {
                    if (winchannel != null) winchannel.Stop();
                    reloads = 0;
                    LoadMainMenu();
                }

                if (mainMenuButton.CheckIfHovered() == true) mainMenuButton.SetCycle(1);
                else mainMenuButton.SetCycle(0);
            }

            if (reloadButton != null)
            {
                if (reloadButton.CheckIfPressed() == true || Input.GetKeyDown(Key.BACKSPACE))
                {
                    if (levelComplete)
                    {
                        score -= 100 * ammo;
                        score -= hwallsamount * 50;
                        score -= vwallsamount * 50;
                    }

                    if (winchannel != null) winchannel.Stop();
                    LoadLevel(currentLevel);
                    reloads++;
                    if (myGame.channelLevel != null) myGame.channelLevel.IsPaused = false;
                }

                if (reloadButton.CheckIfHovered() == true) reloadButton.SetCycle(1);
                else reloadButton.SetCycle(0);
            }

            if (nextLevelButton != null)
            {
                if (reloads < reloadsMax)
                {
                    nextLevelButton.color = 0x888888;
                }
                else nextLevelButton.color = 0xffffff;

                if (nextLevelButton.color != 0x888888)
                {
                    if (nextLevelButton.CheckIfHovered() == true) nextLevelButton.SetCycle(1);
                    else nextLevelButton.SetCycle(0);

                    if (nextLevelButton.CheckIfPressed() == true)
                    {
                        if (currentLevel + 1 == 11)
                        {
                            if (winchannel != null) winchannel.Stop();
                            LoadMainMenu();
                        }
                        else
                        {
                            if (winchannel != null) winchannel.Stop();
                            LoadLevel(currentLevel + 1);
                            if (myGame.channelLevel != null) myGame.channelLevel.IsPaused = false;
                            nextLevelButton.SetCycle(0);
                        }

                        reloads = 0;
                    }
                }
            }

            if (myGame.gameStarted == true && EnemiesPresent() == false) ShowLevelEndScreen();
        }

        int levelCompleteDelay = 30;

        void ShowLevelEndScreen()
        {
            levelCompleteDelay--;
            if (levelCompleteDelay > 0) return;

            if (levelComplete == false)
            {
                AddChild(new LevelCompleted(ammo + 1));
                score += 100 * ammo;
            }
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
            myGame.gameStarted = false;

            MainMenu mainMenu = new MainMenu();
            LateAddChild(mainMenu);

            score = 0;
        }

        public bool DetractUILevelPoints = false;

        public void LoadLevel(int index)
        {
            RemoveAllLevels();
            _levelUI.Clear();

            currentLevel = index;

            ammo = 3;
            hwallsamount = 0;
            vwallsamount = 0;

            levelComplete = false;
            levelCompleteDelay = 30;

            LevelUI levelUI1 = null;
            LevelUI levelUI2 = null;
            LevelUI levelUI3 = null;
            LevelUI levelUI4 = null;
            LevelUI levelUI5 = null;
            LevelUI levelUI6 = null;
            LevelUI levelUI7 = null;
            LevelUI levelUI8 = null;
            LevelUI levelUI9 = null;
            LevelUI levelUI10 = null;
            LevelUI levelUId = null;

            switch (index)
            {
                case 1:
                    myGame.gameStarted = true;
                    AddChild(new Level1());
                    levelUI1 = new LevelUI(0, 0);
                    AddChild(levelUI1);
                    _levelUI.Add(levelUI1);
                    myGame.mainMusicPlaying = false;
                    break;
                case 2:
                    AddChild(new Level2());
                    levelUI2 = new LevelUI(0, 0);
                    AddChild(levelUI2);
                    _levelUI.Add(levelUI2);
                    break;
                case 3:
                    AddChild(new Level3());
                    levelUI3 = new LevelUI(0, 1);
                    AddChild(levelUI3);
                    _levelUI.Add(levelUI3);
                    break;
                case 4:
                    AddChild(new Level4());
                    levelUI4 = new LevelUI(1, 2);
                    AddChild(levelUI4);
                    _levelUI.Add(levelUI4);
                    break;
                case 5:
                    AddChild(new Level5());
                    levelUI5 = new LevelUI(2, 1);
                    AddChild(levelUI5);
                    _levelUI.Add(levelUI5);
                    break;
                case 6:
                    AddChild(new Level6());
                    levelUI6 = new LevelUI(1, 1);
                    AddChild(levelUI6);
                    _levelUI.Add(levelUI6);
                    break;
                case 7:
                    AddChild(new Level7());
                    levelUI7 = new LevelUI(1, 2);
                    AddChild(levelUI7);
                    _levelUI.Add(levelUI7);
                    break;
                case 8:
                    AddChild(new Level8());
                    levelUI8 = new LevelUI(1, 1);
                    AddChild(levelUI8);
                    _levelUI.Add(levelUI8);
                    break;
                case 9:
                    AddChild(new Level9());
                    levelUI9 = new LevelUI(3, 3);
                    AddChild(levelUI9);
                    _levelUI.Add(levelUI9);
                    break;
                case 10:
                    AddChild(new Level10());
                    levelUI10 = new LevelUI(3, 2);
                    AddChild(levelUI10);
                    _levelUI.Add(levelUI10);
                    break;
                default:
                    myGame.gameStarted = true;
                    AddChild(new Level1());
                    levelUId = new LevelUI(0, 0);
                    AddChild(levelUId);
                    _levelUI.Add(levelUId);
                    myGame.mainMusicPlaying = false;
                    break;
            }

            reloadButton = new Button(myGame.width - 210, 50, "RedoSpriteSheet.png", true, 2, 1);
            AddChild(reloadButton);
            reloadButton.SetScaleXY(0.75f, 0.75f);

            mainMenuButton = new Button(myGame.width - 335, 50, "XStyleSheet.png", true, 2, 1);
            AddChild(mainMenuButton);
            mainMenuButton.SetScaleXY(0.75f, 0.75f);

            nextLevelButton = new Button(myGame.width - 85, 50, "NextLevelSpriteSheet.png", true, 2, 1);
            AddChild(nextLevelButton);
            nextLevelButton.SetScaleXY(0.75f, 0.75f);
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