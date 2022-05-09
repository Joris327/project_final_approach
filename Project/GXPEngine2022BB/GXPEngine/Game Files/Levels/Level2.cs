using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level2 : Sprite
    {
        public Level2() : base("colors.png", false, false)
        {
            LateAddChild(new Player(200, 200));
            LateAddChild(new Enemy(400, 400));
            LateAddChild(new StaticWall(250, 400));
            LateAddChild(new StaticWall(550, 400));
        }
    }
}
