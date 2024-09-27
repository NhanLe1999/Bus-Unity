public class SingleTonNonmono<T> where T : new()
{
	public static T ins;

	public static T Instance => default(T);
}
