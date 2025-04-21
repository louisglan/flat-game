using UnityEngine;

public class MenuEventManager : MonoBehaviour
{
    public GameObject gameModeMenuUI;
    public GameObject characterSelectionMenuUI;

    void OnEnable()
    {
        GameModeSelection.OnGameModeSelection += LoadCharacterSelectionMenu;
        CharacterSelection.OnReturnToGameModeSelectionMenu += LoadGameModeSelectionMenu;
    }

    void OnDisable()
    {
        GameModeSelection.OnGameModeSelection -= LoadCharacterSelectionMenu;
        CharacterSelection.OnReturnToGameModeSelectionMenu -= LoadGameModeSelectionMenu;
    }
    
    private void LoadCharacterSelectionMenu()
    {
        gameModeMenuUI.SetActive(false);
        characterSelectionMenuUI.SetActive(true);
    }
    
    private void LoadGameModeSelectionMenu()
    {
        gameModeMenuUI.SetActive(true);
        characterSelectionMenuUI.SetActive(false);
    }
}
