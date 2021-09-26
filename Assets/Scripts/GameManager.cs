using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;


public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    public SpriteAtlas BGAtlas;
    private Dictionary<string, Sprite> dicBGSprite = new Dictionary<string, Sprite>();

    float masterVolumePercent = 1f;
    public float MasterVolume { get => masterVolumePercent; set => masterVolumePercent = value; }
    float sfxVolumePercent = 1f;
    public float SfxVolume { get => sfxVolumePercent; set => sfxVolumePercent = value; }
    float musicVolumePercent = 1f;
    public float MusicVolume { get => musicVolumePercent; set => musicVolumePercent = value; }

    public AudioClip[] bgms;
    //public static sceneState sceneIndex;

    [SerializeField]
    public GameObject main;
    [SerializeField]
    public GameObject option;

    public Slider[] volumeSliders;

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        main.SetActive(true);
        option.SetActive(false);
    }

    public void OptionMenu()
    {
        main.SetActive(false);
        option.SetActive(true);
    }

    public void SetMasterVolume()
    {
        MasterVolume = volumeSliders[0].value;
        Debug.Log(MasterVolume);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
        //GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
    }
    public void SetMusicVolume()
    {
        MusicVolume = volumeSliders[1].value;
        Debug.Log(MusicVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        //GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
    }
    public void SetSfxVolume()
    {
        SfxVolume = volumeSliders[2].value;
        Debug.Log(SfxVolume);
        PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
    }
    public void PlayMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        //sceneIndex = (sceneState)SceneManager.GetActiveScene().buildIndex;
        audioSource.clip = bgms[(int)0];
        audioSource.volume = MasterVolume * MusicVolume * 100;
        if(audioSource.isPlaying == false)
        audioSource.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        //1초 뒤 실행
        //Invoke("GameStart", 1f);   
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume",1f);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume",1f);
        SfxVolume = PlayerPrefs.GetFloat("SfxVolume",1f);

        volumeSliders[0].value = MasterVolume;
        volumeSliders[1].value = MusicVolume;
        volumeSliders[2].value = sfxVolumePercent;

        PlayMusic();

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        GetComponent<AudioSource>().volume = MasterVolume * MusicVolume;
    }

    public Sprite GetSprite(string strKey)
    {
        if (dicBGSprite.ContainsKey(strKey))
            return dicBGSprite[strKey];
        else
        {
            Sprite tempSprite = null;
            tempSprite = BGAtlas.GetSprite(strKey);

            if (tempSprite != null)
                dicBGSprite.Add(strKey, tempSprite);

            return tempSprite;
        }
    }
    public void LoadScene(int sceneIndex)
    {
        SceneIndex sceneNum = (SceneIndex)sceneIndex;
        LoadingSceneController.LoadScene(sceneNum.ToString());
    }
}
