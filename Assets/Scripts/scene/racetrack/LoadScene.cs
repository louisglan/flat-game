using System;
using System.Collections.Generic;
using DefaultNamespace;
using scene.racetrack;
using UnityEngine;

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
    private List<GameObject> _bananas;
    private List<GameObject> _players;

    void Start()
    {
        _bananas = new List<GameObject>();
        _players = new List<GameObject>();
        LoadPlayers();
    }
    
    void OnEnable()
    {
        FinishGameMenu.OnRestartGame += Reset;
    }
    
    void OnDisable()
    {
        FinishGameMenu.OnRestartGame -= Reset;
    }

    private void Reset()
    {
        foreach (var player in _players)
        {
            Destroy(player);
        }

        foreach (var banana in _bananas)
        {
            Destroy(banana);
        }
        LoadPlayers();
    }

    private void LoadPlayers()
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
        _players.Add(player);
        playerMovement.InputNameHorizontalKeyboard = $"Horizontal{playerNumber}Keyboard";
        playerMovement.InputNameHorizontalController = $"Horizontal{playerNumber}Controller";
        var banana = Instantiate(bananaPrefab, spawnPosition + new Vector3(0, 2f, 0), Quaternion.identity);
        var bananaScript = banana.AddComponent<Banana>();
        bananaScript.FinishGameMenuUI = FinishGameMenuUI;
        _bananas.Add(banana);
    }
}
