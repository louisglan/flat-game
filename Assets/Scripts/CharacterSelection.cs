using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter;
    public GameObject starPrefab;
    public GameObject star;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        star = Instantiate(starPrefab, characters[selectedCharacter].transform.position, Quaternion.identity);
        selectedCharacter = 0;
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        for (var i = 0; i < characters.Length; i++)
        {
            var md = characters[i].AddComponent<MouseDetect>();
            md.objectIndex = i;
            md.onMouseEnter = OnMouseEnterObject;
        }
    }

    void OnMouseEnterObject(int index)
    {
        star.transform.position = characters[index].transform.position;
        selectedCharacter = index;
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
