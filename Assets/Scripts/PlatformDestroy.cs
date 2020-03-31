using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    
    public float _timeStay = 5f,_timeBackPlatform = 3;
    public Animator animator;
    public BoxCollider2D boxCollider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")||collision.gameObject.CompareTag("ground"))
        {
            Invoke("DestroyPlatform", _timeStay);
        }
    }
    private void DestroyPlatform()
    {
        animator.SetTrigger("Spawn");
        boxCollider.isTrigger = true;
        Invoke("BackPlatform", _timeBackPlatform);

    }
    private void BackPlatform()
    {
        boxCollider.isTrigger = false;
        gameObject.SetActive(true);
    }
}
