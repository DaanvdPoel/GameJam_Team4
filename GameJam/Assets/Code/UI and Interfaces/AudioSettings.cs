using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : SettingsMenu
{
    // Code based on https://www.youtube.com/watch?v=yWCHaTwVblk&ab_channel=Hooson


    [SerializeField] private Slider             _musicVolumeSlider;                 // Slider object responsible for setting the ingame sound volume.
    [SerializeField] private TextMeshProUGUI    _musicVolumeText;                   // Text showing the current volume of the ingame sound.




    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            LoadSettings();
        }
        else
        {
            LoadSettings();
        }
    }




    public void ChangeVolume()
    {
        AudioManager.instance.SetMusicVolume(_musicVolumeSlider.value);
        AudioManager.instance.SetSoundEffectVolume(_musicVolumeSlider.value);
        SaveSettings();

        _musicVolumeText.text = Mathf.RoundToInt(_musicVolumeSlider.value * 100).ToString(); 
    }




    private void LoadSettings()
    {
        _musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        _musicVolumeText.text = Mathf.RoundToInt(_musicVolumeSlider.value * 100).ToString();
    }


    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", _musicVolumeSlider.value);
    }
}
