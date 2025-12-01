using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

//Usage Example
// Give player 2 brains on Level 3 and mark completed
//SaveService.Instance.SetBrains(3, 2);
//SaveService.Instance.SetCompleted(3, true);

// Read
//int brainsOnLevel3 = SaveService.Instance.GetBrains(3);
//bool level3Done = SaveService.Instance.IsCompleted(3);

public class SaveService : MonoBehaviour
{
    public static SaveService Instance { get; private set; }
    public static event System.Action OnDataChanged;
    public SaveData Data { get; private set; } = new SaveData();

    string SavePath => Path.Combine(UnityEngine.Application.persistentDataPath, "save.json");

    void NotifyChanged() => OnDataChanged?.Invoke();

    /*[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Bootstrap()
    {
        if (Instance == null)
            new GameObject("SaveService").AddComponent<SaveService>();
    } */

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Save()
    {
        try
        {
            var json = JsonUtility.ToJson(Data, prettyPrint: true);
            File.WriteAllText(SavePath, json);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"Save failed: {e}");
        }
    }

    public void Load()
    {
        try
        {
            if (File.Exists(SavePath))
            {
                var json = File.ReadAllText(SavePath);
                Data = JsonUtility.FromJson<SaveData>(json) ?? new SaveData();
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"Load failed: {e}");
            Data = new SaveData();
        }
    }

    public int GetBrains(int level) => Data.levelBrains[ClampLevel(level)];
    public bool IsCompleted(int level) => Data.levelCompleted[ClampLevel(level)];

    public void SetBrains(int level, int brains, bool autosave = true)
    {
        int i = Mathf.Clamp(level - 1, 0, 7);
        Data.levelBrains[i] = Mathf.Clamp(brains, 0, 3);
        if (autosave) Save();
        NotifyChanged();
    }

    public void SetCompleted(int level, bool completed = true, bool autosave = true)
    {
        int i = Mathf.Clamp(level - 1, 0, 7);
        Data.levelCompleted[i] = completed;
        if (autosave) Save();
        NotifyChanged();
    }

    static int ClampLevel(int level) => Mathf.Clamp(level - 1, 0, 7);

    // autosave
    void OnApplicationPause(bool pause) { if (pause) Save(); }
    void OnApplicationQuit() => Save();

    public void ClearData()
    {
        if (Data == null) return;

        // Reset level completion
        if (Data.levelCompleted != null)
        {
            for (int i = 0; i < Data.levelCompleted.Length; i++)
                Data.levelCompleted[i] = false;
        }

        // Reset brain counts
        if (Data.levelBrains != null)
        {
            for (int i = 0; i < Data.levelBrains.Length; i++)
                Data.levelBrains[i] = 0;
        }

        // Save the cleared data back to disk
        Save();
}

}
