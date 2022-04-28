using System;
using GXPEngine;
using System.Collections.Generic;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        MyGame myGame = MyGame.current;

        Button mainMenuButton;

        public List<Block> _movers;

        public LevelManager() : base()
        {
            LoadMainMenu();
            _movers = new List<Block>();
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

            if(_movers.Count > 0)
            {
                foreach (Block bullet in _movers)
                {
                    bullet.Step();

                    /*
                    if (bullet.x > myGame.width + bullet.width || // if (offscreen)
                        bullet.x < 0 - bullet.width ||
                        bullet.y > myGame.height + bullet.height ||
                        bullet.y < 0 - bullet.height)
                    {
                        _movers.Remove(bullet);
                        bullet.LateDestroy();
                    }
                    */
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
            LateAddChild(new GameUI(this, 2, 2));

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