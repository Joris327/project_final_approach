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
        }

        void Update()
        {
            
        }
    }
}