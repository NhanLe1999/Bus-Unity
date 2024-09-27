using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "SO/Projectile")]
public class ProjectileSO : ScriptableObject
{
	public static ProjectileSO ins;

	public ProjectileVariation[] projectiles;

	private void Awake()
	{
	}
}
