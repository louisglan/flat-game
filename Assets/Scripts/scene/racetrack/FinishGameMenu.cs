using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

namespace scene.racetrack
{
    public class FinishGameMenu : MonoBehaviour
    {
        public static event Action OnRestartGame;
        public GameObject mainMenuButtonGameObject;
        private Button _mainMenuButtonComponent;
        public GameObject restartButtonGameObject;
        private Button _restartButtonComponent;
        private bool _isPlayer1Selecting;
        private bool _isPlayer2Selecting;
        private bool _isMainMenuSelected = true;
        
        void OnEnable()
            {
                _mainMenuButtonComponent = mainMenuButtonGameObject.GetComponent<Button>();
                _restartButtonComponent = restartButtonGameObject.GetComponent<Button>();
                Reset();
            }
        
        void Reset()
        {
            EventSystem.current.SetSelectedGameObject(null);
            _mainMenuButtonComponent.Select();
        }
    
        void Update()
        {
            var verticalInput1 = Input.GetAxisRaw("Vertical1");
            var verticalInput2 = Input.GetAxisRaw("Vertical2");
            if (verticalInput1 != 0 || verticalInput2 != 0)
            {
                NavigateVertically(_isPlayer1Selecting, verticalInput1);
                NavigateVertically(_isPlayer2Selecting, verticalInput2);
            }
            _isPlayer1Selecting = verticalInput1 != 0;
            _isPlayer2Selecting = verticalInput2 != 0;
    
            var isSubmit = Input.GetButton("Submit1") || Input.GetButton("Submit2");
            if (isSubmit)
            {
                Submit();
            }
        }

        private void Submit()
        {
            if (_isMainMenuSelected)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Time.timeScale = 1f;
                GlobalStateManager.Instance.isGameOver = false;
                OnRestartGame?.Invoke();
            }
            Reset();
        }
    
        void NavigateVertically(bool isPlayerSelecting, float verticalInput)
        {
            if (isPlayerSelecting || verticalInput == 0)
            {
                return;
            }
            _isMainMenuSelected = !_isMainMenuSelected;
            EventSystem.current.SetSelectedGameObject(null);
            if (_isMainMenuSelected)
            {
                _mainMenuButtonComponent.Select();
            }
            else
            {
                _restartButtonComponent.Select();
            }
        }
    }
}