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
        Button trailButton;
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
                soundButton = new Button(808, 200, "sound_on.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            }
            else if (myGame.soundOn == false)
            {
                soundButton = new Button(808, 200, "sound_off.png");
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

            if (myGame.trailOn == true)
            {
                trailButton = new Button(808, 305, "trail_on.png");
                trailButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(trailButton);
            }
            else if (myGame.trailOn == false)
            {
                trailButton = new Button(808, 305, "trail_off.png");
                trailButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(trailButton);


            }
        }

            void Update()
        {


            DrawButtons();

            if (returnButton.CheckIfPressed() == true)
            {
                levelManager.LoadMainMenu();
            }

            Boolean rButtonHovered = returnButton.CheckIfHovered();

            if(rButtonHovered == true)
            {
                returnButton.Remove();
                returnButton = new Button(1200, 650, "x_hover.png");
                LateAddChild(returnButton);
            } else
            {
                returnButton.Remove();
                returnButton = new Button(1200, 650, "return.png");
                LateAddChild(returnButton);
            }

            


        }

        void DrawButtons()
        {

            Boolean sButtonPressed = soundButton.CheckIfPressed();
            Boolean mButtonPressed = musicButton.CheckIfPressed();
            Boolean tButtonPressed = trailButton.CheckIfPressed();

            Boolean sButtonHovered = soundButton.CheckIfHovered();
            Boolean mButtonHovered = musicButton.CheckIfHovered();
            Boolean tButtonHovered = trailButton.CheckIfHovered();

            /// SOUND BUTTON
            // TURN OFF
            if (sButtonPressed && myGame.soundOn == true)
            {
                soundButton.Remove();
                soundButton = new Button(808, 225, "sound_off.png");
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
                soundButton = new Button(808, 225, "sound_on.png");
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
                soundButton = new Button(808, 225, "sound_hover.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            } else
            {
                if(myGame.soundOn == true)
                {
                    soundButton.Remove();
                    soundButton = new Button(808, 225, "sound_on.png");
                    soundButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(soundButton);
                } else
                {
                    soundButton.Remove();
                    soundButton = new Button(808, 225, "sound_off.png");
                    soundButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(soundButton);
                }
            }

            if (sButtonHovered && myGame.soundOn != true)
            {
                soundButton.Remove();
                soundButton = new Button(808, 225, "sound_off_hover.png");
                soundButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(soundButton);
            }


                /////////////////////////////////////////////////////////////////////////////////////////////////////


                /// MUSIC BUTTON
                // TURN OFF
                if (mButtonPressed && myGame.musicOn == true)
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
            if (mButtonPressed == true && myGame.musicOn == false)
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

            if (mButtonHovered && myGame.musicOn == true)
            {
                musicButton.Remove();
                musicButton = new Button(808, 165, "music_hover.png");
                musicButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(musicButton);
            }
            else
            {
                if (myGame.musicOn == true)
                {
                    musicButton.Remove();
                    musicButton = new Button(808, 165, "music_on.png");
                    musicButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(musicButton);
                }
                else
                {
                    musicButton.Remove();
                    musicButton = new Button(808, 165, "music_off.png");
                    musicButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(musicButton);
                }
            }

            if (mButtonHovered && myGame.musicOn != true)
            {
                musicButton.Remove();
                musicButton = new Button(808, 165, "music_off_hover.png");
                musicButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(musicButton);
            }

            /// TRAIL BUTTON
            // TURN OFF
            if (tButtonPressed && myGame.trailOn == true)
            {
                trailButton.Remove();
                trailButton = new Button(808, 285, "trail_off.png");
                trailButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(trailButton);
                myGame.trailOn = false;
                tButtonPressed = false;
                Console.WriteLine("Trail on = " + myGame.trailOn);
                //System.Threading.Thread.Sleep(1000);
            }

            // TURN ON
            if (tButtonPressed == true && myGame.trailOn == false)
            {

                trailButton.Remove();
                trailButton = new Button(808, 285, "trail_on.png");
                trailButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(trailButton);
                myGame.trailOn = true;
                tButtonPressed = false;
                Console.WriteLine("Trail on = " + myGame.trailOn);
                //System.Threading.Thread.Sleep(1000);
            }

            if (tButtonHovered && myGame.trailOn == true)
            {
                trailButton.Remove();
                trailButton = new Button(808, 285, "trail_hover.png");
                trailButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(trailButton);
            }
            else
            {
                if (myGame.trailOn == true)
                {
                    trailButton.Remove();
                    trailButton = new Button(808, 285, "trail_on.png");
                    trailButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(trailButton);
                }
                else
                {
                    trailButton.Remove();
                    trailButton = new Button(808, 285, "trail_off.png");
                    trailButton.SetScaleXY(buttonScale, buttonScale);
                    LateAddChild(trailButton);
                }
            }

            if (tButtonHovered && myGame.trailOn != true)
            {
                trailButton.Remove();
                trailButton = new Button(808, 285, "trail_off_hover.png");
                trailButton.SetScaleXY(buttonScale, buttonScale);
                LateAddChild(trailButton);
            }







        }
    }
}