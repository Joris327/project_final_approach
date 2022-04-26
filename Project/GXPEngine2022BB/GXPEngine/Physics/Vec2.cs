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

	public float Length()
	{
		float length;
		length = Mathf.Sqrt((x * x) + (y * y));
		return length;
	}

	public void Normalize()
	{
		if (Length() == 0) return;

		float scalar = 1 / Length();
		x *= scalar;
		y *= scalar;
	}

	public Vec2 Normalized()
	{
		if (Length() == 0) return this;

		Vec2 normalize;
		float scalar = 1 / Length();
		normalize = new Vec2(x * scalar, y * scalar);
		return normalize;
	}

	public void SetXY(float setX, float setY)
	{
		x = setX;
		y = setY;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)    //add
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}
	public static Vec2 operator +(float left, Vec2 right)
	{
		return new Vec2(left + right.x, left + right.y);
	}
	public static Vec2 operator +(Vec2 left, float right)
	{
		return new Vec2(left.x + right, left.y + right);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right) //substract
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}
	public static Vec2 operator -(float left, Vec2 right)
	{
		return new Vec2(left - right.x, left - right.y);
	}
	public static Vec2 operator -(Vec2 left, float right)
	{
		return new Vec2(left.x - right, left.y - right);
	}

	public static Vec2 operator *(Vec2 left, Vec2 right) //multiply
	{
		return new Vec2(left.x * right.x, left.y * right.y);
	}
	public static Vec2 operator *(float left, Vec2 right)
	{
		return new Vec2(left * right.x, left * right.y);
	}
	public static Vec2 operator *(Vec2 left, float right)
	{
		return new Vec2(left.x * right, left.y * right);
	}

	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}

	public static float DegToRad(float deg)
	{
		float radians = deg * (Mathf.PI / 180.0f);
		return radians;
	}

	public static float RadToDeg(float rad)
	{
		float degrees = rad * (180.0f / Mathf.PI);
		return degrees;
	}

	public static Vec2 GetUnitVecRad(float rad)
	{
		float newX = Mathf.Cos(rad);
		float newY = Mathf.Sin(rad);
		return new Vec2(newX, newY);
	}

	public static Vec2 GetUnitVecDeg(float deg)
	{
		return GetUnitVecRad(DegToRad(deg));
	}

	public static Vec2 RandomUnitVec()
	{
		float random_Deg = Utils.Random(0.0f, 360.0f);
		return GetUnitVecDeg(random_Deg);
	}

	public void SetAngleRad(float rad)
	{
		float newX = Mathf.Cos(rad) * Length();
		float newY = Mathf.Sin(rad) * Length();
		SetXY(newX, newY);
	}

	public void SetAngleDeg(float deg)
	{
		SetAngleRad(DegToRad(deg));
	}

	public float GetAngleRad()
	{
		return Mathf.Atan2(y, x);
	}

	public float GetAngleDeg()
	{
		return RadToDeg(Mathf.Atan2(y, x));
	}

	public void RotateRad(float rad)
	{
		SetXY(x * Mathf.Cos(rad) - y * Mathf.Sin(rad), x * Mathf.Sin(rad) + y * Mathf.Cos(rad));
	}

	public void RotateDeg(float deg)
	{
		RotateRad(DegToRad(deg));
	}

	public void RotateAroundVecRad(Vec2 RotationPoint, float rad)
	{
		this -= RotationPoint;
		RotateRad(rad);
		this += RotationPoint;
	}

	public void RotateAroundVecDeg(Vec2 RotationPoint, float deg)
	{
		RotateAroundVecRad(RotationPoint, DegToRad(deg));
	}

	public static Vec2 GetMousePosition()
	{
		return new Vec2(Input.mouseX, Input.mouseY);
	}
}