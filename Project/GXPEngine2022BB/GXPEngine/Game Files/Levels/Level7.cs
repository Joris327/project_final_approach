using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level7 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level7() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            AddChild(new Player(100, 600));

            AddChild(new Enemy(150, 250));
            AddChild(new Platform(155, 325));

            AddChild(new Enemy(1100, 250));
            AddChild(new Platform(1105, 325));
        }
    }
}