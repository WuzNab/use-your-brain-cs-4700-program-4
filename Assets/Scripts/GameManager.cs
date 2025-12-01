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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectBrain()
    {
        brainsCollected++;
        brainsCollected = Mathf.Clamp(brainsCollected, 0, 3);
        Debug.Log($"GameManager brains count: {brainsCollected}");
    }

    public void ResetBrains()
    {
        brainsCollected = 0;
        Debug.Log("Brains reset for next level");
    }

    //  Debug helper
    [ContextMenu("Clear Save")]
    public void ClearSave()
    {
        SaveService.Instance.ClearData();
        Debug.Log("Save data cleared");
    }
}
