using UnityEngine;
using UnityEngine.Audio;

public class SplatEffect : MonoBehaviour
{
    [SerializeField] private AudioClip[] splatSounds;
    private AudioSource _audioSource;

    void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        MenuSubmitEvent.OnSubmit += MakeSplatSound;
    }

    private void OnDisable()
    {
        MenuSubmitEvent.OnSubmit -= MakeSplatSound;
    }

    void MakeSplatSound()
    {
        int index = Random.Range(0, splatSounds.Length);
        _audioSource.PlayOneShot(splatSounds[index]);
    }
}
