using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        MyGame myGame = MyGame.current;

        LevelManager levelManager;

        readonly Player player;

        public Level1(LevelManager pLevelManager) : base("colors.png", false, false)
        {
            levelManager = pLevelManager;

            player = new Player(200, 600);
            LateAddChild(player);
        }

        void Update()
        {
            
        }
    }
}