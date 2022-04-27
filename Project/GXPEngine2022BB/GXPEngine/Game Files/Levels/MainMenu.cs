using System;
using GXPEngine;


public class MainMenu : Sprite
{
    MyGame myGame = MyGame.current;
    LevelManager levelManager;
    Button startButton;

    public MainMenu(LevelManager plevelMagager) : base("checkers.png")
    {
        levelManager = plevelMagager;

        startButton = new Button(myGame.width/2, myGame.height/2, "square.png");
        LateAddChild(startButton);
    }

    void Update()
    {
        if (startButton.CheckIfPressed() == true)
        {
            levelManager.LoadLevel(1);
        }
    }
}
