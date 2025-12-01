using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || levelManager == null) return;

        int brainsCollected = GameManager.Instance.brainsCollected;

        levelManager.CompleteLevel(brainsCollected);

        // Reset for next level
        GameManager.Instance.ResetBrains();

        // Optionally show victory screen
        // SceneManager.LoadScene("VictoryScreen");
    }
}
