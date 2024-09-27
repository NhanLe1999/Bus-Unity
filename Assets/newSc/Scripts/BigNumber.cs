using System;

[Serializable]
public struct BigNumber
{
	private static string[] sRank;

	public double v;

	public int m;

	public static BigNumber ZERO => default(BigNumber);

	public BigNumber(long value)
	{
		v = 0.0;
		m = 0;
	}

	public BigNumber(ulong value)
	{
		v = 0.0;
		m = 0;
	}

	public BigNumber(float value)
	{
		v = 0.0;
		m = 0;
	}

	public BigNumber(double value)
	{
		v = 0.0;
		m = 0;
	}

	public void Init(ulong value)
	{
	}

	public BigNumber(BigNumber bi)
	{
		v = 0.0;
		m = 0;
	}

	public BigNumber(double _v, int _m)
	{
		v = 0.0;
		m = 0;
	}

	public BigNumber(string value, int radix)
	{
		v = 0.0;
		m = 0;
	}

	public BigNumber(string value)
	{
		v = 0.0;
		m = 0;
	}

	public static implicit operator BigNumber(long value)
	{
		return default(BigNumber);
	}

	public static implicit operator BigNumber(ulong value)
	{
		return default(BigNumber);
	}

	public static implicit operator BigNumber(int value)
	{
		return default(BigNumber);
	}

	public static implicit operator BigNumber(uint value)
	{
		return default(BigNumber);
	}

	public static implicit operator BigNumber(float value)
	{
		return default(BigNumber);
	}

	public static implicit operator BigNumber(double value)
	{
		return default(BigNumber);
	}

	public static bool operator ==(BigNumber bi1, BigNumber bi2)
	{
		return false;
	}

	public static bool operator !=(BigNumber bi1, BigNumber bi2)
	{
		return false;
	}

	public override bool Equals(object o)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public static bool operator >(BigNumber bi1, BigNumber bi2)
	{
		return false;
	}

	public static bool operator <(BigNumber bi1, BigNumber bi2)
	{
		return false;
	}

	public static bool operator >=(BigNumber bi1, BigNumber bi2)
	{
		return false;
	}

	public static bool operator <=(BigNumber bi1, BigNumber bi2)
	{
		return false;
	}

	public static BigNumber operator /(BigNumber bi1, BigNumber bi2)
	{
		return default(BigNumber);
	}

	public static BigNumber operator +(BigNumber bi1, BigNumber bi2)
	{
		return default(BigNumber);
	}

	public static BigNumber operator -(BigNumber bi1, BigNumber bi2)
	{
		return default(BigNumber);
	}

	public static BigNumber operator *(BigNumber bi1, BigNumber bi2)
	{
		return default(BigNumber);
	}

	public BigNumber max(BigNumber bi)
	{
		return default(BigNumber);
	}

	public BigNumber min(BigNumber bi)
	{
		return default(BigNumber);
	}

	public override string ToString()
	{
		return null;
	}

	public BigNumber sqrt()
	{
		return default(BigNumber);
	}

	public BigNumber sqrtPermanent()
	{
		return default(BigNumber);
	}

	public BigNumber Normalize()
	{
		return default(BigNumber);
	}

	public string ToString2()
	{
		return null;
	}

	public string ToCharacterFormat()
	{
		return null;
	}

	public int ToInt()
	{
		return 0;
	}

	public long ToLong()
	{
		return 0L;
	}

	public BigNumber multiplyWithFloat(float f)
	{
		return default(BigNumber);
	}

	public BigNumber multiplyWithFloatPernament(float f)
	{
		return default(BigNumber);
	}

	public BigNumber multiplyInt(int i)
	{
		return default(BigNumber);
	}

	public BigNumber multiplyIntPernament(int i, bool isReleaseVal = true)
	{
		return default(BigNumber);
	}

	public static BigNumber ParseFromDouble(double d)
	{
		return default(BigNumber);
	}

	public static BigNumber ParseFromCharacterFormat(string s)
	{
		return default(BigNumber);
	}

	public static BigNumber Clamp(BigNumber value, BigNumber min, BigNumber max)
	{
		return default(BigNumber);
	}

	public BigNumber powPernament(int exp)
	{
		return default(BigNumber);
	}

	public BigNumber pow(int exp)
	{
		return default(BigNumber);
	}

	internal BigNumber dividePermanent(BigNumber amount, bool isRelease = false)
	{
		return default(BigNumber);
	}

	internal BigNumber divide(BigNumber amount, bool isReleaseVal = false)
	{
		return default(BigNumber);
	}

	internal BigNumber multiplyPermanent(BigNumber amount, bool isReleaseVal = false)
	{
		return default(BigNumber);
	}

	internal BigNumber multiply(BigNumber amount, bool isReleaseVal = false)
	{
		return default(BigNumber);
	}

	internal BigNumber subtractPermanent(BigNumber amount, bool isRelease = false)
	{
		return default(BigNumber);
	}

	internal BigNumber subtract(BigNumber amount, bool isRelease = false)
	{
		return default(BigNumber);
	}

	internal BigNumber addPermanent(BigNumber amount, bool isReleaseVal = false)
	{
		return default(BigNumber);
	}

	public BigNumber add(BigNumber amount, bool isReleaseVal = false)
	{
		return default(BigNumber);
	}

	private BigNumber CopyData(BigNumber val)
	{
		return default(BigNumber);
	}

	public float ToFloat()
	{
		return 0f;
	}

	public double ToDouble()
	{
		return 0.0;
	}

	public BigNumber RoundToInt()
	{
		return default(BigNumber);
	}
}
