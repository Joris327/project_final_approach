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
        

        public Controls() : base("controls_background.png", false, false)
        {
            Console.WriteLine("Sound on = " + myGame.soundOn);
            returnButton = new Button(1150, 650, "square.png");
            
            musicButton = new Button(808, 610, "colors.png");
            LateAddChild(musicButton);
            LateAddChild(returnButton);

            if (myGame.soundOn == true)
            {
                soundButton = new Button(808, 531, "colors.png");
                LateAddChild(soundButton);
            }
            else if (myGame.soundOn == false)
            {
                soundButton = new Button(808, 531, "checkers.png");
                LateAddChild(soundButton);
            }


        }

        void Update()
        {

            Boolean sButtonPressed = soundButton.CheckIfPressed();

            if (returnButton.CheckIfPressed() == true)
            {
                levelManager.LoadMainMenu();
            }

            if (sButtonPressed && soundButton.bSprite == "colors.png")
            {
                soundButton.Remove();
                soundButton = new Button(808, 531, "checkers.png");
                LateAddChild(soundButton);
                myGame.soundOn = false;
                sButtonPressed = false;
                Console.WriteLine("Sound on = " + myGame.soundOn);
                //System.Threading.Thread.Sleep(1000);
            }

            if (sButtonPressed == true && soundButton.bSprite == "checkers.png")
            {
                
                soundButton.Remove();
                soundButton = new Button(808, 531, "colors.png");
                LateAddChild(soundButton);
                myGame.soundOn = true;
                sButtonPressed = false;
                Console.WriteLine("Sound on = " + myGame.soundOn);
                //System.Threading.Thread.Sleep(1000);
            }

            
        }
    }
}