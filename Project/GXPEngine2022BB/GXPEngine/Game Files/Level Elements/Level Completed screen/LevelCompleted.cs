using System.Drawing;

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

        readonly Font cowboyFont = new Font(FontFamily.GenericSerif, 20, FontStyle.Regular);

        readonly Canvas scoreUI = new Canvas(300, 300, false);

        public LevelCompleted(int pstarsWon) : base("Level_Completed.png", false, false)
        {
            starsWon = pstarsWon;

            SetOrigin(width / 2, height / 2);
            SetXY(myGame.width / 2, myGame.height / 2);

            star1 = new StarAnim(304-x, 199-y);
            star2 = new StarAnim(503-x, 74-y);
            star3 = new StarAnim(702-x, 199-y);

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

            if (myGame.musicOn) levelManager.winchannel = levelManager.winmusic.Play();
            if (myGame.channelLevel != null) myGame.channelLevel.IsPaused = true;

            AddChild(scoreUI);
            SetOrigin(width / 2, height / 2);
            scoreUI.SetXY(-90, -100);
        }

        void SetupButtons()
        {
            //redoButton = new Button(myGame.width/2, myGame.height/2+200, "RedoSpriteSheet.png", true, 2, 1);
            //nextLevelButton = new Button(myGame.width/2+150, myGame.height / 2 + 200, "NextLevelSpriteSheet.png", true, 2, 1);
            //mainMenuButton = new Button(myGame.width/2-150, myGame.height / 2 + 200, "XStyleSheet.png", true, 2, 1);

            redoButton = new Button(0, 200, "RedoSpriteSheet.png", true, 2, 1);
            nextLevelButton = new Button(200, 200, "NextLevelSpriteSheet.png", true, 2, 1);
            mainMenuButton = new Button(-200, 200, "XStyleSheet.png", true, 2, 1);

            AddChild(redoButton);
            AddChild(nextLevelButton);
            AddChild(mainMenuButton);
        }

        void Update()
        {
            AnimateStars();

            UpdateButtons();

            scoreUI.graphics.Clear(Color.Empty);
            scoreUI.graphics.DrawString("Score: " + levelManager.score.ToString(), cowboyFont, Brushes.Black, 30, 110);
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
                if (levelManager.winchannel != null) levelManager.winchannel.Stop();
                levelManager.LoadMainMenu();
            }
            else if (redoButton.CheckIfPressed() == true)
            {
                if (levelManager.levelComplete)
                {
                    levelManager.score -= 100 * levelManager.ammo;
                    levelManager.score -= levelManager.hwallsamount * 50;
                    levelManager.score -= levelManager.vwallsamount * 50;
                }

                if (levelManager.winchannel != null) levelManager.winchannel.Stop();
                levelManager.LoadLevel(levelManager.currentLevel);
                myGame.channelLevel.IsPaused = false;
            }

            if (nextLevelButton.CheckIfPressed() == true)
            {
                if (levelManager.currentLevel < 10)
                {
                    if (levelManager.winchannel != null) levelManager.winchannel.Stop();
                    levelManager.LoadLevel(levelManager.currentLevel + 1);
                    myGame.channelLevel.IsPaused = false;
                    levelManager.reloads = 0;
                }
                else
                {
                    if (levelManager.winchannel != null) levelManager.winchannel.Stop();
                    levelManager.LoadMainMenu();
                    myGame.channelLevel.IsPaused = false;
                }
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