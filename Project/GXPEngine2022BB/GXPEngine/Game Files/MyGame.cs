using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	public static MyGame current; // to access mygame from another class put this in the declarations: MyGame myGame = MyGame.current;

	LevelManager levelManager;

	Canvas pixelUI;

	static void Main()
	{
		new MyGame().Start();
	}

	public MyGame() : base(1280, 720, false)
	{
		targetFps = 60;
		current = this;

		levelManager = new LevelManager();
		LateAddChild(levelManager);
		pixelUI = new Canvas(500, 500, false);
		LateAddChild(pixelUI);
	}

	void Update()
	{
		if(Input.GetKey(Key.SPACE))
        {
			int mouseX = Input.mouseX;
			int mouseY = Input.mouseY;

			pixelUI.graphics.Clear(Color.Empty);
			pixelUI.graphics.DrawString(mouseX.ToString() + " " + mouseY.ToString(), SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }
	}
}