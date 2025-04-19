using UnityEngine;

namespace DefaultNamespace
{
    public class MenuLoader : MonoBehaviour
    {
        public GameObject gameModeMenuUI;
        public GameObject characterSelectionMenuUI;
        
        public void LoadGameModeMenu()
        {
            Debug.Log("loading game mode menu");
            gameModeMenuUI.SetActive(true);
            characterSelectionMenuUI.SetActive(false);
        }

        public void LoadCharacterSelectionMenu(bool isSinglePlayer)
        {
            GlobalStateManager.Instance.gameMode = isSinglePlayer ? GameMode.SinglePlayer : GameMode.MultiPlayer;
            characterSelectionMenuUI.SetActive(true);
            gameModeMenuUI.SetActive(false);
        }
    }
}