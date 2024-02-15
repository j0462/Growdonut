using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    public static Soundmanager instance = null;
    AudioSource audio;
    GameObject[] sound;
    public static float SoundVolume;

    public GameObject first;
    [Header("토큰음")]
    public AudioClip[] firstClips;
    AudioSource firstchild;
    
    public GameObject second;
    [Header("UI음")]
    public AudioClip[] secondClips;
    AudioSource secondchild;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        audio = GetComponent<AudioSource>(); //bgm
        firstchild = first.GetComponent<AudioSource>();//토큰소리
        secondchild = second.GetComponent<AudioSource>();//UI소리

        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        audio.volume = SoundVolume;
        firstchild.volume = SoundVolume;
        secondchild.volume = SoundVolume;
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", SoundVolume);
    }
    public void AudioPlay()
    {
        audio.Play();
    }
    public void AudioStop()
    {
        audio.Stop();
    }
    public void Playfirst(int index)
    {
        firstchild.clip = firstClips[index];
        firstchild.Play();
    }
    public void Playsecond(int index)
    {
        secondchild.clip = secondClips[index];
        secondchild.Play();
    }
    
}
