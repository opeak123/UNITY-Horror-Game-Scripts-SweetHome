using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audiomixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] public GameObject MusicMark;
    [SerializeField] public GameObject SfxMark;
    [SerializeField] public Text musictxt;
    [SerializeField] public Text sfxtxt;

    const string MIXER_MUSIC = "BackMusicVolume";
    const string MIXER_SFX = "SfxVolume";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
    }

    void SetMusicVolume(float value1)
    {
        audiomixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value1) * 20);
        musictxt.text = Mathf.RoundToInt(value1 * 100).ToString();
    }

    void SetSfxVolume(float value2)
    {
        audiomixer.SetFloat(MIXER_SFX ,Mathf.Log10(value2) * 20);
        sfxtxt.text = Mathf.RoundToInt(value2 * 100).ToString();
    }

    public void MuteMusicToggle(bool musicmuted)
    {
        if(musicmuted)
            musicSlider.value = 0.0001f;
        else
            musicSlider.value = 1;
        
    }
    public void MuteSfxToggle(bool sfxmuted)
    {
        if (sfxmuted)
            sfxSlider.value = 0.0001f;
        
        else
            sfxSlider.value = 1;
    }
}
