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
            Console.WriteLine("Music on = " + myGame.musicOn);
            returnButton = new Button(1150, 650, "square.png");
            
            
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

            if (myGame.musicOn == true)
            {
                musicButton = new Button(808, 610, "colors.png");
                LateAddChild(musicButton);
            }
            else if (myGame.musicOn == false)
            {
                musicButton = new Button(808, 610, "checkers.png");
                LateAddChild(musicButton);
            }


        }

        void Update()
        {

            Boolean sButtonPressed = soundButton.CheckIfPressed();
            Boolean mButtonPressed = musicButton.CheckIfPressed();

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

            if (mButtonPressed && musicButton.bSprite == "colors.png")
            {
                musicButton.Remove();
                musicButton = new Button(808, 610, "checkers.png");
                LateAddChild(musicButton);
                myGame.musicOn = false;
                mButtonPressed = false;
                Console.WriteLine("Music on = " + myGame.musicOn);
                //System.Threading.Thread.Sleep(1000);
            }

            if (mButtonPressed == true && musicButton.bSprite == "checkers.png")
            {

                musicButton.Remove();
                musicButton = new Button(808, 610, "colors.png");
                LateAddChild(musicButton);
                myGame.musicOn = true;
                mButtonPressed = false;
                Console.WriteLine("Music on = " + myGame.musicOn);
                //System.Threading.Thread.Sleep(1000);
            }


        }
    }
}