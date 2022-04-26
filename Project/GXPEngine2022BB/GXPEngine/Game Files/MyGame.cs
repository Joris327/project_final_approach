using System;
using GXPEngine;

public class MyGame : Game
{
	public static MyGame current; // to access mygame from another class this in the declarations: MyGame myGame = MyGame.current;

	LevelManager levelManager;

	static void Main()
	{
		new MyGame().Start();
	}

	public MyGame() : base(800, 600, false)
	{
		levelManager = new LevelManager();
		LateAddChild(levelManager);
	}

	void Update()
	{
		if (Input.GetKeyDown(Key.SPACE))
        {
			levelManager.RemoveAllLevels();
        }
		if (Input.GetKeyDown(Key.ZERO))
        {
			levelManager.LoadMainMenu();
        }
	}
}