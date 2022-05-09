using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class StaticWall : Sprite
    {
        readonly MyGame myGame = MyGame.current;

        public StaticWall(float pX, float pY, int protation=0) : base("WallTexture.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);
            rotation = protation;
            AddRigidbody();
        }

        void AddRigidbody()
        {
            Block block1 = new Block(37.5f, new Vec2(x+1, y - 38), new Vec2(), true, false, 999);
            Block block2 = new Block(37.5f, new Vec2(x+1, y + 39), new Vec2(), true, false, 999);

            if (rotation == 90)
            {
                block1._position = new Vec2(x - 38, y+1);
                block2._position = new Vec2(x + 39, y+1);
            }

            myGame.LateAddChild(block1);
            myGame.LateAddChild(block2);

            myGame._movers.Add(block1);
            myGame._movers.Add(block2);
        }
    }
}
