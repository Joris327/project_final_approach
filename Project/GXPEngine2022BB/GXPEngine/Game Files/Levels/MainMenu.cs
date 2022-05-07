using System;
using GXPEngine;


public class MainMenu : Sprite
{
    MyGame myGame = MyGame.current;
    LevelManager levelManager = LevelManager.current;
    Button startButton;

    public MainMenu() : base("checkers.png")
    {
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
