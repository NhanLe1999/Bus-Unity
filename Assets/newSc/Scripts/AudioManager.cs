using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : SingleTons<AudioManager>
{

	public AudioSource SoundAudioSource;

	public AudioSource MusicAudioSource;

	private AudioClipSO audioClipSO;

	protected override void Awake()
	{
	}

	private IEnumerator Start()
	{
		return null;
	}

	public void UpdateAudio()
	{
	}

	public void SetSoundState(bool isOn)
	{
	}

	public void SetMusicState(bool isOn)
	{
	}

	public void SetVibrateState(bool isOn)
	{
	}

	public void PlaySound(SoundType type)
	{
	}

	public void PlayMusic(MusicType type)
	{
	}

	public void MakeVibrate()
	{
	}
}
