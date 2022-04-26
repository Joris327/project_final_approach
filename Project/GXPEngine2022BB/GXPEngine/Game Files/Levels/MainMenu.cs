using System;
using GXPEngine;


public class MainMenu : Sprite
{
    LevelManager levelManager;
    Button startButton = new Button(400, 300, "square.png");

    public MainMenu(LevelManager plevelMagager) : base("checkers.png")
    {
        levelManager = plevelMagager;

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
