using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level9 : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        public Level9() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;

            AddChild(new Player(100, 600));

            AddChild(new Enemy(485, 200));
            AddChild(new Crate(400, 224));
            AddChild(new Platform(385, 275));
            AddChild(new Platform(495, 275));

            AddChild(new Enemy(400, 550));
            AddChild(new Crate(485, 574));
            AddChild(new Platform(385, 625));
            AddChild(new Platform(495, 625));

            //AddChild(new Enemy(1000, 200));
            //AddChild(new Crate(1085, 224));
            //AddChild(new Platform(985, 275));
            //AddChild(new Platform(1095, 275));

            AddChild(new Enemy(1000, 550));
            AddChild(new Crate(1085, 574));
            AddChild(new Platform(985, 625));
            AddChild(new Platform(1095, 625));
        }
    }
}