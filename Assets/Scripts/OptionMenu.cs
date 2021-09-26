using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider[] Sliders = new Slider[3];

    public void OnEnable()
    {
        Sliders[0].value = SoundManager.Instance.MasterVolume;
        Sliders[1].value = SoundManager.Instance.MusicVolume;
        Sliders[2].value = SoundManager.Instance.SfxVolume;
    }

    public void SetVolume(int iArrayNum)
    { 
        switch(iArrayNum)
        {
            case 0: SoundManager.Instance.SetMasterVolume(Sliders[iArrayNum].value); break;
            case 1: SoundManager.Instance.SetMusicVolume(Sliders[iArrayNum].value); break;
            case 2: SoundManager.Instance.SetSfxVolume(Sliders[iArrayNum].value); break;
        }
    }

    public void OpenUI()
    {
        this.gameObject.SetActive(true);
    }
    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }
}
