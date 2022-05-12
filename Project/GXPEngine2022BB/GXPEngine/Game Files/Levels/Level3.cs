using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level3 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level3() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            LateAddChild(new Player(200, 600));

            LateAddChild(new Enemy(635, 200));
            LateAddChild(new Platform(640, 275));

            LateAddChild(new Enemy(950, 450));
            LateAddChild(new Platform(955, 525));

            LateAddChild(new StaticWall(640, 500, new Vec2(1,1)));
            //LateAddChild(new StaticWall(150, 600));
        }
    }
}