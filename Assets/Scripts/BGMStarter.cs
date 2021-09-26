using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStarter : MonoBehaviour
{
    public int iThisSceneBGM = 0;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(iThisSceneBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
