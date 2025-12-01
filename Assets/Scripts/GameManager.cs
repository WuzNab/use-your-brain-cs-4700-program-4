using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int brainsCollected = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectBrain()
    {
        brainsCollected++;
        brainsCollected = Mathf.Clamp(brainsCollected, 0, 3); // max 3 per level
        Debug.Log($"GameManager brains count: {brainsCollected}");
    }

    // ✅ Add this method to clear the count after saving
    public void ResetBrains()
    {
        brainsCollected = 0;
        Debug.Log("Brains reset for next level");
    }
}
