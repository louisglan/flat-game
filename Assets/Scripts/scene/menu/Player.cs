using UnityEngine;

namespace DefaultNamespace
{
    public class Player
    {
        public readonly int PlayerNumber;
        public int SelectedCharacterIndex = 0;
        public int HoveredCharacterIndex = 0;
        public readonly GameObject StarPrefab;
        public GameObject Star;
        public GameObject HoverStar;
        public bool IsSelecting = false;
        public int VerticalPositionIndex = 1;
        
        public Player(int playerNumber, GameObject starPrefab)
        {
            PlayerNumber = playerNumber;
            StarPrefab = starPrefab;
        }
    }
}