using System;
using GXPEngine;

namespace GXPEngine
{
    public class Player : AnimationSprite
    {
        public Player(float pX, float pY) : base("barry.png", 7, 1)
        {
            SetOrigin(width / 2, height / 2);

            x = pX;
            y = pY;
        }
    }
}