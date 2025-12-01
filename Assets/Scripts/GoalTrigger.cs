using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || levelManager == null) return;

        // Get total brains collected from GameManager
        int brainsCollected = GameManager.Instance.brainsCollected;

        // Save completion + collectibles
        levelManager.CompleteLevel(brainsCollected);

        // Reset for next level
        GameManager.Instance.ResetBrains();

        // Exit back to main menu (scene index 0)
        SceneManager.LoadScene(0);
    }
}
