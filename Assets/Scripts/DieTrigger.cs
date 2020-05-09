using UnityEngine;

public class DieTrigger : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private HealthBar HealthBar;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           HealthBar.TakeHealth();
        }
    }
}
