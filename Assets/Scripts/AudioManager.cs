using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioSource backgroundMusic;
    public AudioSource playerSFXSource;
    public AudioSource worldSFXSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }
    

    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }

    public void PlayPlayerSFX(AudioClip clip)
    {
        playerSFXSource.clip = clip;
        playerSFXSource.Play();
    }

    public void PlayWorldSFX(AudioClip clip)
    {
        worldSFXSource.clip = clip;
        worldSFXSource.Play();
    }
}
