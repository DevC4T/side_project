using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public enum sceneState
{
    SS_MENU,
    SS_GAME,
}

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
        //GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
    }
    public void SetMusicVolume()
    {
        MusicVolume = volumeSliders[1].value;
        Debug.Log(MusicVolume);
        //GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
    }
    public void SetSfxVolume()
    {
        SfxVolume = volumeSliders[2].value;
        Debug.Log(SfxVolume);
    }
    public void PlayMusic()
    {
        //sceneIndex = (sceneState)SceneManager.GetActiveScene().buildIndex;
        GetComponent<AudioSource>().clip = bgms[(int)0];
        GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100;
        GetComponent<AudioSource>().Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        //1초 뒤 실행
        //Invoke("GameStart", 1f);   
        foreach (var item in volumeSliders)
        {
            item.value = 1f;
        }

        PlayMusic();
    }

    void Update()
    {
        GetComponent<AudioSource>().volume = MasterVolume * MusicVolume;
    }

    void GameStart()
    {
        // 볼륨 기본 max 설정 
        foreach (var item in volumeSliders)
        {
            item.value = 1f;
        }
       
        // 전원절약에 대한 설정을 나타내며, 사용자의 입력이 멈춘 시간으로부터 일정시간 후에 화면을 끄는 기능을 허용합니다. 
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //StartCoroutine(UpdateProcess());         
    }

    public IEnumerator UpdateProcess()
    {
        //게임매니저 자체를 싱글톤 (+ dontdistroy obj) 상속해놨음. 
        //DontDestroyOnLoad(this.gameObject);
        yield return null;

        //SceneManager.LoadScene("InGameScene");
        //yield return null;
        //게임물 등급 화면     
        //yield return StartCoroutine(GameRatingScreenStart());
        //GameRatingScreen.SetActive(false);

        //동영상 상영!!!!
        //yield return videoCoroutine = StartCoroutine(OpeningVideo());
        //동영상 상영후 진행
        //OpeningVideo_End();
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
}
