using UnityEngine;

public class CheerEffect : MonoBehaviour
{
    [SerializeField] private AudioClip cheerEffect;
    private AudioSource _audioSource;
    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        Banana.OnGameOver += PlayCheerEffect;
    }

    private void OnDisable()
    {
        Banana.OnGameOver -= PlayCheerEffect;
    }

    void PlayCheerEffect()
    {
        _audioSource.PlayOneShot(cheerEffect);
    }
}
