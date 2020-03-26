using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public bool _scrolling, _paralax;
    public float _backGroundSize, _paralaxSpeed;
 
    Transform CameraTransform;
    Transform[] Layers;
    float _viewZone = 11, _lastCameraX;
    int _leftIndex, _rightIndex;

    void Start()
    {

        CameraTransform = Camera.main.transform;
        _lastCameraX = CameraTransform.position.x;
        Layers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            Layers[i] = transform.GetChild(i);
        }

        _leftIndex = 0;
        _rightIndex = Layers.Length - 1;

    }
    void Update()
    {

        if (_paralax)
        {
            float deltaX = CameraTransform.position.x - _lastCameraX;
            transform.position += Vector3.right * (deltaX * _paralaxSpeed);
        }

        _lastCameraX = CameraTransform.position.x;

        if (_scrolling)
        {
            if (CameraTransform.position.x < (Layers[_leftIndex].transform.position.x + _viewZone))
            {
                ScrollLeft();
            }
            if (CameraTransform.position.x > (Layers[_rightIndex].transform.position.x - _viewZone))
            {
                ScrollRight();
            }
        }

    }

    void ScrollLeft()
    {

        Layers[_rightIndex].position = Vector3.right * (Layers[_leftIndex].position.x - _backGroundSize);
        _leftIndex = _rightIndex;
        _rightIndex--;

        if (_rightIndex < 0)
            _rightIndex = Layers.Length - 1;  

    }

    void ScrollRight()
    {

        Layers[_leftIndex].position = Vector3.right * (Layers[_rightIndex].position.x + _backGroundSize);
        _rightIndex = _leftIndex;
        _leftIndex++;

        if (_leftIndex == Layers.Length)
            _leftIndex = 0;

    }
}
