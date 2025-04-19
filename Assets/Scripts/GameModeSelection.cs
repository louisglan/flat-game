using DefaultNamespace;
using DefaultNamespace.Utils;
using UnityEngine;

public class GameModeSelection : MonoBehaviour
{
    public GameObject singlePlayerButton;
    public GameObject multiPlayerButton;
    private bool _isSinglePlayer = true;
    private bool _isPlayer1Selecting;
    private MenuLoader _menuLoader;
    private bool _isSubmitting;

    
    void OnEnable()
    {
        Reset();
        _menuLoader = GetComponent<MenuLoader>();
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
        var verticalInput1 = Input.GetAxis("Vertical1");
        if (verticalInput1 != 0)
        {
            NavigateVertically(verticalInput1);
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
            _menuLoader.LoadCharacterSelectionMenu(_isSinglePlayer);
        }
    }

    void NavigateVertically(float verticalInput)
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
