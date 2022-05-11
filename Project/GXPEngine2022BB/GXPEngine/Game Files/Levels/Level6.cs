using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level6 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level6() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            AddChild(new Player(100, 600));

            AddChild(new Enemy(640, 200));
            AddChild(new Platform(640, 275));
            AddChild(new Crate(745, 224));
            AddChild(new Platform(745, 275));

            AddChild(new Enemy(680, 450));
            AddChild(new Platform(685, 525));
            AddChild(new Crate(575, 474));
            AddChild(new Platform(575, 525));
        }
    }
}
