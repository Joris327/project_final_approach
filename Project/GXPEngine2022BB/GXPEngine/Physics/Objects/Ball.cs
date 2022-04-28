using System;
using GXPEngine;

public class Ball : EasyDraw
{
	bool drawing = false;

	public int radius
	{
		get
		{
			return _radius;
		}
	}

	public Vec2 acceleration;
	public Vec2 velocity;
	public Vec2 position;

	int _radius;
	float _speed;
	Vec2 _oldposition;

	

	public Ball(int pRadius, Vec2 pPosition, float pSpeed = 5) : base(pRadius * 2 + 1, pRadius * 2 + 1)
	{
		_radius = pRadius;
		position = pPosition;
		_speed = pSpeed;
		velocity.SetXY(-5, 4);
		UpdateScreenPosition();
		SetOrigin(_radius, _radius);

		Draw(255, 255, 255);
	}

	bool graf = false;
	public void Gravity()
	{
		if (Input.GetKeyDown(Key.E)) graf = !graf;

		if (graf)
		{

			if (Input.GetKeyDown(Key.UP)) acceleration.SetXY(0, -((9.81f) / 100));
			if (Input.GetKeyDown(Key.DOWN)) acceleration.SetXY(0, ((9.81f) / 100));
			if (Input.GetKeyDown(Key.LEFT)) acceleration.SetXY(-((9.81f) / 100), 0);
			if (Input.GetKeyDown(Key.RIGHT)) acceleration.SetXY(((9.81f) / 100), 0);

		}
		else acceleration.SetXY(0, 0);
	}

	void Draw(byte red, byte green, byte blue)
	{
		Fill(red, green, blue);
		Stroke(red, green, blue);
		Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
	}

	void FollowMouse()
	{
		position.SetXY(Input.mouseX, Input.mouseY);
	}

	public void UpdateScreenPosition()
	{
		x = position.x;
		y = position.y;
	}

	public void Step()
	{
		Gravity();
		_oldposition = position;

		velocity += acceleration;
		position += velocity;

		//CheckLines();
		UpdateScreenPosition();

		if (Input.GetKeyDown(Key.D)) drawing = !drawing;

		//if (drawing)
		{
			//((MyGame)game).DrawLine(_oldposition, position);
		}
	}
	/*
	public void CheckLines()
	{

		MyGame myGame = (MyGame)game;

		for (int i = 0; i < myGame.GetNumberOfLines(); i++)
		{
			NLineSegment _line = myGame.GetLine(i);

			Vec2 point = _line.start;
			Vec2 line = _line.start - _line.end;

			Vec2 normalLine = line.Normal();
			Vec2 difference = point - position;

			float ballDistance = difference.Dot(normalLine);

			if (Mathf.Abs(ballDistance) < _radius)
			{
				SetColor(1, 0, 0);
				position -= (-ballDistance + radius) * normalLine;

				velocity.Reflect(normalLine);

				velocity *= bounciness;

				UpdateScreenPosition();
			}
			else
			{
				SetColor(0, 1, 0);
			}
		}
	}
	*/
}
