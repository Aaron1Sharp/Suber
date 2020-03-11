using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerate : MonoBehaviour
{
    public GameObject Cell;
    public Transform Zero;
    public int Height, Widht;
    public void Start()
    {
        Generate();
    }
    public void Generate()
    {
        
        for (int x = 0; x < Widht; x++)
        {
          var cell = Instantiate(Cell, Zero);
            cell.transform.localPosition = new Vector3(x, 0, 0);
        }
    }
}
