using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void Replay()
    {
        Time.timeScale = 1f;
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;

        Time.timeScale = 1f;

        SaveService.Instance.SetCompleted(current, true);

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next); // load next level
        }
        else
        {
            SceneManager.LoadScene(0); // no more levels, return to menu
        }
    }
}
