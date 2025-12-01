using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level settings")]
    [Tooltip("1-based level index (e.g., Level 1 = 1, Level 2 = 2)")]
    public int levelIndex = 1;

    public void CompleteLevel(int brainsCollected = 0)
    {
        // Save completion
        SaveService.Instance.SetCompleted(levelIndex, true);

        // Save brains collected (optional)
        SaveService.Instance.SetBrains(levelIndex, brainsCollected);

        Debug.Log($"Level {levelIndex} marked completed with {brainsCollected} brains!");
    }
}
