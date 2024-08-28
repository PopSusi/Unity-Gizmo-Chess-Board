using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChessBoardScript : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int x = 0; x < 9; x++)
        {
            Gizmos.DrawLine(new Vector3(x, 0, 0), new Vector3(x, 0, 8));
        }
        for (int z = 0; z < 9; z++)
        {
            Gizmos.DrawLine(new Vector3(0, 0, z), new Vector3(8, 0, z));
        }
    }
}

