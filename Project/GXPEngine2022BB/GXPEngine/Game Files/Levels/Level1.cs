using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        public Level1() : base("colors.png", false, false)
        {
            LateAddChild(new Player(200, 600));
        }
    }
}