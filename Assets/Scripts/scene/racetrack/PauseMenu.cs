using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

namespace scene.racetrack
{
    public class PauseMenu : MonoBehaviour
    {
        public static event Action OnResumeGame;
        public GameObject mainMenuButtonGameObject;
        private Button _mainMenuButtonComponent;
        public GameObject resumeButtonGameObject;
        private Button _resumeButtonComponent;
        private bool _isPlayer1Selecting;
        private bool _isPlayer2Selecting;
        private bool _isMainMenuSelected = true;
        
        void OnEnable()
        {
            _mainMenuButtonComponent = mainMenuButtonGameObject.GetComponent<Button>();
            _resumeButtonComponent = resumeButtonGameObject.GetComponent<Button>();
            Reset();
        }
        
        void Reset()
        {
            EventSystem.current.SetSelectedGameObject(null);
            _mainMenuButtonComponent.Select();
        }
    
        void Update()
        {
            var verticalInput1Keyboard = Input.GetAxisRaw("Vertical1Keyboard");
            var verticalInput2Keybaord = Input.GetAxisRaw("Vertical2Keyboard");
            var verticalInput1Controller = Input.GetAxisRaw("Vertical1Controller");
            var verticalInput2Controller = Input.GetAxisRaw("Vertical2Controller");
            if (verticalInput1Keyboard != 0 || verticalInput2Keybaord != 0 || verticalInput1Controller != 0 || verticalInput2Controller != 0)
            {
                NavigateVertically(_isPlayer1Selecting, verticalInput1Keyboard);
                NavigateVertically(_isPlayer2Selecting, verticalInput2Keybaord);
                NavigateVertically(_isPlayer1Selecting, verticalInput1Controller);
                NavigateVertically(_isPlayer2Selecting, verticalInput2Controller);
            }
            _isPlayer1Selecting = verticalInput1Keyboard != 0 || verticalInput1Controller != 0;
            _isPlayer2Selecting = verticalInput2Keybaord != 0 || verticalInput2Controller != 0;
    
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
                OnResumeGame?.Invoke();
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
                _resumeButtonComponent.Select();
            }
        }
    }
}