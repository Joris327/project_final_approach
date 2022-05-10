using System;
using GXPEngine;

namespace GXPEngine
{
    public class Controls : Sprite
    {
        MyGame myGame = MyGame.current;
        LevelManager levelManager = LevelManager.current;
        Button returnButton;
        Button soundButton;
        Button musicButton;
        public Boolean soundOn;
        public Boolean musicOn;

        public Controls() : base("controls_background.png", false, false)
        {
            returnButton = new Button(1150, 650, "square.png");
            soundButton = new Button(808, 531, "colors.png");
            LateAddChild(soundButton);
            musicButton = new Button(808, 610, "colors.png");
            LateAddChild(musicButton);
            LateAddChild(returnButton);


        }

        void Update()
        {

            if (returnButton.CheckIfPressed() == true)
            {
                levelManager.LoadMainMenu();
            }

            if (soundButton.CheckIfPressed() == true)
            {
                if (soundButton.bSprite == "colors.png")
                {
                    soundButton.Remove();
                    soundButton = new Button(808, 531, "checkers.png");
                    LateAddChild(soundButton);
                    soundOn = false;
                    Console.WriteLine(soundButton.CheckIfPressed());
                }

                //if (soundButton.bSprite == "checkers.png")
                //{
                //    Console.WriteLine(soundButton.CheckIfPressed());
                //    soundButton.Remove();
                //    soundButton = new Button(808, 531, "colors.png");
                //    LateAddChild(soundButton);
                //    soundOn = true;
                //}
            }
        }
    }
}