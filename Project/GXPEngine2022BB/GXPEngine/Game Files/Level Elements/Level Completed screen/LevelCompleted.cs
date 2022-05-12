using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class LevelCompleted : Sprite
    {
        readonly MyGame myGame = MyGame.current;
        readonly LevelManager levelManager = LevelManager.current;

        readonly StarAnim star1;
        readonly StarAnim star2;
        readonly StarAnim star3;

        Button redoButton;
        Button nextLevelButton;
        Button mainMenuButton;

        readonly int starsWon;

        public LevelCompleted(int pstarsWon) : base("Level_Completed.png", false, false)
        {
            starsWon = pstarsWon;

            SetOrigin(width / 2, height / 2);
            SetXY(myGame.width / 2, myGame.height / 2);

            star1 = new StarAnim(309-x, 188-y);
            star2 = new StarAnim(509-x, 62-y);
            star3 = new StarAnim(707-x, 189-y);

            SetupButtons();

            if (starsWon >= 1)
            {
                AddChild(star1);
                star1.animate = true;
            }
            if (starsWon >= 2)
            {
                AddChild(star2);
                star2.visible = false;
            }
            if (starsWon >= 3)
            {
                AddChild(star3);
                star3.visible = false;
            }
        }

        void SetupButtons()
        {
            //redoButton = new Button(myGame.width/2, myGame.height/2+200, "RedoSpriteSheet.png", true, 2, 1);
            //nextLevelButton = new Button(myGame.width/2+150, myGame.height / 2 + 200, "NextLevelSpriteSheet.png", true, 2, 1);
            //mainMenuButton = new Button(myGame.width/2-150, myGame.height / 2 + 200, "XStyleSheet.png", true, 2, 1);

            redoButton = new Button(0, 200, "RedoSpriteSheet.png", true, 2, 1);
            nextLevelButton = new Button(150, 200, "NextLevelSpriteSheet.png", true, 2, 1);
            mainMenuButton = new Button(-150, 200, "XStyleSheet.png", true, 2, 1);

            AddChild(redoButton);
            AddChild(nextLevelButton);
            AddChild(mainMenuButton);
        }

        void Update()
        {
            AnimateStars();

            UpdateButtons();
        }

        void UpdateButtons()
        {

            if (redoButton.CheckIfHovered() == true) redoButton.SetCycle(1);
            else redoButton.SetCycle(0);

            if (nextLevelButton.CheckIfHovered() == true) nextLevelButton.SetCycle(1);
            else nextLevelButton.SetCycle(0);

            if (mainMenuButton.CheckIfHovered() == true) mainMenuButton.SetCycle(1);
            else mainMenuButton.SetCycle(0);
            
            if (mainMenuButton.CheckIfPressed() == true)
            {
                myGame.gameStarted = false;
                levelManager.LoadMainMenu();
            }
            else if (redoButton.CheckIfPressed() == true) levelManager.LoadLevel(levelManager.currentLevel);

            if (nextLevelButton.CheckIfPressed() == true)
            {
                if (levelManager.currentLevel < 10) levelManager.LoadLevel(levelManager.currentLevel + 1);
                else levelManager.LoadMainMenu();
            }
        }

        void AnimateStars()
        {
            if (starsWon >= 2 && star1.currentFrame == 19)
            {
                star2.animate = true;
                star2.visible = true;
            }

            if (starsWon >= 3 && star2.currentFrame == 19)
            {
                star3.animate = true;
                star3.visible = true;
            }
        }
    }
}