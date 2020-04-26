using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float _time;
    private void Start()
    {
        Destroy(gameObject, _time);
    }
}
