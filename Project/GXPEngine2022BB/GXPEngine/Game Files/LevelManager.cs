using System;
using GXPEngine;

namespace GXPEngine
{
    public class LevelManager : GameObject
    {
        public LevelManager()
        {
            LoadMainMenu();
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

            switch(number)
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