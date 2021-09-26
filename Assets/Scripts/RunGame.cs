using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.gameObject.SetActive(true);
        SoundManager.Instance.gameObject.SetActive(true);
        LoadingSceneController.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
