using System;

namespace GXPEngine
{
    public class AimLine : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        Sound gunshot = new Sound("gunshot without the gun noises.mp3");
        int shotDelaySetup = 10;
        int shotDelay;
        bool hasShot = false;

        public AimLine(float pX, float pY) : base("mcharacter2.png", false)
        {
            SetOrigin(0, height/2);
            SetXY(pX, pY);

            shotDelay = shotDelaySetup;
        }

        void Update()
        {
            TurnTowardsMouse();

            if (Input.GetKeyDown(Key.SPACE) && levelManager.ammo > 0)
            {
                Shoot();
            }
        }

        void TurnTowardsMouse()
        {
            Vec2 _relative_Mouse_Position = Vec2.GetMousePosition() - new Vec2(parent.x, parent.y);
            rotation = _relative_Mouse_Position.GetAngleDeg() - parent.rotation;
        }

        void Shoot()
        {
            Vec2 position = new Vec2(x + parent.x , y + parent.y);
            Vec2 nozzle_Pos = new Vec2(position.x + 113, position.y);
            nozzle_Pos.RotateAroundVecDeg(position, rotation + parent.rotation);

            Vec2 velocity = new Vec2(10, 0);
            velocity.SetAngleDeg(rotation + parent.rotation);

            //levelManager.LateAddChild(new Bullet(nozzle_Pos.x, nozzle_Pos.y, rotation + parent.rotation, velocity));
            Block bulletObject = new Block(5, nozzle_Pos, velocity, true, false);
        
            myGame._movers.Add(bulletObject);
            levelManager.AddChild(bulletObject);

            Bullet bulletSprite = new Bullet(rotation, bulletObject);
            bulletObject.AddChild(bulletSprite);

            gunshot.Play(false);
            levelManager.ammo--;
        }
    }
}