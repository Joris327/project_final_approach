using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level4 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level4() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            LateAddChild(new Player(200, 600));

            LateAddChild(new Enemy(450, 350));
            LateAddChild(new Platform(455, 425));

            LateAddChild(new Enemy(1050, 350));
            LateAddChild(new Platform(1055, 425));

            //LateAddChild(new StaticWall(650, 500));
            //LateAddChild(new StaticWall(150, 600));
        }
    }
}
