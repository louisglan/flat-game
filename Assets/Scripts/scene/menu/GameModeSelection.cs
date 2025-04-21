using System;
using DefaultNamespace;
using DefaultNamespace.Utils;
using UnityEngine;

public class GameModeSelection : MonoBehaviour
{
    public GameObject singlePlayerButton;
    public GameObject multiPlayerButton;
    private bool _isSinglePlayer = true;
    private bool _isPlayer1Selecting;
    private bool _isSubmitting;
    public static event Action OnGameModeSelection;

    
    void OnEnable()
    {
        Reset();
    }

    void Reset()
    {
        ColourUtils.SetTransparency(singlePlayerButton, 1f);
        ColourUtils.SetTransparency(multiPlayerButton, 0.5f);
        _isSinglePlayer = true;
        _isSubmitting = true;
    }

    void Update()
    {
        var verticalInput1Keyboard = Input.GetAxisRaw("Vertical1Keyboard");
        var verticalInput1Controller = Input.GetAxisRaw("Vertical1Controller");
        if (verticalInput1Keyboard != 0 || verticalInput1Controller != 0)
        {
            NavigateVertically();
            _isPlayer1Selecting = true;
        }
        else
        {
            _isPlayer1Selecting = false;
        }

        var isSubmit = Input.GetButton("Submit1");
        if (!isSubmit)
        {
            _isSubmitting = false;
        }
        if (isSubmit && !_isSubmitting)
        {
            GlobalStateManager.Instance.gameMode = _isSinglePlayer ? GameMode.SinglePlayer : GameMode.MultiPlayer;
            OnGameModeSelection?.Invoke();
            gameObject.SetActive(false);
        }
    }

    void NavigateVertically()
    {
        
        if (_isPlayer1Selecting)
        {
            return;
        }
        _isSinglePlayer = !_isSinglePlayer;
        ColourUtils.SetTransparency(singlePlayerButton, _isSinglePlayer ? 1f : 0.5f);
        ColourUtils.SetTransparency(multiPlayerButton, _isSinglePlayer ? 0.5f : 1f);
    }
}
