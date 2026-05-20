using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void startGame(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
