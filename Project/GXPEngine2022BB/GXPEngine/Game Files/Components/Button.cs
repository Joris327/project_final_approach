using System;
using GXPEngine;

namespace GXPEngine
{
    public class Button : AnimationSprite
    {
        public Button(float pX, float pY, String buttonSprite, bool pVisible=true) : base(buttonSprite, 1, 1, -1, false, false)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            visible = pVisible;
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