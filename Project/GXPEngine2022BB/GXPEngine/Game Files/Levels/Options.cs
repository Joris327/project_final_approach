using System;
using GXPEngine;

namespace GXPEngine
{
    public class Options : Sprite
    {
        MyGame myGame = MyGame.current;
        LevelManager levelManager = LevelManager.current;
        Button returnButton;

        public Options() : base("colors.png", false, false)
        {
            returnButton = new Button(myGame.width / 2, myGame.height / 2, "square.png");
            LateAddChild(returnButton);

        }

        void Update()
        {
            if(returnButton.CheckIfPressed() == true)
            {
                levelManager.LoadMainMenu();
            }
        }
    }
}