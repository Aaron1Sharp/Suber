using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CustomTilemap;
namespace CustomTilemap
{
    [CustomEditor(typeof(TerrainGenerate))]
    public class TerrainGeneratorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generator!"))
            {
                ((TerrainGenerate)target).GenerateAndRender();
            }
            if (GUILayout.Button("Clear!"))
            {
                ((TerrainGenerate)target).GetComponent<TilemapRender>().Clear();
            }
        }
    }
}
