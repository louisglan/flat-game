using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class LoadScene : MonoBehaviour
{
    public GameObject[] characters;
    public Vector3 spawnPositionSinglePlayerMode;
    public Vector3 spawnPositionMultiPlayerModePlayer1;
    public Vector3 spawnPositionMultiPlayerModePlayer2;
    public GameObject bananaPrefab;
    public GameObject multiPlayerGround;
    public GameObject singlePlayerGround;
    public GameObject FinishGameMenuUI;
    
    void Start()
    {
        var isSinglePlayerMode = GlobalStateManager.Instance.gameMode == GameMode.SinglePlayer;
        if (isSinglePlayerMode)
        {
            singlePlayerGround.SetActive(true);
            multiPlayerGround.SetActive(false);
            InstantiateCharacterAndBanana("1", spawnPositionSinglePlayerMode);
        } else
        {
            singlePlayerGround.SetActive(false);
            multiPlayerGround.SetActive(true);
            InstantiateCharacterAndBanana("1", spawnPositionMultiPlayerModePlayer1);
            InstantiateCharacterAndBanana("2", spawnPositionMultiPlayerModePlayer2);
        }
    }

    private void InstantiateCharacterAndBanana(string playerNumber, Vector3 spawnPosition)
    {
        var player = Instantiate(characters[PlayerPrefs.GetInt($"selectedCharacterPlayer{playerNumber}")], spawnPosition, Quaternion.identity);
        var playerMovement = player.AddComponent<PlayerMovement>();
        playerMovement.SetInputNameHorizontal($"Horizontal{playerNumber}");
        var banana = Instantiate(bananaPrefab, spawnPosition + new Vector3(0, 2f, 0), Quaternion.identity);
        var bananaScript = banana.AddComponent<Banana>();
        bananaScript.FinishGameMenuUI = FinishGameMenuUI;
    }
}
