using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BrainPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectBrain();
            Destroy(gameObject); // remove collectible
        }
    }
}
