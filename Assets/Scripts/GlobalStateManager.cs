using UnityEngine;

namespace DefaultNamespace
{
    public class GlobalStateManager : MonoBehaviour
    {
        public static GlobalStateManager Instance { get; private set; }
        
        public GameMode gameMode = GameMode.SinglePlayer;
        public bool isGameOver;
        public float highScore;
        public int selectedCharacterPlayer1;
        public int selectedCharacterPlayer2;

        private void Awake()
        {
            ResetState();
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
            highScore = 10000f;
            selectedCharacterPlayer1 = 0;
            selectedCharacterPlayer2 = 0;
        }
    }
}