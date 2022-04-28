using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	public static MyGame current; // to access mygame from another class put this in the declarations: MyGame myGame = MyGame.current;

	public float LeftXBoundary = 0;
	public float RightXBoundary = 0;
	public float TopYBoundary = 0;
	public float BottomYBoundary = 0;

	static void Main()
	{
		new MyGame().Start();
	}

	public MyGame() : base(1280, 720, false, false)
	{
		targetFps = 60;
		current = this;

		LateAddChild(new LevelManager());
	}

	public int GetNumberOfMovers()
    {
		return 1;
    }

	public Block GetMover(int index)
	{
		//if (index >= 0 && index < _movers.Count)
		{
			//return _movers[index];
		}
		return null;
	}
}