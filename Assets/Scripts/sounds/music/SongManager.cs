using scene.racetrack;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    [SerializeField] private GameObject songIntro;
    [SerializeField] private GameObject songLoop;
    private AudioSource _songIntroAudioSource;
    private AudioSource _songLoopAudioSource;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        FinishGameMenu.OnReturnToMenu += Reset;
    }

    private void OnDisable()
    {
        FinishGameMenu.OnReturnToMenu -= Reset;
    }

    private void Reset()
    {
        _songLoopAudioSource.Stop();
        _songIntroAudioSource.Play();
    }

    private void Start()
    {
        _songIntroAudioSource = songIntro.GetComponent<AudioSource>();
        _songLoopAudioSource = songLoop.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_songIntroAudioSource.isPlaying && !_songLoopAudioSource.isPlaying)
        {
            _songLoopAudioSource.Play();
        }
    }
}
