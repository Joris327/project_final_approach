using System;

namespace GXPEngine
{
    public class Bullet : Sprite
    {
        MyGame myGame = MyGame.current;

        Vec2 velocity;

        public Bullet(float pX, float pY, float pRotation, Vec2 pVelocity) : base("triangle.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            SetScaleXY(0.1f, 0.1f);
            rotation = pRotation;
            velocity = pVelocity;
            //velocity.SetAngleDeg(rotation - 90);
        }

        void Update()
        {
            if (x > myGame.width + width || // if (offscreen)
                x < 0 - width ||
                y > myGame.height + height ||
                y < 0 - height)
            {
                LateDestroy();
            }

            x += velocity.x;
            y += velocity.y;
        }
    }
}