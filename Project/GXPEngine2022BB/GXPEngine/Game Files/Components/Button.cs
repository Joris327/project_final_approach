using System;
using GXPEngine;

namespace GXPEngine
{
    public class Button : AnimationSprite
    {
        public Button(float pX, int pY, String buttonSprite) : base(buttonSprite, 1, 1, -1, false, false)
        {
            SetOrigin(width / 2, height / 2);

            x = pX;
            y = pY;
        }

        public bool CheckIfPressed()
        {
            float mouseX = Input.mouseX;
            float mouseY = Input.mouseY;
            float radiusX = width / 2;
            float radiusY = height / 2;

            if (mouseX < x + radiusX && mouseX > x - radiusX &&
                mouseY < y + radiusY && mouseY > y - radiusY &&
                Input.GetMouseButtonDown(0))
            {
                return true;
            }
            else return false;
        }
    }
}