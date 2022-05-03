using System;
using GXPEngine;

namespace GXPEngine
{
    public class LevelBase : Sprite
    {
        //this class in intended to function as a blueprint to make the other levels off of.
        //it should never be invoked.

        public LevelBase() : base("colors.png", false, false)
        {
            LateAddChild(new Player(200, 200));
        }
    }
}