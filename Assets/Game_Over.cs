using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
   public void Exit()
   {
       SceneManager.LoadScene(0);
   }

   public void Restart()
   {
       var current = SceneManager.GetActiveScene();
       SceneManager.LoadScene(current.buildIndex);
   }

   public void PreviousLevel()
   {
       int current = SceneManager.GetActiveScene().buildIndex;
       int prev = current - 1;

       if (prev >= 0)
       {
           SceneManager.LoadScene(prev);
       }
   }
}
