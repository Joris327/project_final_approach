using System;
using GXPEngine;

namespace GXPEngine
{
    public class Player : Sprite
    {
        public Player(float pX, float pY) : base("character_circulair_shoulder_2.png")
        {
            SetOrigin(width / 2 - 90, height / 2 - 60);
            SetXY(pX, pY);
            SetScaleXY(0.4f, 0.4f);
            LateAddChild(new PlayerArm(0, 0));
            LateAddChild(new Aimline(0, 0));
        }
    }
}