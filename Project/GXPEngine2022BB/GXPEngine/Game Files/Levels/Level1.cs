using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        MyGame myGame = MyGame.current;
        LevelManager levelManager = LevelManager.current;

        Button nextLevelButton;

        public Level1() : base("colors.png", false, false)
        {
            nextLevelButton = new Button(myGame.width - 160, 32, "square.png");
            LateAddChild(nextLevelButton);

            LateAddChild(new Player(200, 600));
            LateAddChild(new Enemy(600, 489));
            LateAddChild(new Enemy(400, 189));
            LateAddChild(new StaticWall(600, 550, 90));
            LateAddChild(new StaticWall(400, 250, 90));
            LateAddChild(new StaticWall(1000, 500));
        }

        void Update()
        {
            if (nextLevelButton.CheckIfPressed() == true)
            {
                levelManager.LoadLevel(2);
            }
        }
    }
}