using System;

[Serializable]
public class MatrixPrime<Fuck>
{
	public ArrayPrime<Fuck>[] elements;

	public Fuck this[int x, int y] => default(Fuck);

	public Fuck[] this[int i] => null;

	public int GetLength(int dim)
	{
		return 0;
	}
}
