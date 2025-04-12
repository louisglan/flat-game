using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    public GameObject[] characters;
    public Vector3 spawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = Instantiate(characters[PlayerPrefs.GetInt("selectedCharacter")], spawnPosition, Quaternion.identity);
        player.AddComponent<PlayerMovement>();
    }
}
