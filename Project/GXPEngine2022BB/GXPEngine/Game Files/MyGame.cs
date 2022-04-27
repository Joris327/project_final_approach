using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	public static MyGame current; // to access mygame from another class put this in the declarations: MyGame myGame = MyGame.current;

	static void Main()
	{
		new MyGame().Start();
	}

	public MyGame() : base(1280, 720, false)
	{
		targetFps = 60;
		current = this;

		LateAddChild(new LevelManager());
	}
}