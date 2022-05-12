using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level2 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level2() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            LateAddChild(new Player(200, 600));

            LateAddChild(new Enemy(600, 200));
            LateAddChild(new Platform(605, 275));

            LateAddChild(new Enemy(600, 450));
            LateAddChild(new Platform(605, 525));

            LateAddChild(new StaticWall(950, 300));
            //LateAddChild(new StaticWall(150, 600));
        }
    }
}
