using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource src;
    public AudioSource music;
    public AudioClip hoverclip, pickedPuzzle, slottedPuzzle;

    private Singleton soundEffectController = Singleton.Instance;

    private void Start()
    {
        
    }
    
    private void Update()
    {
        if(src.isPlaying == false)
        {
            Destroy(transform.gameObject);
        }
        
        // for music
        music.volume = soundEffectController.soundEffects;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        src = GetComponent<AudioSource>();
        src.volume = soundEffectController.soundEffects;
    }

    public void PlayMusic()
    {
        
    }

    public void StopMusic()
    {
        
    }

    public void playHover()
    {
       src.PlayOneShot(hoverclip);
    }
    
    public void pickPuzzle()
    {
       src.PlayOneShot(pickedPuzzle);
    }

    public void slotPuzzle()
    {
       src.PlayOneShot(slottedPuzzle);
    }

}
