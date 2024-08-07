using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsManager : MonoBehaviour
{
    [SerializeField] private Slider soundEffectSlider;
    private Singleton singleton = Singleton.Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if(!PlayerPrefs.HasKey("soundEffectVolume"))
        {
           PlayerPrefs.SetFloat("soundEffectVolume", 1);
           Load();
        }
        else
        {
           Load();
        }
    }

    public void changeVolume()
    {
        singleton.soundEffects = soundEffectSlider.value;
        Save();
    }

    //save the volume settings
    private void Load()
    {
        soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectVolume");
        singleton.soundEffects = soundEffectSlider.value;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectSlider.value);
    }

    public void closeOptions()
    {
        this.gameObject.SetActive(false);
    }

}
