using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{

    public static IEnumerator StartFade(AudioSource song, float duration, float targetVolume)
    {
        GameManager manager = FindObjectOfType<GameManager>();
        // manager.isMusicFading = true;

        float currentTime = 0;
        float start = song.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            song.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        // manager.isMusicFading = false;
        yield break;
    }
}
