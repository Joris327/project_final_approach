using System;
using GXPEngine;

namespace GXPEngine
{
    public class Player : AnimationSprite
    {
        LevelManager levelManager;

        public Player(float pX, float pY, LevelManager pLevelManager) : base("barry.png", 7, 1)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            SetFrame(7);
            levelManager = pLevelManager;
            LateAddChild(new AimLine(0, 0, levelManager));
        }

        void Update()
        {
            
        }
    }
}