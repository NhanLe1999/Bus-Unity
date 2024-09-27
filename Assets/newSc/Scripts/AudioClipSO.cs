using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Clip", menuName = "SO/Audio Clip")]
public class AudioClipSO : ScriptableObject
{
	[Serializable]
	public class AudioData
	{
		public AudioClip clip;

		[Range(0f, 1f)]
		public float volume;
	}

	public static AudioClipSO ins;

	public List<AudioData> soundDatas;

	public List<AudioData> musicDatas;

	private void Awake()
	{
	}
}
