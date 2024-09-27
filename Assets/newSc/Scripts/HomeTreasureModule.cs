using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeTreasureModule : MonoBehaviour
{
	public static HomeTreasureModule cur;

	public new GameObject gameObject;

	public ProgressBarPro barPro;

	public TMP_Text progressText;

	public TMP_Text timeLeftText;

	[SerializeField]
	private AnimationCurve barIncreaseCurve;

	[SerializeField]
	private AnimationCurve barIncreaseDurationCurve;

	public RectTransform objectiveIconRect;

	public RectTransform itemRestRect;

	public RectTransform singleItemShowRect;

	public RectTransform chestShowRect;

	public GameObject firstDarkObject;

	public Image firstDarkImage;

	public GameObject secondDarkObject;

	public Image secondDarkImage;

	public GameObject thirdDarkObject;

	public Image thirdDarkImage;

	public GameObject blockagePanelObject;

	//public TreasureItem objectTreasureItem;

	//public TreasureItem itemTreasureItem;

	public Image objectiveImage;

	public Sprite[] objectiveSprites;

	public RectTransform tapToContinueRect;

	private Tween tapToContinueTween;

	//public ParticleImage objectiveEffect;

	private bool isHandlingTreasure;

	//public ParticleImage splashEffect;

	public TreasureShowIcon[] treasureShowIcons;

	public RectTransform[] chestFormation_1;

	public RectTransform[] chestFormation_2;

	public RectTransform[] chestFormation_3;

	public RectTransform[] chestFormation_4;

	public RectTransform[] multiFormation_1;

	public RectTransform[] multiFormation_2;

	public RectTransform[] multiFormation_3;

	public RectTransform[] multiFormation_4;

	[Header("Treasure Item")]
	public Sprite[] itemSprites;

	public Vector2[] imageSize;

	public Vector2[] imagePos;

	public GameObject showCaseObject;

	private static readonly WaitUntil CheckTimeCondition;

	private static readonly WaitUntil WaitForTap;

	private void Awake()
	{
	}

	public void OnClickTreasure()
	{
	}

	public void JustBeNormal()
	{
	}

	public void CheckTime()
	{
	}

	public string GetTime()
	{
		return null;
	}

	public void HandleTreasure()
	{
	}

	private void NukeTreasureShowIcon()
	{
	}

	private void SetProgressBar()
	{
	}

	public void PopBlinkEffect()
	{
	}
}
