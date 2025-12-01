using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Usage Example:
// Damage: Hit_Points.Instance.DamageCone(1);
// Direct set: Hit_Points.Instance.SetFootballHP(2);
// Check if game over: if (Hit_Points.IsGameOver) { /* stop spawns, etc. */ }

public class Hit_Points : MonoBehaviour
{
    [Header("Current HP")]
    public int Cone_Zombie_Hit_Points = 2;
    public int Football_Zombie_Hit_Points = 3;
    public int Balloon_Zombie_Hit_Points = 1;

    [Header("Overlay")]
    [SerializeField] GameObject Game_Over_Canvas;

    // Static API
    public static bool IsGameOver { get; private set; }
    public static Hit_Points Instance { get; private set; }

    void Awake()
    {
        Instance = this;

        // Reset game state for new scene
        IsGameOver = false;

        if (!Game_Over_Canvas)
        {
            var go = GameObject.Find("Game_Over_Canvas");
            if (go) Game_Over_Canvas = go;
        }

        if (Game_Over_Canvas) Game_Over_Canvas.SetActive(false);
        Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        SetLabel("Cone_Zombie_Hit_Points", Cone_Zombie_Hit_Points);
        SetLabel("Football_Zombie_Hit_Points", Football_Zombie_Hit_Points);
        SetLabel("Balloon_Zombie_Hit_Points", Balloon_Zombie_Hit_Points);
    }

    // API for other scripts
    public void SetConeHP(int value) { Cone_Zombie_Hit_Points = Mathf.Max(0, value); AfterChange(); }
    public void SetFootballHP(int value) { Football_Zombie_Hit_Points = Mathf.Max(0, value); AfterChange(); }
    public void SetBalloonHP(int value) { Balloon_Zombie_Hit_Points = Mathf.Max(0, value); AfterChange(); }

    public void DamageCone(int amount = 1) => SetConeHP(Cone_Zombie_Hit_Points - amount);
    public void DamageFootball(int amount = 1) => SetFootballHP(Football_Zombie_Hit_Points - amount);
    public void DamageBalloon(int amount = 1) => SetBalloonHP(Balloon_Zombie_Hit_Points - amount);

    void AfterChange()
    {
        Refresh();
        CheckGameOver();
    }

    void CheckGameOver()
    {
        if (IsGameOver) return;

        if (Cone_Zombie_Hit_Points <= 0 ||
            Football_Zombie_Hit_Points <= 0 ||
            Balloon_Zombie_Hit_Points <= 0)
        {
            IsGameOver = true;

            if (Game_Over_Canvas) Game_Over_Canvas.SetActive(true);
            else Debug.LogWarning("Game_Over_Canvas not assigned/found.");

            // Optional: Pause game on death
            Time.timeScale = 0f;
        }
    }

    void SetLabel(string childName, int value)
    {
        var t = transform.Find(childName) ?? GameObject.Find(childName)?.transform;
        if (!t) { Debug.LogWarning($"[{name}] Missing UI child: {childName}"); return; }

        var tmp = t.GetComponent<TMP_Text>();
        if (tmp) { tmp.text = value.ToString(); return; }

        var ui = t.GetComponent<Text>();
        if (ui) { ui.text = value.ToString(); return; }

        Debug.LogWarning($"[{name}] No Text/TMP_Text on {childName}");
    }

    // Optional: Reset HP without reloading scene
    public void ResetHP()
    {
        IsGameOver = false;
        Cone_Zombie_Hit_Points = 2;
        Football_Zombie_Hit_Points = 3;
        Balloon_Zombie_Hit_Points = 1;

        if (Game_Over_Canvas) Game_Over_Canvas.SetActive(false);
        Time.timeScale = 1f;

        Refresh();
    }
}
