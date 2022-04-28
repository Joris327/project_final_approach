using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        MyGame myGame = MyGame.current;

        LevelManager levelManager;

        public Level1(LevelManager pLevelManager) : base("colors.png", false, false)
        {
            levelManager = pLevelManager;
            LateAddChild(new Player(200, 600, levelManager));

            myGame.LeftXBoundary = 64;
            myGame.RightXBoundary = myGame.width - 64;
            myGame.TopYBoundary = 64;
            myGame.BottomYBoundary = myGame.height - 64;
        }

        void Update()
        {
            
        }
    }
}