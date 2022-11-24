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

	public bool soundOn = true;
	public bool musicOn = true;
	public bool trailOn = true;

	public bool gameStarted = false;
	public bool mainMusicPlaying = false;
	public bool bMusicPlaying = false;

	public SoundChannel channel;
	public SoundChannel channelLevel;

	

	static void Main()
	{
		new MyGame().Start();
	}

	public MyGame() : base(1280, 720, true, false)
	{
		targetFps = 60;
		current = this;
		ShowMouse(true);

		LeftXBoundary = 64;
		RightXBoundary = width - 64;
		TopYBoundary = 64;
		BottomYBoundary = height - 64;

		LateAddChild(new LevelManager());
	}

	void Update()
    {
		ManageMusic();

		StepThroughMovers();
	}

	void ManageMusic()
    {
		Sound menuMusic = new Sound("mainmenu_music.mp3", true);
		Sound levelMusic = new Sound("b_music.mp3", true);

		if (musicOn)
		{
			if (!mainMusicPlaying && !gameStarted)
			{
				channel = menuMusic.Play();
				mainMusicPlaying = true;
			}

			if (gameStarted)
			{
				channel.Stop();
				mainMusicPlaying = false;

				if (!bMusicPlaying)
				{
					channelLevel = levelMusic.Play();
					bMusicPlaying = true;
				}
			}

			if (!gameStarted && channelLevel != null)
			{
				channelLevel.Stop();
				bMusicPlaying = false;
			}
		}

		if (!musicOn)
		{
			channel.Mute = true;
		}
		else
		{
			channel.Mute = false;
		}
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