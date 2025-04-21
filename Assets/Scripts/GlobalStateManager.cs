using UnityEngine;

namespace DefaultNamespace
{
    public class GlobalStateManager : MonoBehaviour
    {
        public static GlobalStateManager Instance { get; private set; }
        
        public GameMode gameMode = GameMode.SinglePlayer;
        public bool isGameOver;
        public int selectedCharacterPlayer1;
        public int selectedCharacterPlayer2;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void ResetState()
        {
            gameMode = GameMode.SinglePlayer;
            isGameOver = false;
            selectedCharacterPlayer1 = 0;
            selectedCharacterPlayer2 = 0;
        }
    }
}