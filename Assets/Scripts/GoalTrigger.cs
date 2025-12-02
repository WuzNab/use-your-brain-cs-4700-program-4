using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject Victory_Canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || levelManager == null) return;

        Time.timeScale = 0f;

        int index = SceneManager.GetActiveScene().buildIndex;

        int brainsCollected = GameManager.Instance.brainsCollected;

        SaveService.Instance.SetBrains(index, brainsCollected);
        SaveService.Instance.SetCompleted(index, true);

        if (Victory_Canvas != null)
            Victory_Canvas.SetActive(true);
        else
            UnityEngine.Debug.LogWarning("Victory_Canvas not assigned on GoalTrigger.");
    }
}
