using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public int brainsCollected = 0;

    public void CollectBrain()
    {
        brainsCollected++;
        brainsCollected = Mathf.Clamp(brainsCollected, 0, 3); // max 3 per level
    }
}
