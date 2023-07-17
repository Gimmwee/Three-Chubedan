using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        _musicSlider.value = 0;
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SfxVolume()
    {
        AudioManager.Instance.SfxVolume(_sfxSlider.value);
    }
}
