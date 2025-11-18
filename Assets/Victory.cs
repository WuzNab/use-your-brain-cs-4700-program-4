using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void Replay()
    {
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;

        if (next >= 8)
        {
            SceneManager.LoadScene(next);
        }
    }
}
