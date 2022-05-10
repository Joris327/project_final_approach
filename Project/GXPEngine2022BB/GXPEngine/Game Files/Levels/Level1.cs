using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        MyGame myGame = MyGame.current;

        public Level1() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            LateAddChild(new Player(150, 500));
            //LateAddChild(new Enemy(600, 460));
            //LateAddChild(new Enemy(400, 160));
            //LateAddChild(new StaticWall(600, 550, 90));
            //LateAddChild(new StaticWall(400, 250, 90));
            //LateAddChild(new StaticWall(1000, 500));

            LateAddChild(new Enemy(700, 500));
        }
    }
}