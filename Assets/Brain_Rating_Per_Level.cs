using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Brain_Rating_Per_Level : MonoBehaviour
{
    [SerializeField, Range(1, 8)] int level = 1;
    [SerializeField] Sprite collected;
    [SerializeField] Sprite empty;

    void OnEnable()
    {
        Refresh();
        if (SaveService.Instance != null) SaveService.OnDataChanged += Refresh;
    }

    void OnDisable()
    {
        if (SaveService.Instance != null) SaveService.OnDataChanged -= Refresh;
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        int brains = GetBrainsFromSave(level);

        for (int i = 1; i <= 3; i++)
        {
            var t = transform.Find($"Brain_{i}");
            if (!t) continue;

            var img = t.GetComponent<UnityEngine.UI.Image>();
            if (!img) continue;

            img.sprite = (i <= brains) ? collected : empty;
        }
    }

    int GetBrainsFromSave(int levelNum)
    {
        var svc = SaveService.Instance;
        if (svc == null || svc.Data == null || svc.Data.levelBrains == null || svc.Data.levelBrains.Length == 0)
            return 0;

        int idx = Mathf.Clamp(levelNum - 1, 0, svc.Data.levelBrains.Length - 1);
        return Mathf.Clamp(svc.Data.levelBrains[idx], 0, 3);
    }
}
