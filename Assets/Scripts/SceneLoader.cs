using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Race Track");
    }
}