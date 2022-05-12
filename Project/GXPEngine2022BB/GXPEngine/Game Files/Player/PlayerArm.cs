using System;
using System.Drawing;

namespace GXPEngine
{
    public class PlayerArm : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        Sound gunshot = new Sound("gunshot without the gun noises.mp3");

        public PlayerArm(float pX, float pY) : base("mcharacter2.png", false)
        {
            SetOrigin(0, height/2);
            SetXY(pX, pY);
        }

        void Update()
        {
            if (levelManager.levelComplete == false) TurnTowardsMouse();

            LevelUI levelUI = null;

            foreach(LevelUI levelui in levelManager._levelUI)
            {
                levelUI = levelui;
            }

            if (Input.GetKeyDown(Key.SPACE) && levelManager.ammo > 0 && levelManager.levelComplete == false)
            {
                if (levelUI == null) Shoot();
                else if (levelUI != null)
                {
                    if (levelUI.holdingObject == false) Shoot();
                }
            }

            if (Input.GetMouseButtonDown(2) && levelManager.ammo > 0 && levelManager.levelComplete == false && levelManager.holding == false)
            {
                if (levelUI == null) Shoot();
                else if (levelUI != null)
                {
                    if (levelUI.holdingObject == false) Shoot();
                }
            }
        }

        void TurnTowardsMouse()
        {
            Vec2 _relative_Mouse_Position = Vec2.GetMousePosition() - new Vec2(parent.x, parent.y);
            rotation = _relative_Mouse_Position.GetAngleDeg() - parent.rotation;
        }

        void Shoot()
        {
            levelManager._lineContainer.graphics.Clear(Color.Empty);

            Vec2 position = new Vec2(x + parent.x , y + parent.y);
            Vec2 nozzle_Pos = new Vec2(position.x + 113, position.y);
            nozzle_Pos.RotateAroundVecDeg(position, rotation + parent.rotation);

            Vec2 velocity = new Vec2(10, 0);
            velocity.SetAngleDeg(rotation + parent.rotation);

            Block bulletObject = new Block(5, nozzle_Pos, velocity, true, false);
        
            myGame._movers.Add(bulletObject);
            levelManager.AddChild(bulletObject);
            bulletObject.isBullet = true;

            Bullet bulletSprite = new Bullet(rotation, bulletObject);
            bulletObject.AddChild(bulletSprite);

            if (myGame.soundOn) gunshot.Play(false);
            levelManager.ammo--;
        }
    }
}