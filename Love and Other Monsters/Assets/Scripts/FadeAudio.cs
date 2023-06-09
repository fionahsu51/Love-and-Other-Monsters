using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from here. thank you!
// https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
public static class FadeAudioSource {
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        yield break;
    }

    public static void PlayBGM(AudioSource source, AudioClip clip){
        source.clip = clip;
        source.Play();
    }
}