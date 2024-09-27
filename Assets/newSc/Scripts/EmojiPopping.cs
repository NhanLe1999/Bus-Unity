using UnityEngine;

public class EmojiPopping : MonoBehaviour
{
	public static EmojiPopping cur;

	public new GameObject gameObject;

	public GameObject[] emojiObjects;

	public Transform[] emojiTrans;

	private bool[] emojiFlags;

	[SerializeField]
	private Vector3 offsetFromMinion;

	[SerializeField]
	private Vector3 offsetFromMinionOnBoard;

	[SerializeField]
	private float[] durationOptions;

	[SerializeField]
	private float[] timeSpaceOptions;

	private float timePoint;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public static void Activate(bool isOn)
	{
	}

	private void OffEmoji(int index)
	{
	}

	private void PopEmoji()
	{
	}
}
