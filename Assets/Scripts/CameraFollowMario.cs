using UnityEngine;

public class CameraFollowMario : MonoBehaviour
{
#pragma warning disable 0649
#pragma warning disable 0108
    public float speed = 3f;
    public GameObject _followObject;
    public Vector2 followOffset;
    private Vector2 threshold;  
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float _leftLimit, _rightLimit, _upLimit, _bottomLimit;

    void Start()
    {

        threshold = calculateThreshold();
        rigidbody = _followObject.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        transform.position = new Vector3
            (

                Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
                Mathf.Clamp(transform.position.y, _bottomLimit, _upLimit),
                transform.position.z

            );

        Vector2 follow = _followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);
        Vector3 newPosition = transform.position;

        if (Mathf.Abs(xDifference)>=threshold.x)
        {
            newPosition.x = follow.x;
        }

        if (Mathf.Abs(yDifference)>=threshold.y)
        {
            newPosition.y = follow.y;
        }

        float moveSpeed = rigidbody.velocity.magnitude > speed ? rigidbody.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

    }
    private Vector3 calculateThreshold()
    {

        Rect aspect = Camera.main.pixelRect;
        Vector2 vector = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        vector.x -= followOffset.x;
        vector.y -= followOffset.y;
        return vector;

    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));

        
        Gizmos.color = Color.red;
        DrawGizmosLine(_leftLimit, _rightLimit, _upLimit,_upLimit);
        DrawGizmosLine(_leftLimit, _rightLimit, _bottomLimit,_bottomLimit);
        DrawGizmosLine(_leftLimit, _leftLimit, _upLimit,_bottomLimit);
        DrawGizmosLine(_rightLimit, _rightLimit, _upLimit,_bottomLimit);

    }

    public void DrawGizmosLine(float sideA, float sideB,float sideC, float sideD)
    {
        Gizmos.DrawLine(new Vector2(sideA, sideC), new Vector2(sideB, sideD));
    }
}
