using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level5 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level5() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            AddChild(new Player(100, 600));

            AddChild(new Enemy(400, 300));
            AddChild(new Platform(405, 375));

            AddChild(new Enemy(840, 200));
            AddChild(new Platform(845, 275));

            AddChild(new Enemy(840, 500));
            AddChild(new Platform(845, 575));
        }
    }
}
