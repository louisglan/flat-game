using UnityEngine;

public class GameModeSelectionMenuLoader : MonoBehaviour
{
    public GameObject gameModeSelectionMenu;
    public GameObject mainMenu;
    void OnMouseDown()
    {
        gameModeSelectionMenu.SetActive(true);
        mainMenu.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteSwitcher>().normalSprite;
    }
}
