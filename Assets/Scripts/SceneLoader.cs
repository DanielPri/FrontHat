using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneLoader : MonoBehaviour
{
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("ObstacleAndBGDev");
    }

    public void startGame()
    {
        SceneManager.LoadScene("Intro");
    }
}
