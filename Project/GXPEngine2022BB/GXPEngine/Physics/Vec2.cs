using System;
using GXPEngine;

public struct Vec2
{
	public float x;
	public float y;

	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}

	public void Normalize()
	{
		float len = this.Length();
		if (len > 0)
		{
			this.x /= len;
			this.y /= len;
		}

	}

	public Vec2 Normalized()
	{
		float len = this.Length();
		if (len > 0)
		{
			float newX = this.x / len;
			float newY = this.y / len;
			return new Vec2(newX, newY);
		}
		else
		{
			return new Vec2(0, 0);
		}


	}

	public float Length()
	{
		float pyth = (this.x * this.x) + (this.y * this.y);
		float len = Mathf.Sqrt(pyth);
		return len;
	}

	public void SetXY(float newX, float newY)
	{
		this.x = newX;
		this.y = newY;
	}

	public static Vec2 operator *(Vec2 v, float scale)
	{
		float newX = v.x *= scale;
		float newY = v.y *= scale;

		return new Vec2(newX, newY);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}
}

