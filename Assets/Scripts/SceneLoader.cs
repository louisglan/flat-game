using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene("Race Track");
    }
}
