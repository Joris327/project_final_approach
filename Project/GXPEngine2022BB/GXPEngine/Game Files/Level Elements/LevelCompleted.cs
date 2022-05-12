using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class LevelCompleted : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        Sound end;


        public LevelCompleted() : base("Level_Completed.png", false, false)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(myGame.width / 2, myGame.height / 2);
            
        }

        void Update()
        {
            if (!myGame.endPlaying)
            {
                end = new Sound("end.mp3", false);
                end.Play();
                myGame.endPlaying = true;
            }
        }
    }
}
