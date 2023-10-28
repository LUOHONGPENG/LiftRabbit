using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BGM1,
    BGM2,
    Hello1,
    Hello2,
    DaDa,
    LevelUp,
    Eat,
    NoConsumer,
    Shit
}

public class SoundMgr : MonoBehaviour
{
    [Header("BGM")]
    public AudioSource auBGM1;

    [Header("Sound")]
    public AudioSource auHello1;
    public AudioSource auHello2;
    public AudioSource auDaDa;
    public AudioSource auLevelUp;
    public AudioSource auEat;
    public AudioSource auNoConsumer;



    public Dictionary<SoundType, AudioSource> dicSoundAudio = new Dictionary<SoundType, AudioSource>();
    public Dictionary<SoundType, float> dicSoundTime = new Dictionary<SoundType, float>();

    [Header("Test")]
    public SoundType testSoundType;

    public void OnEnable()
    {
        EventCenter.Instance.AddEventListener("PlaySound", PlaySound);
        EventCenter.Instance.AddEventListener("StopSound", StopSound);

    }

    public void OnDestroy()
    {
        EventCenter.Instance.RemoveEventListener("PlaySound", PlaySound);
        EventCenter.Instance.RemoveEventListener("StopSound", StopSound);

    }

    public void Init()
    {
        dicSoundAudio.Clear();
        dicSoundAudio.Add(SoundType.Hello1, auHello1);
        dicSoundAudio.Add(SoundType.Hello2, auHello2);
        dicSoundAudio.Add(SoundType.DaDa, auDaDa);
        dicSoundAudio.Add(SoundType.LevelUp, auLevelUp);
        dicSoundAudio.Add(SoundType.Eat, auEat);
        dicSoundAudio.Add(SoundType.NoConsumer, auNoConsumer);


        dicSoundTime.Clear();
        dicSoundTime.Add(SoundType.Hello1, 0.4f);
        dicSoundTime.Add(SoundType.Hello2, 0.4f);
        dicSoundTime.Add(SoundType.DaDa, 1.4f);
        dicSoundTime.Add(SoundType.LevelUp, 0.4f);
        dicSoundTime.Add(SoundType.Eat, 0.2f);

    }

    public void PlaySound(object arg0)
    {
        SoundType soundType = (SoundType)arg0;

        if (dicSoundAudio.ContainsKey(soundType))
        {
            AudioSource targetSound = dicSoundAudio[soundType];

            float playTime = 0.6f;
            if (dicSoundTime.ContainsKey(soundType))
            {
                playTime = dicSoundTime[soundType];
            }
            targetSound.time = playTime;
            targetSound.Play();
        }
    }

    public void StopSound(object arg0)
    {
        SoundType soundType = (SoundType)arg0;

        if (dicSoundAudio.ContainsKey(soundType))
        {
            AudioSource targetSound = dicSoundAudio[soundType];

            targetSound.Stop();
        }
    }


    public void PlaySoundTime(SoundType soundType, float playtime)
    {
        if (dicSoundAudio.ContainsKey(soundType))
        {
            AudioSource targetSound = dicSoundAudio[soundType];

            float playTime = playtime;
            targetSound.time = playTime;
            targetSound.Play();
        }
    }
}
