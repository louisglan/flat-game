using System;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private List<Player> _players;
    public GameObject player1StarPrefab;
    public GameObject player2StarPrefab;
    public GameObject startButton;
    private SpriteSwitcher _startButtonSpriteSwitcher;
    public GameObject backButton;
    private SpriteSwitcher _backButtonSpriteSwitcher;
    private bool _isSinglePlayer;
    private int _startButtonPlayerCount = 0;
    private int _backButtonPlayerCount = 0;
    public static event Action OnReturnToGameModeSelectionMenu;
    
    private void OnEnable()
    {
        _isSinglePlayer = GlobalStateManager.Instance.gameMode == GameMode.SinglePlayer;
        _players ??= new List<Player> {new (1, player1StarPrefab)};
        _startButtonSpriteSwitcher = startButton.GetComponent<SpriteSwitcher>();
        _backButtonSpriteSwitcher = backButton.GetComponent<SpriteSwitcher>();
        Reset();
        if (!_isSinglePlayer)
        {
            _players.Add(new Player(2, player2StarPrefab));
        }
        foreach (var player in _players)
        {
            InitialiseSelectedCharacter(player);
            InitialiseHoveredCharacter(player);
        }
    }

    private void Reset()
    {
        _startButtonPlayerCount = 0;
        _backButtonPlayerCount = 0;
//        _startButtonSpriteSwitcher.UseNormalSprite();
//        _backButtonSpriteSwitcher.UseNormalSprite();
        foreach (var player in _players)
        {
            Destroy(player.Star);
            Destroy(player.HoverStar);
            player.HoveredCharacterIndex = 0;
            player.VerticalPositionIndex = 1;
        }
        if (_players.Count > 1)
        {
            _players.RemoveAt(1);
        }
    }

    void Update()
    {
        if (_startButtonPlayerCount > 0)
        {
            _startButtonSpriteSwitcher.UseHoverSprite();
        } else 
        {
            _startButtonSpriteSwitcher.UseNormalSprite();
        }

        if (_backButtonPlayerCount > 0)
        {
            _backButtonSpriteSwitcher.UseHoverSprite();
        }
        else
        {
            _backButtonSpriteSwitcher.UseNormalSprite();
        }
        foreach (var player in _players)
        {
            var horizontalInputKeyboard = Input.GetAxisRaw($"Horizontal{player.PlayerNumber}Keyboard");
            var horizontalInputController = Input.GetAxisRaw($"Horizontal{player.PlayerNumber}Controller");
            var verticalInputKeyboard = Input.GetAxisRaw($"Vertical{player.PlayerNumber}Keyboard");
            var verticalInputController = Input.GetAxisRaw($"Vertical{player.PlayerNumber}Controller");
            var isSubmit = Input.GetButton($"Submit{player.PlayerNumber}");
            if (isSubmit)
            {
                Submit(player);
            }
            if (horizontalInputKeyboard != 0 || horizontalInputController != 0)
            {
                ChangeHoveredCharacter(player, horizontalInputController != 0 ? horizontalInputController : horizontalInputKeyboard);
            } else if (verticalInputKeyboard != 0 || verticalInputController != 0)
            {
                NavigateVertically(player, verticalInputController != 0 ? verticalInputController : verticalInputKeyboard);
            } else
            {
                player.IsSelecting = false;
            }
        }
    }

    private void Submit(Player player)
    {
        switch (player.VerticalPositionIndex)
        {
            case 0:
            {
                SceneManager.LoadScene("RaceTrack");
                break;
            }
            case 1:
            {
                ChangeSelectedCharacter(player);
                break;
            }
            case 2:
            {
                OnReturnToGameModeSelectionMenu?.Invoke();
                break;
            }
            default: return;
        }
    }

    private void ChangeSelectedCharacter(Player player)
    {
        player.SelectedCharacterIndex = player.HoveredCharacterIndex;
        player.Star.transform.position = characters[player.SelectedCharacterIndex].transform.position;
        PlayerPrefs.SetInt($"selectedCharacterPlayer{player.PlayerNumber}", player.SelectedCharacterIndex);
    }

    private void ChangeHoveredCharacter(Player player, float horizontalInput)
    {
        var isRight = horizontalInput > 0;
        var isLeft = horizontalInput < 0;
        if (player.IsSelecting || player.VerticalPositionIndex != 1)
        {
            return;
        }
        if (isRight)
        {
            NavigateRight(player);
            player.IsSelecting = true;
        } else if (isLeft)
        {
            NavigateLeft(player);
            player.IsSelecting = true;
        }
    }

    private void NavigateRight(Player player)
    {
        if (player.HoveredCharacterIndex == characters.Length - 1)
        {
            return;
        }
        player.HoveredCharacterIndex++;
        player.HoverStar.transform.position = characters[player.HoveredCharacterIndex].transform.position;
    }
    
    private void NavigateLeft(Player player)
    {
        if (player.HoveredCharacterIndex == 0)
        {
            return;
        }
        player.HoveredCharacterIndex--;
        player.HoverStar.transform.position = characters[player.HoveredCharacterIndex].transform.position;
    }
    
    private void NavigateVertically(Player player, float verticalInput)
    {
        var isDown = verticalInput < 0;
        var isUp = verticalInput > 0;
        if (player.IsSelecting)
        {
            return;
        }
        if (isDown)
        {
            NavigateDown(player, verticalInput);
        }
        if (isUp)
        {
            NavigateUp(player, verticalInput);
        }
    }

    private void NavigateDown(Player player, float verticalInput)
    {
        switch (player.VerticalPositionIndex)
        {
            case 2: return;
            case 1:
            {
                player.HoverStar.SetActive(false);
                player.VerticalPositionIndex++;
                _backButtonPlayerCount += 1;
                player.IsSelecting = true;
                break;
            }
            case 0:
            {
                player.HoverStar.SetActive(true);
                player.VerticalPositionIndex++;
                _startButtonPlayerCount -= 1;
                player.IsSelecting = true;
                break;
            }
            default: return;
        }
    }
    
    private void NavigateUp(Player player, float verticalInput)
    {
        switch (player.VerticalPositionIndex)
        {
            case 0: return;
            case 1:
            {
                player.HoverStar.SetActive(false);
                player.VerticalPositionIndex--;
                _startButtonPlayerCount += 1;
                player.IsSelecting = true;
                break;
            }
            case 2:
            {
                player.HoverStar.SetActive(true);
                player.VerticalPositionIndex--;
                _backButtonPlayerCount -= 1;
                player.IsSelecting = true;
                break;
            }
            default: return;
        }
    }

    private void InitialiseSelectedCharacter(Player player)
    {
        player.Star = Instantiate(player.StarPrefab, characters[0].transform.position, Quaternion.identity, transform);
        PlayerPrefs.SetInt($"selectedCharacterPlayer{player.PlayerNumber}", 0);
    }

    private void InitialiseHoveredCharacter(Player player)
    {
        player.HoverStar = Instantiate(player.StarPrefab, characters[0].transform.position, Quaternion.identity, transform);
        ColourUtils.SetTransparency(player.HoverStar, 0.5f);
    }
}
