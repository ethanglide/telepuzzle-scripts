using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSliders : MonoBehaviour
{
    public AudioMixer audioMixer;

    float volume;

    private void Awake()
    {       
        if (gameObject.name == "MasterSlider")
        {
            audioMixer.GetFloat("MasterVolume", out volume);
        }
        else if (gameObject.name == "MusicSlider")
        {
            audioMixer.GetFloat("MusicVolume", out volume);
        }
        else if (gameObject.name == "SfxSlider")
        {
            audioMixer.GetFloat("SfxVolume", out volume);
        }

        gameObject.GetComponent<Slider>().value = volume;
        gameObject.GetComponentInChildren<TMPro.TMP_Text>().text = (volume + 80).ToString("0");

    }

    public void SetMasterVolume(float vol)
    {
        audioMixer.SetFloat("MasterVolume", vol);
        gameObject.GetComponentInChildren<TMPro.TMP_Text>().text = (vol + 80).ToString("0");
    }
    public void SetMusicVolume(float vol)
    {
        audioMixer.SetFloat("MusicVolume", vol);
        gameObject.GetComponentInChildren<TMPro.TMP_Text>().text = (vol + 80).ToString("0");
    }
    public void SetSfxVolume(float vol)
    {
        audioMixer.SetFloat("SfxVolume", vol);
        gameObject.GetComponentInChildren<TMPro.TMP_Text>().text = (vol + 80).ToString("0");
    }
}
