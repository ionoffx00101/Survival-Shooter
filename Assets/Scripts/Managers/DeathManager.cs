using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour {

    // 배경음악을 끄고 싶다.

    public AudioSource backgroundMusic;

    private void Awake()
    {
        backgroundMusic = GetComponent<AudioSource>();

    }

    void musicStop()
    {

        backgroundMusic.Stop();

    }
}
