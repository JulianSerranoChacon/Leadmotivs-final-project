using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private int nextScene = 0;

    public int getNextScene()
    {
        return nextScene;
    }

    public void setNextScene(int nS)
    {
        nextScene = nS;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
