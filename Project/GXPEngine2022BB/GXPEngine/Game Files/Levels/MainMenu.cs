using System;
using GXPEngine;


public class MainMenu : Sprite
{
    MyGame myGame = MyGame.current;
    LevelManager levelManager = LevelManager.current;
    Button startButton;
    Button controlsButton;
    Button storyButton;
    Button exitButton;

    public MainMenu() : base("main_menu.png")
    {
        startButton = new Button(myGame.width / 2 + 30, myGame.height / 2 - 20, "square.png");
        controlsButton = new Button(myGame.width / 2 - 60, myGame.height / 2 + 125, "square.png");
        storyButton = new Button(myGame.width / 2 + 500, myGame.height / 2 + 30, "square.png");
        exitButton = new Button(myGame.width / 2 - 60, myGame.height / 2 + 290, "square.png");

        startButton.height = 135;
        startButton.width = 380;
        startButton.alpha = 0;

        controlsButton.width = 400;
        controlsButton.height = 100;
        controlsButton.alpha = 20;
        controlsButton.alpha = 0;

        exitButton.width = 350;
        exitButton.height = 190;
        exitButton.alpha = 0;


        storyButton.width = 175;
        storyButton.height = 110;
        storyButton.alpha = 0;

        LateAddChild(controlsButton);
        LateAddChild(exitButton);
        LateAddChild(storyButton);
        LateAddChild(startButton);
    }

    void Update()
    {
        if (startButton.CheckIfPressed() == true)
        {
            levelManager.LoadLevel(1);
        }

        if (exitButton.CheckIfPressed() == true)
        {
            myGame.Destroy();
        }

        if (controlsButton.CheckIfPressed() == true)
        {
            levelManager.LoadControls();
            if (myGame.musicOn == false)
            {
                //music.Stop();
            }
        }

        if (storyButton.CheckIfPressed() == true)
        {
            levelManager.LoadStory();
        }
    }
}
