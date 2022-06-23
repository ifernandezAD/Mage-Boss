using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip musicLevel;
    public AudioClip audioJump;
    public AudioClip audioDamage;
    public AudioClip audioDie;
    public AudioClip audioFire;
    public AudioClip audioItem;
    public AudioClip audioChest;
    public AudioClip audioMessage;
    public AudioClip audioBreakWall;
    public AudioClip audioCheckPoint;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       // PlayeLevelMusic();
    }


    public void PlayeLevelMusic()
    {
        audioSource.clip = musicLevel;
        audioSource.Play();
    }

    public void PlayAudioJump()
    {
        audioSource.PlayOneShot(audioJump);
    }

    public void PlayAudioDamage()
    {
        audioSource.PlayOneShot(audioDamage);
    }

    public void PlayAudioDie()
    {
        audioSource.PlayOneShot(audioDie);
    }

    public void PlayAudioFire()
    {
        audioSource.PlayOneShot(audioFire);
    }

    public void PlayAudioChest()
    {
        audioSource.PlayOneShot(audioChest);
    }

    public void PlayAudioItem()
    {
        audioSource.PlayOneShot(audioItem);
    }

    public void PlayAudioMessage()
    {
        audioSource.PlayOneShot(audioMessage);
    }

    public void PlayAudioBreakWall()
    {
        audioSource.PlayOneShot(audioBreakWall);
    }

    public void PlayAudioCheckPoint()
    {
        audioSource.PlayOneShot(audioCheckPoint);
    }

}
