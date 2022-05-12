using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level1() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            LateAddChild(new Player(150, 500));

            LateAddChild(new Enemy(700, 500));
            LateAddChild(new Platform(705, 575));

            LateAddChild(new Crate(500, 300));
        }
    }
}