using System;
using scene.racetrack;
using UnityEngine;

public class BanannabelleAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public static event Action OnBanannabelleAnimationEnd;
    
    void OnEnable()
    {
        Banana.OnGameOver += StartAnimation;
        FinishGameMenu.OnRestartGame += Reset;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void OnDisable()
    {
        Banana.OnGameOver -= StartAnimation;
        FinishGameMenu.OnRestartGame -= Reset;
    }

    void Reset()
    {
        _spriteRenderer.enabled = false;
    }

    void StartAnimation()
    {
        Debug.Log("StartAnimation");
         _spriteRenderer.enabled = true;
        _animator.SetTrigger("TrBanannabelle");
    }

    void OnLastFrame()
    {
        OnBanannabelleAnimationEnd?.Invoke();
    }
}
