using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    // VARIABLES
    public AudioMixer mixer;

    // FUNCTIONS
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }
}
