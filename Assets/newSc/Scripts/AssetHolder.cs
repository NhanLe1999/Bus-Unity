using UnityEngine;

public class AssetHolder : SingleTons<AssetHolder>
{
	public AudioClipSO audioClipSO;

	public ProjectileSO projectileSO;

	public Quest[] questList;

	public Achivement[] achivementList;

	public ScriptableObject[] so;

	public ScriptableObject[] eventSO;

	public AnimationCurve treasurePopDisplayCurve;

	public AnimationCurve treasurePopShowOnDisplayCurve;

	public AnimationCurve treasurePopToPlayCurve;

	public AnimationCurve treasurePopOnDisappear;
}
