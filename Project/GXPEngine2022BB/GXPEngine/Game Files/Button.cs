using System;
using GXPEngine;

namespace GXPEngine
{
    public class Button : AnimationSprite
    {
        public String bSprite;

        public Button(float pX, float pY, String buttonSprite, bool pVisible= true, int xrow=1, int yrow=1) : base(buttonSprite, xrow, yrow, -1, false, false)
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
            float parentX = 0;
            float parentY = 0;

            if (parent != null)
            {
                parentX = parent.x;
                parentY = parent.y;
            }

            if (mouseX < x + radiusX + parentX && mouseX > x - radiusX + parentX &&
                mouseY < y + radiusY + parentY && mouseY > y - radiusY + parentY &&
                Input.GetMouseButtonDown(0))
            {
                return true;
            }
            else return false;
        }

        public bool CheckIfHovered()
        {
            float mouseX = Input.mouseX;
            float mouseY = Input.mouseY;
            float radiusX = width / 2;
            float radiusY = height / 2;
            float parentX = 0;
            float parentY = 0;

            if (parent != null)
            {
                parentX = parent.x;
                parentY = parent.y;
            }

            if (mouseX < x + radiusX + parentX && mouseX > x - radiusX + parentX &&
                mouseY < y + radiusY + parentY && mouseY > y - radiusY + parentY)
            {
                return true;
            }
            else return false;
        }
    }
}