using System;
using GXPEngine;


public class Story : Sprite
{
    MyGame myGame = MyGame.current;
    LevelManager levelManager = LevelManager.current;
    Button returnButton;

    public Story() : base("BQK.png")
    {
        Sprite story = new Sprite("story.png");
        LateAddChild(story);

        returnButton = new Button(1150, 650, "return.png");
    }

    void Update()
    {
        Boolean rButtonHovered = returnButton.CheckIfHovered();

        if (rButtonHovered == true)
        {
            returnButton.Remove();
            returnButton = new Button(1200, 650, "x_hover.png");
            LateAddChild(returnButton);
        }
        else
        {
            returnButton.Remove();
            returnButton = new Button(1200, 650, "return.png");
            LateAddChild(returnButton);
        }

        if (returnButton.CheckIfPressed() == true)
        {
            levelManager.LoadMainMenu();
        }







    }
}
