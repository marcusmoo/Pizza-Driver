using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    float length;
    
    // Start is called before the first frame update
    void Start()
    {
        length = backgroundMusic.clip.length;
        StartCoroutine(LoopAudio());
    }

    IEnumerator LoopAudio()
    {
        while (true)
        {
            backgroundMusic.Play();
            yield return new WaitForSeconds(length);
        }
    }
}
