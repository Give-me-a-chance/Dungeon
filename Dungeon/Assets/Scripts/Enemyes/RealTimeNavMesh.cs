using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class RealTimeNavMesh : MonoBehaviour
{
    NavMeshSurface nav_mesh;
    // Start is called before the first frame update
    void Start()
    {
        nav_mesh = GetComponent<NavMeshSurface>();
        nav_mesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
