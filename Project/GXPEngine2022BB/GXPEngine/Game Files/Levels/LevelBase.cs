using System;
using GXPEngine;

namespace GXPEngine
{
    public class LevelBase : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        //this class in intended to function as a blueprint to make the other levels off of.
        //it should never be invoked.

        public LevelBase() : base("BQK.png", false, false)
        {
            myGame.LeftXBoundary = -64;
            myGame.RightXBoundary = width + 64;
            myGame.TopYBoundary = -64;
            myGame.BottomYBoundary = height + 64;
        }
    }
}