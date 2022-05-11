using System;
using System.Drawing;
using System.Collections.Generic;
using GXPEngine;

public class MyGame : Game
{
	public static MyGame current; // to access mygame from another class put this in the declarations: MyGame myGame = MyGame.current;

	public List<Block> _movers = new List<Block>();

	public float LeftXBoundary; //default is set in constructor
	public float RightXBoundary;
	public float TopYBoundary;
	public float BottomYBoundary;
	public Boolean soundOn = true;
	public Boolean musicOn = true;

	static void Main()
	{
		new MyGame().Start();
	}

	public MyGame() : base(1280, 720, false, false)
	{
		targetFps = 60;
		current = this;

		LeftXBoundary = 64;
		RightXBoundary = width - 64;
		TopYBoundary = 64;
		BottomYBoundary = height - 64;

		LateAddChild(new LevelManager());
	}

	void Update()
    {
		StepThroughMovers();
	}

	void StepThroughMovers()
	{
		foreach (Block bullet in _movers)
		{
			bullet.Step();
		}

		foreach (Block b in _movers) b.Step();
	}

	public int GetNumberOfMovers()
    {
		return _movers.Count;
	}

	public Block GetMover(int index)
	{
		if (index >= 0 && index < _movers.Count)
		{
			return _movers[index];
		}
		return null;
	}
}