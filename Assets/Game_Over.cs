using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
   public void Exit()
   {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
   }

   public void Restart()
   {
       Time.timeScale = 1f;
       var current = SceneManager.GetActiveScene();
       SceneManager.LoadScene(current.buildIndex);
   }

   public void PreviousLevel()
   {
       int current = SceneManager.GetActiveScene().buildIndex;
       int prev = current - 1;

       if (prev >= 0)
       {
            Time.timeScale = 1f;
            SceneManager.LoadScene(prev);
       }
   }
}
