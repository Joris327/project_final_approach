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
        float buttonScale = 0.55f;
        

        public Controls() : base("BQK.png", false, false)
        {
            Console.WriteLine("Sound on = " + myGame.soundOn);
            Console.WriteLine("Music on = " + myGame.musicOn);
            returnButton = new Button(1150, 650, "return.png");
            Sprite controls_settings = new Sprite("settings_menu.png");
            LateAddChild(controls_settings);
            
            
            LateAddChild(returnButton);

            if (myGame.soundOn == true)
            {
                soundButton = new Button(808, 235, "sound_on.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            }
            else if (myGame.soundOn == false)
            {
                soundButton = new Button(808, 235, "sound_off.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            }

            if (myGame.musicOn == true)
            {
                musicButton = new Button(808, 165, "music_on.png");
                musicButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(musicButton);
            }
            else if (myGame.musicOn == false)
            {
                musicButton = new Button(808, 165, "music_off.png");
                musicButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(musicButton);
            }


        }

        void Update()
        {


            DrawButtons();

            if (returnButton.CheckIfPressed() == true)
            {
                levelManager.LoadMainMenu();
            }

            


        }

        void DrawButtons()
        {

            Boolean sButtonPressed = soundButton.CheckIfPressed();
            Boolean mButtonPressed = musicButton.CheckIfPressed();

            Boolean sButtonHovered = soundButton.CheckIfHovered();
            Boolean mButtonHovered = musicButton.CheckIfHovered();

            /// SOUND BUTTON
            // TURN OFF
            if (sButtonPressed && myGame.soundOn == true)
            {
                soundButton.Remove();
                soundButton = new Button(808, 235, "sound_off.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
                myGame.soundOn = false;
                sButtonPressed = false;
                Console.WriteLine("Sound on = " + myGame.soundOn);
                //System.Threading.Thread.Sleep(1000);
            }

            // TURN ON
            if (sButtonPressed == true && myGame.soundOn == false)
            {

                soundButton.Remove();
                soundButton = new Button(808, 235, "sound_on.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
                myGame.soundOn = true;
                sButtonPressed = false;
                Console.WriteLine("Sound on = " + myGame.soundOn);
                //System.Threading.Thread.Sleep(1000);
            }

            if(sButtonHovered && myGame.soundOn == true)
            {
                soundButton.Remove();
                soundButton = new Button(808, 235, "sound_hover.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            } else
            {
                if(myGame.soundOn == true)
                {
                    soundButton.Remove();
                    soundButton = new Button(808, 235, "sound_on.png");
                    soundButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(soundButton);
                } else
                {
                    soundButton.Remove();
                    soundButton = new Button(808, 235, "sound_off.png");
                    soundButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(soundButton);
                }
            }

            if (sButtonHovered && myGame.soundOn != true)
            {
                soundButton.Remove();
                soundButton = new Button(808, 235, "sound_off_hover.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            }


                /////////////////////////////////////////////////////////////////////////////////////////////////////


                /// MUSIC BUTTON
                // TURN OFF
                if (mButtonPressed && musicButton.bSprite == "music_on.png")
            {
                musicButton.Remove();
                musicButton = new Button(808, 165, "music_off.png");
                musicButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(musicButton);
                myGame.musicOn = false;
                mButtonPressed = false;
                Console.WriteLine("Music on = " + myGame.musicOn);
                //System.Threading.Thread.Sleep(1000);
            }

            // TURN ON
            if (mButtonPressed == true && musicButton.bSprite == "music_off.png")
            {

                musicButton.Remove();
                musicButton = new Button(808, 165, "music_on.png");
                musicButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(musicButton);
                myGame.musicOn = true;
                mButtonPressed = false;
                Console.WriteLine("Music on = " + myGame.musicOn);
                //System.Threading.Thread.Sleep(1000);
            }
        }
    }
}