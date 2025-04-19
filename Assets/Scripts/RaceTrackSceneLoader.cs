using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceTrackSceneLoader : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("RaceTrack");
    }
}