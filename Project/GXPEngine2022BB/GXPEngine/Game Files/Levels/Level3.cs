using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level3 : Sprite
    {
        MyGame myGame = MyGame.current;

        public Level3() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            LateAddChild(new Player(200, 600));
            LateAddChild(new Enemy(650, 200));
            LateAddChild(new Enemy(950, 450));
            LateAddChild(new StaticWall(650, 500));
            //LateAddChild(new StaticWall(150, 600));
        }
    }
}