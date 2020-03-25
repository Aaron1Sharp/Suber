using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float BackGroundSize;
 
    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 11;
    private int leftIndex, rightIndex;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) 
        {
            ScrollLeft();
        }
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - BackGroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }
    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + BackGroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
