using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;


public class GameManager : MonoSingleton<GameManager>
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject goGameManager = new GameObject("GameManager");
                DontDestroyOnLoad(goGameManager);
                goGameManager.AddComponent(typeof(GameManager));
                instance = (GameManager)goGameManager.GetComponent(typeof(GameManager));
            }
            return instance;
        }
    }




    [SerializeField]
    public SpriteAtlas BGAtlas;
    //public Dictionary<string, Sprite> dicBGSprite = new Dictionary<string, Sprite>();

   

    public AudioClip[] bgms;
    //public static sceneState sceneIndex;
    

    public void Quit()
    {
        Application.Quit();
    }




    // start is called before the first frame update
    void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    //void Update()
    //{
    //    GetComponent<AudioSource>().volume = MasterVolume * MusicVolume;
    //}

    //public Sprite GetSprite(string strKey)
    //{
    //    if (dicBGSprite.ContainsKey(strKey))
    //        return dicBGSprite[strKey];
    //    else
    //    {
    //        Sprite tempSprite = null;
    //        tempSprite = BGAtlas.GetSprite(strKey);

    //        if (tempSprite != null)
    //            dicBGSprite.Add(strKey, tempSprite);

    //        return tempSprite;
    //    }
    //}
    public void LoadScene(int sceneIndex)
    {
        SceneIndex sceneNum = (SceneIndex)sceneIndex;
        LoadingSceneController.LoadScene(sceneNum.ToString());
    }
}
