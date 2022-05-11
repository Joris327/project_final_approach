using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level8 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level8() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            AddChild(new Player(100, 600));

            AddChild(new Enemy(400, 350));
            AddChild(new Platform(405, 425));

            AddChild(new Enemy(800, 550));
            AddChild(new Platform(805, 625));

            AddChild(new Enemy(1100, 400));
            AddChild(new Platform(1105, 475));
        }
    }
}