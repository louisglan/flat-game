using UnityEngine;

public class RaceTrackEventManager : MonoBehaviour
{
    [SerializeField] private GameObject finishGameMenuUI;
    [SerializeField] private GameObject banannabelle;

    void OnEnable()
    {
        BanannabelleAnimation.OnBanannabelleAnimationEnd += LoadFinishGameMenu;
    }

    void OnDisable()
    {
        BanannabelleAnimation.OnBanannabelleAnimationEnd -= LoadFinishGameMenu;
    }

    private void LoadFinishGameMenu()
    {
        finishGameMenuUI.SetActive(true);
    }
}
