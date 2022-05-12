using System;
using GXPEngine;
using System.Drawing;


public class Block : EasyDraw
{
	MyGame myGame = MyGame.current;

	// These four public static fields are changed from MyGame, based on key input (see Console):
	public static bool drawDebugLine = true;
	public static bool wordy = true;
	public static float bounciness = 1;
	// For ease of testing / changing, we assume every block has the same acceleration (gravity):
	public static Vec2 acceleration = new Vec2(0, 0);

	public readonly float radius;

	// Mass = density * volume.
	// In 2D, we assume volume = area (=all objects are assumed to have the same "depth")
	public float Mass
	{
		get
		{
			return 4 * radius * radius * _density;
		}
	}

	public Vec2 position
	{
		get
		{
			return _position;
		}
	}

	public Vec2 velocity;

	public int side = 0;
	public float firstTOI = 0;
	public Block firstColBlock = null;

	public Vec2 _position;
	Vec2 _oldPosition;

	float _red = 1;
	float _green = 1;
	float _blue = 1;

	float _density = 1;

	const float _colorFadeSpeed = 0.025f;

	LevelManager levelManager = LevelManager.current;

	//Canvas _lineContainer = null;

	int _bounces = 10;

	public bool canCollide;

	bool Visible;

	Sound ricochet = new Sound("ground ricochet.mp3");

	public float angle;

	int lives = 2;

	readonly CrateDestruction crateDestruction = null;

	Sound crateSound = new Sound("wood hit crunchymunchy.mp3");

	public Block(float pradius, Vec2 pPosition, Vec2 pVelocity, bool pcanCollide=true, bool pVisible=true, int density=1) : base((int)pradius * 2, (int)pradius * 2)
	{
		radius = pradius;
		_position = pPosition;
		velocity = pVelocity;
		canCollide = pcanCollide;
		Visible = pVisible;

		SetOrigin(radius, radius);
		if (Visible == true) Draw();
		//Draw();
		UpdateScreenPosition();
		_oldPosition = new Vec2(0, 0);
		//bounciness = 1.0f;
		acceleration = new Vec2(0, (100f * 9.81f) / Mass);

		levelManager._lineContainer = new Canvas(myGame.width, myGame.height, false);
		levelManager.AddChild(levelManager._lineContainer);

		_density = density;

		crateDestruction = new CrateDestruction(x, y);
	}

	bool graf = false;

	public void Gravity()
	{

		//if (Input.GetKeyDown(Key.E)) graf = !graf;

		if (graf)
		{

			if (Input.GetKeyDown(Key.UP)) acceleration.SetXY(0, -((100f * 9.81f) / Mass));
			if (Input.GetKeyDown(Key.DOWN)) acceleration.SetXY(0, ((100f * 9.81f) / Mass));
			if (Input.GetKeyDown(Key.LEFT)) acceleration.SetXY(-((100f * 9.81f) / Mass), 0);
			if (Input.GetKeyDown(Key.RIGHT)) acceleration.SetXY(((100f * 9.81f) / Mass), 0);

		}
		else acceleration.SetXY(0, 0);
	}

	public void SetFadeColor(float pRed, float pGreen, float pBlue)
	{
		_red = pRed;
		_green = pGreen;
		_blue = pBlue;
	}

	public void Update()
	{
		if (Input.GetKeyDown(Key.D)) Draw();

		if (_bounces <= 0) SelfDestruct();

		if (lives <= 0) SelfDestruct();

		CheckOffscreen();
	}

	void SelfDestruct()
    {
		int index = -1;

		foreach (Block b in myGame._movers) // remove this block from the _movers list
		{
			if (b == this) index = myGame._movers.IndexOf(b);
		}

		if (index != -1) myGame._movers.RemoveAt(index);

		LateDestroy();
	}

	public void Step()
	{
		_oldPosition = _position;

		if (canCollide == false)
		{
			UpdateScreenPosition();
			return;
		}

		Gravity();
		Move();
		UpdateColor();
		UpdateScreenPosition();
		ShowDebugInfo();
	}

	void CheckOffscreen()
    {
		if (x < 0 - radius||
			x > myGame.width + radius ||
			y < 0 - radius ||
			y > myGame.height + radius)
        {
			SelfDestruct();
        }
    }

	void Move()
	{
		if (canCollide == false) return;

		firstTOI = 1.0f;
		//side 1 is left, 2 is right, 3 is top, 4 is down;
		side = 0;
		firstColBlock = null;

		velocity += acceleration;
		_position += velocity;

		CheckBoundaryCollisions();
		CheckBlockOverlaps();
		ResolveCollision(side, firstTOI, firstColBlock);
	}

	float POI(float Impact, bool onYAxis)
	{

		float timeOfInpact;

		if (onYAxis)
		{
			if (position.y - _oldPosition.y == 0) return 10;
			timeOfInpact = (Impact - _oldPosition.y) / (_position.y - _oldPosition.y);
		}
		else
		{
			if (position.x - _oldPosition.x == 0) return 10;
			timeOfInpact = (Impact - _oldPosition.x) / (_position.x - _oldPosition.x);
		}
		return timeOfInpact;
	}

	void CheckBoundaryCollisions()
	{
		MyGame myGame = (MyGame)game;
		if (_position.x - radius < myGame.LeftXBoundary)
		{
			_bounces--;

			float impact = (myGame.LeftXBoundary + radius);
			float TOI = POI(impact, false);

			if (TOI < firstTOI)
			{
				firstTOI = TOI;
				side = 1;
			}

			SetFadeColor(1, 0.2f, 0.2f);
			if (wordy)
			{
				//Console.WriteLine("Left boundary collision");
			}

			if (myGame.soundOn) ricochet.Play();
		}
		else if (_position.x + radius > myGame.RightXBoundary)
		{
			_bounces--;

			float impact = (myGame.RightXBoundary - radius);
			float TOI = POI(impact, false);
			if (TOI < firstTOI)
			{
				firstTOI = TOI;
				side = 2;
				//Console.WriteLine(firstTOI);
			}

			SetFadeColor(1, 0.2f, 0.2f);
			if (wordy)
			{
				//Console.WriteLine("Right boundary collision");
			}

			if (myGame.soundOn) ricochet.Play();
		}

		if (_position.y - radius < myGame.TopYBoundary)
		{
			_bounces--;

			float impact = (myGame.TopYBoundary + radius);
			float TOI = POI(impact, true);
			if (TOI < firstTOI)
			{
				firstTOI = TOI;
				side = 3;
			}

			SetFadeColor(0.2f, 1, 0.2f);

			if (wordy)
			{
				//Console.WriteLine("Top boundary collision");
			}

			if (myGame.soundOn) ricochet.Play();
		}
		else if (_position.y + radius > myGame.BottomYBoundary)
		{
			_bounces--;

			float impact = (myGame.BottomYBoundary - radius);

			float TOI = POI(impact, true);
			if (TOI < firstTOI)
			{
				firstTOI = TOI;
				side = 3;
			}

			SetFadeColor(0.2f, 1, 0.2f);
			if (wordy)
			{
				//Console.WriteLine("Bottom boundary collision");
			}

			if (myGame.soundOn) ricochet.Play();
		}
	}

	void CheckBlockOverlaps()
	{
		MyGame myGame = (MyGame)game;
		for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
		{
			Block other = myGame.GetMover(i);
			if (other != this)
			{
				if ((this._position.x + this.radius > other._position.x - other.radius) &&
				(this._position.x - this.radius < other._position.x + other.radius) &&
				(this._position.y + this.radius > other._position.y - other.radius) &&
				(this._position.y - this.radius < other._position.y + other.radius))
				{
					_bounces--;
					//LEFT COLLISSION
					if (_position.x - radius < other._position.x + other.radius)
					{
						float impact = (other._position.x + other.radius + this.radius);
						float TOI = POI(impact, false);

						if (TOI >= 0 && TOI < firstTOI)
						{
							float newy = _oldPosition.y + TOI * velocity.y;
							float newy2 = _oldPosition.y + TOI * velocity.y;

							newy += radius;
							newy2 -= radius;

							if (!((newy < (other.position.y - other.radius) && newy2 < (other.position.y - other.radius)) || newy > (other.position.y + other.radius) && newy2 > (other.position.y + other.radius)))
							{
								firstColBlock = other;
								firstTOI = TOI;

								side = 1;
							}
						}
					}

					//RIGHT COLLISION
					if (_position.x + radius > other._position.x - other.radius)
					{


						float impact = (other._position.x - other.radius - this.radius);
						float TOI = POI(impact, false);
						if (Input.GetKey(Key.Z))
						{
							//Console.WriteLine(impact);
							//Console.WriteLine(position.x);
							//Console.WriteLine(_oldPosition.x);
						}
						if (TOI >= 0 && TOI < firstTOI)
						{
							float newy = _oldPosition.y + TOI * velocity.y;
							float newy2 = _oldPosition.y + TOI * velocity.y;

							newy += radius;
							newy2 -= radius;

							if (!((newy < (other.position.y - other.radius) && newy2 < (other.position.y - other.radius)) || newy > (other.position.y + other.radius) && newy2 > (other.position.y + other.radius)))
							{
								firstColBlock = other;
								firstTOI = TOI;
								side = 2;
							}
						}
					}

					//TOP COLLISION
					if (_position.y - radius < other._position.y + other.radius)
					{
						float impact = (other._position.y + other.radius + this.radius);
						float TOI = POI(impact, true);
						if (TOI >= 0 && TOI < firstTOI)
						{

							float newx = _oldPosition.x + TOI * velocity.x;
							float newx2 = _oldPosition.x + TOI * velocity.x;

							newx += radius;
							newx2 -= radius;

							if (!((newx < (other.position.x - other.radius) && newx2 < (other.position.x - other.radius)) || newx > (other.position.x + other.radius) && newx2 > (other.position.x + other.radius)))
							{
								firstColBlock = other;
								firstTOI = TOI;
								side = 3;
							}
						}
					}

					//BOTTOM COLLISION
					if (_position.y + radius > other._position.y - other.radius)
					{
						float impact = (other._position.y - other.radius - this.radius);

						float TOI = POI(impact, true);
						if (TOI >= 0 && TOI < firstTOI)
						{
							float newx = _oldPosition.x + TOI * velocity.x;
							float newx2 = _oldPosition.x + TOI * velocity.x;

							newx += radius;
							newx2 -= radius;

							//checks if both y's are outside the other cube
							if (!((newx < (other.position.x - other.radius) && newx2 < (other.position.x - other.radius)) || newx > (other.position.x + other.radius) && newx2 > (other.position.x + other.radius)))
							{
								firstColBlock = other;
								firstTOI = TOI;
								side = 4;
							}
						}
					}

					SetFadeColor(0.2f, 0.2f, 1);
					other.SetFadeColor(0.2f, 0.2f, 1);
					if (wordy)
					{
						//Console.WriteLine("Block-block overlap detected.");
					}

					if (myGame.soundOn) ricochet.Play();
				}
			}
		}

		//Console.WriteLine(side);
		
		switch (side) // left=1, right=2, top=3, bottom=4.
        {
			case 1:
				myGame.LateAddChild(new Sparks(x+40, y-20, 90));
				break;
			case 2:
				myGame.LateAddChild(new Sparks(x-40, y+20, 270));
				break;
			case 3:
				myGame.LateAddChild(new Sparks(x+25, y+42, 180));
				break;
			case 4:
				myGame.LateAddChild(new Sparks(x-10, y-45, 0));
				break;
		}
	}

	void ResolveCollision(int side, float TOI, Block other = null)
	{
		if (side == 0)
		{
			return;
		}

		if (other == null)
		{
			if (side == 1 || side == 2)
			{
				_position = _oldPosition + firstTOI * velocity;
				velocity.x *= -bounciness;

				//if (side == 1) LateAddChild(new Sparks(_position.x, _position.y, 90));
				//else if (side == 2) LateAddChild(new Sparks(_position.x, _position.y, 270));
			}
			else if (side == 3 || side == 4)
			{
				_position = _oldPosition + firstTOI * velocity;
				velocity.y *= -bounciness;

				//if (side == 3) LateAddChild(new Sparks(_position.x, _position.y, 180));
				//else if (side == 4) LateAddChild(new Sparks(_position.x, _position.y, 0));
			}
		}
		else if (other != null)
		{
			Vec2 relPos = _oldPosition - other.position;
			Vec2 relVel = velocity - other.velocity;

			angle = relVel.Dot(relPos);

			if (angle >= 0) return;

			if (side == 1 || side == 2)
			{
				_position = _oldPosition + firstTOI * velocity;
				other._position = other._oldPosition + firstTOI * other.velocity;
				//if (side == 1) LateAddChild(new Sparks(_position.x, _position.y, 90));
				//else if (side == 2) LateAddChild(new Sparks(_position.x, _position.y, 270));

				float CenterOfMass = ((this.velocity.x * this.Mass + other.velocity.x * other.Mass) / (this.Mass + firstColBlock.Mass));
				velocity.x = CenterOfMass - bounciness * (velocity.x - CenterOfMass);
				other.velocity.x = CenterOfMass - bounciness * (other.velocity.x - CenterOfMass);

			}
			else if (side == 3 || side == 4)
			{
				_position = _oldPosition + firstTOI * velocity;
				firstColBlock._position = firstColBlock._oldPosition + firstTOI * firstColBlock.velocity;

				//if (side == 3) LateAddChild(new Sparks(_position.x, _position.y, 180));
				//else if (side == 4) LateAddChild(new Sparks(_position.x, _position.y, 0));

				float CenterOfMass = ((this.velocity.y * this.Mass + firstColBlock.velocity.y * firstColBlock.Mass) / (this.Mass + firstColBlock.Mass));
				velocity.y = CenterOfMass - bounciness * (velocity.y - CenterOfMass);
				firstColBlock.velocity.y = CenterOfMass - bounciness * (firstColBlock.velocity.y - CenterOfMass);
			}

		}
	}

	void UpdateColor()
	{
		if (_red < 1)
		{
			_red = Mathf.Min(1, _red + _colorFadeSpeed);
		}
		if (_green < 1)
		{
			_green = Mathf.Min(1, _green + _colorFadeSpeed);
		}
		if (_blue < 1)
		{
			_blue = Mathf.Min(1, _blue + _colorFadeSpeed);
		}
		SetColor(_red, _green, _blue);
	}

	public void DrawLine(Vec2 start, Vec2 end)
	{
		if (myGame.trailOn == false) return;
		levelManager._lineContainer.graphics.DrawLine(Pens.White, start.x, start.y, end.x, end.y);
	}

	void ShowDebugInfo()
	{
		if (drawDebugLine)
		{
			DrawLine(_oldPosition, _position);
		}
	}

	void UpdateScreenPosition()
	{
		x = _position.x;
		y = _position.y;
	}

	void Draw()
	{
		Fill(200);
		NoStroke();
		ShapeAlign(CenterMode.Min, CenterMode.Min);
		Rect(0, 0, width, height);
	}

	bool slow = false;
	public bool isBullet = false;

	void OnCollision(GameObject other)
    {
		if (other is Crate)
        {
			Console.WriteLine(lives.ToString());

			if (slow == false)
			{
				velocity.x /= 2;
				velocity.y /= 2;

				slow = true;
			}

			if (isBullet == true)
			{
				lives--;

				if (crateDestruction != null)
                {
					levelManager.LateAddChild(crateDestruction);
					crateDestruction.x = other.x;
					crateDestruction.y = other.y;
				}

				crateSound.Play();
				other.LateDestroy();
			}
		}
	}
}