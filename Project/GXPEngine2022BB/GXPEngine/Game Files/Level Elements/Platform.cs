using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Platform : Sprite
    {
        readonly MyGame myGame = MyGame.current;

        public Platform(float pX, float pY) : base("platform10.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY(pX, pY);

            AddRigidbody();
        }

        void AddRigidbody()
        {
            Block block1 = new Block(7, new Vec2(x - 43, y - height/4), new Vec2(), false, false, 9999999);
            Block block2 = new Block(10, new Vec2(x - 25, y - height/4+3), new Vec2(), false, false, 9999999);
            Block block3 = new Block(13, new Vec2(x, y), new Vec2(), false, false, 9999999);
            Block block4 = new Block(10, new Vec2(x + 25, y - height / 4+3), new Vec2(), false, false, 9999999);
            Block block5 = new Block(7, new Vec2(x + 43, y - height / 4), new Vec2(), false, false, 9999999);

            myGame.LateAddChild(block1);
            myGame.LateAddChild(block2);
            myGame.LateAddChild(block3);
            myGame.LateAddChild(block4);
            myGame.LateAddChild(block5);

            myGame._movers.Add(block1);
            myGame._movers.Add(block2);
            myGame._movers.Add(block3);
            myGame._movers.Add(block4);
            myGame._movers.Add(block5);

        }
    }
}
