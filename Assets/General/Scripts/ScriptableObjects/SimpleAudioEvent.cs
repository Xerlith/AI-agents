using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class SimpleAudioEvent : AudioEvent
{
	public AudioClip[] clips;

	public float volumeRange;

	public float pitchRange;

	public override void Play(AudioSource source)
	{
		if (clips.Length == 0) return;

		source.clip = clips[Random.Range(0, clips.Length)];
		source.volume = Random.Range(1-volumeRange, 1+volumeRange);
		source.pitch = Random.Range(1-pitchRange, 1+pitchRange);
		source.Play();
	}
}