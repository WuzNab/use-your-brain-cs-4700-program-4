using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BrainRatingUI : MonoBehaviour
{
    [SerializeField] Transform brainRatingRoot;
    [SerializeField] Sprite collected;
    [SerializeField] Sprite empty;

    public int level1, level2, level3, level4, level5, level6, level7, level8; // 0–3

    void Start()
    {
        if (brainRatingRoot == null) brainRatingRoot = transform;

        SetLevel(1, level1);
        SetLevel(2, level2);
        SetLevel(3, level3);
        SetLevel(4, level4);
        SetLevel(5, level5);
        SetLevel(6, level6);
        SetLevel(7, level7);
        SetLevel(8, level8);
    }

    void SetLevel(int levelNumber, int rating)
    {
        rating = Mathf.Clamp(rating, 0, 3);

        for (int slot = 1; slot <= 3; slot++)
        {
            Transform t = brainRatingRoot.Find($"level{levelNumber}_{slot}");
            if (!t) continue;

            UnityEngine.UI.Image img = t.GetComponent<UnityEngine.UI.Image>();
            if (!img) continue;

            img.sprite = (slot <= rating) ? collected : empty;
        }
    }
}
