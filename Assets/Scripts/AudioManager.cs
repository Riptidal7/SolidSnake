using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioSource backgroundMusicSource;
    public AudioSource snakeDyingSource;
    public AudioSource menuMusicSource;

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
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.Play();
    }

    public void PlaySnakeDyingSFX(AudioClip clip)
    {
        snakeDyingSource.clip = clip;
        snakeDyingSource.Play();
    }

    public void PlayMenuMusic(AudioClip clip)
    {
        menuMusicSource.clip = clip;
        menuMusicSource.Play();
    }
    
    public void StopMusic()
    {
        backgroundMusicSource.Stop();
        menuMusicSource.Stop();
        snakeDyingSource.Stop();
    }
}
