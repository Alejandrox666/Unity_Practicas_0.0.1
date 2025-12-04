using UnityEngine;

public class BackgroundMusicController2 : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private float volume = 0.5f;
    
    private AudioSource audioSource;
    
    void Start()
    {
        // Configurar audio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        
        if (menuMusic != null)
        {
            audioSource.clip = menuMusic;
            audioSource.loop = true;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
    
    public bool IsMusicPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
    
    public void StopBackgroundMusic()
    {
        if (audioSource != null)
            audioSource.Stop();
    }
    
    public void PlayBackgroundMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }
}