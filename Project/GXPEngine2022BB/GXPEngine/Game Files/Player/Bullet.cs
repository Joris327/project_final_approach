using System;

namespace GXPEngine
{
    public class Bullet : Sprite
    {
        readonly MyGame myGame = MyGame.current;

        Vec2 velocity;

        float new_rotation;

        public Bullet(float pRotation) : base("triangle.png")
        {
            SetOrigin(width / 2, height / 2);
            new_rotation = pRotation;
            SetScaleXY(0.5f, 0.5f);
            
            //velocity.SetAngleDeg(rotation - 90);
        }


        void Update()
        {

            rotation = new_rotation;
        }
    }
}