using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundMusicController : MonoBehaviour
{
    [Header("Referencias de Audio")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip backgroundMusic;
    
    [Header("Configuración UI")]
    [SerializeField] private Button musicToggleButton;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Image musicButtonImage;
    
    [Header("Configuración")]
    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 0.5f;
    [SerializeField] private bool playOnStart = true;
    [SerializeField] private bool dontDestroyOnLoad = true;
    
    private bool isMusicPlaying = true;
    private static BackgroundMusicController instance;
    
    void Awake()
    {
        // Singleton para que la música no se reinicie al cambiar escena
        if (instance == null)
        {
            instance = this;
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // Crear AudioSource si no existe
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }
        
        SetupAudioSource();
        LoadMusicSettings();
    }
    
    void Start()
    {
        if (playOnStart && isMusicPlaying)
        {
            PlayBackgroundMusic();
        }
        
        SetupUI();
    }
    
    void SetupAudioSource()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.playOnAwake = false;
    }
    
    void SetupUI()
    {
        if (musicToggleButton != null)
        {
            musicToggleButton.onClick.AddListener(ToggleMusic);
            
            // Actualizar imagen del botón
            UpdateButtonImage();
        }
    }
    
    void LoadMusicSettings()
    {
        // Cargar preferencias guardadas
        isMusicPlaying = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
    
    void SaveMusicSettings()
    {
        PlayerPrefs.SetInt("MusicEnabled", isMusicPlaying ? 1 : 0);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }
    
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic == null)
        {
            Debug.LogWarning("No hay música asignada para reproducir");
            return;
        }
        
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
            isMusicPlaying = true;
            UpdateButtonImage();
        }
    }
    
    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            isMusicPlaying = false;
            UpdateButtonImage();
        }
    }
    
    public void ToggleMusic()
    {
        if (isMusicPlaying)
        {
            StopBackgroundMusic();
        }
        else
        {
            PlayBackgroundMusic();
        }
        
        SaveMusicSettings();
    }
    
    void UpdateButtonImage()
    {
        if (musicButtonImage != null && musicOnSprite != null && musicOffSprite != null)
        {
            musicButtonImage.sprite = isMusicPlaying ? musicOnSprite : musicOffSprite;
        }
    }
    
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        musicSource.volume = musicVolume;
        SaveMusicSettings();
    }
    
    public bool IsMusicPlaying()
    {
        return isMusicPlaying;
    }
    
    void OnDestroy()
    {
        if (musicToggleButton != null)
        {
            musicToggleButton.onClick.RemoveListener(ToggleMusic);
        }
        
        SaveMusicSettings();
    }
}