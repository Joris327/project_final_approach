

namespace GXPEngine
{
    public class Aimline : Sprite
    {
        readonly LevelManager levelManager = LevelManager.current;

        public Aimline(float pX, float pY) : base("Aim_Line.png")
        {
            SetScaleXY(1.5f, 1.5f);
            SetOrigin(-200, height / 3);
            SetXY(pX, pY);
        }

        void Update()
        {
            if (levelManager.levelComplete == false) TurnTowardsMouse();
        }

        void TurnTowardsMouse()
        {
            Vec2 _relative_Mouse_Position = Vec2.GetMousePosition() - new Vec2(parent.x, parent.y);
            rotation = _relative_Mouse_Position.GetAngleDeg() - parent.rotation;
        }
    }
}