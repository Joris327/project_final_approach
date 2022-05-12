using System;
using GXPEngine;


public class MainMenu : Sprite
{
    MyGame myGame = MyGame.current;
    LevelManager levelManager = LevelManager.current;
    Button startButton;
    Button optionsButton;
    Button controlsButton;
    Button storyButton;
    Button exitButton;

    public MainMenu() : base("checkers.png")
    {
        startButton = new Button(myGame.width/2, myGame.height/2, "square.png");
        controlsButton = new Button(myGame.width / 2, myGame.height / 2 + 64, "square.png");
        storyButton = new Button(myGame.width / 2, myGame.height / 2 + 128, "square.png");
        exitButton = new Button(myGame.width / 2, myGame.height / 2 + 192, "square.png");

        LateAddChild(controlsButton);
        LateAddChild(exitButton);
        LateAddChild(startButton);
        LateAddChild(storyButton);
      
        



    }

    void Update()
    {

      

        if (startButton.CheckIfPressed() == true)
        {
            //music.Stop();
            levelManager.LoadLevel(1);
            
        }

        if(storyButton.CheckIfPressed() == true)
        {
            levelManager.LoadStory();
        }

        if(exitButton.CheckIfPressed() == true)
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

        


    }
}
