using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject goSoundManager = new GameObject("SoundManager");
                DontDestroyOnLoad(goSoundManager);
                instance = (SoundManager)goSoundManager.AddComponent(typeof(SoundManager));
                instance.audioSource = (AudioSource)goSoundManager.AddComponent(typeof(AudioSource));
            }
            return instance;
        }
    }

    public float MasterVolume { get; set; }
    public float SfxVolume { get; set; }
    public float MusicVolume { get; set; }
    private AudioSource audioSource = null;
    public AudioClip[] bgms;
    public int iCurrentBGM = 0;

    void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //1초 뒤 실행
        //invoke("gamestart", 1f);   
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);

        bgms = Resources.LoadAll<AudioClip>("Audio/BGM");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayBGM(int iBGMNumber)
    {
        iCurrentBGM = iBGMNumber;
        if (bgms[iCurrentBGM] == null)
            return;
        audioSource.clip = bgms[iCurrentBGM];
        audioSource.volume = MasterVolume * MusicVolume * 100;
        audioSource.loop = true;
        if (audioSource.isPlaying == false)
            audioSource.Play();
    }


    public void SetMasterVolume(float fValue)
    {
        MasterVolume = fValue;
        Debug.Log(MasterVolume);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
        audioSource.volume = MasterVolume;
        //GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
    }
    public void SetMusicVolume(float fValue)
    {
        MusicVolume = fValue;
        Debug.Log(MusicVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        //GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
    }
    public void SetSfxVolume(float fValue)
    {
        SfxVolume = fValue;
        Debug.Log(SfxVolume);
        PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
    }
}
