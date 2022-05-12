using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level10 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level10() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            AddChild(new Player(100, 600));

            AddChild(new Enemy(400, 200));
            AddChild(new Crate(485, 224));
            AddChild(new Platform(385, 275));
            AddChild(new Platform(495, 275));

            AddChild(new Enemy(400, 550));
            AddChild(new Platform(405, 625));

            AddChild(new Enemy(800, 200));
            AddChild(new Platform(805, 275));

            AddChild(new Enemy(885, 550));
            AddChild(new Platform(895, 625));

            AddChild(new Enemy(1100, 400));
            AddChild(new Crate(1015, 424));
            AddChild(new Platform(1005, 475));
            AddChild(new Platform(1110, 475));
        }
    }
}