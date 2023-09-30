using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicSource = GetComponent<AudioSource>();
    }

    // 음악 한번만 재생시 사용
    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = false;
        musicSource.Play();
    }

    //음악 루프로 실행시 사용
    public void PlayMusicLoop(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    //음악 한번만 실행할때 사용하는 함수
    public void PlayOneShot(AudioClip musicClip)
    {
        musicSource.PlayOneShot(musicClip);
    }
}