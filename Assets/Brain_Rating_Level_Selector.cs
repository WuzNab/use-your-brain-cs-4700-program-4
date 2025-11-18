using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Brain_Rating_Level_Selector : MonoBehaviour
{
    [SerializeField] Transform brainRatingRoot;
    [SerializeField] Sprite collected;
    [SerializeField] Sprite empty;

    void Start() => Refresh();

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        if (brainRatingRoot == null) brainRatingRoot = transform;

        for (int level = 1; level <= 8; level++)
        {
            SetLevel(level, GetBrainsFromSave(level));
        }
    }

    int GetBrainsFromSave(int level)
    {
        var svc = SaveService.Instance;
        if (svc == null || svc.Data == null || svc.Data.levelBrains == null) return 0;

        int idx = Mathf.Clamp(level - 1, 0, svc.Data.levelBrains.Length - 1);
        return Mathf.Clamp(svc.Data.levelBrains[idx], 0, 3); // 0–3
    }

    void SetLevel(int levelNumber, int rating)
    {
        rating = Mathf.Clamp(rating, 0, 3);

        for (int slot = 1; slot <= 3; slot++)
        {
            var t = brainRatingRoot.Find($"level{levelNumber}_{slot}");
            if (!t) continue;

            var img = t.GetComponent<UnityEngine.UI.Image>();
            if (!img) continue;

            img.sprite = (slot <= rating) ? collected : empty;
        }
    }

    void OnEnable()
    {
        Refresh();
        if (SaveService.Instance != null) SaveService.OnDataChanged += Refresh;
    }

    void OnDisable()
    {
        if (SaveService.Instance != null) SaveService.OnDataChanged -= Refresh;
    }

}
