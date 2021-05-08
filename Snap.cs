using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    [SerializeField] private Vector3 gridSize = default;

    

    private void OnDrawGizmos()
    {
        SnapToGrid2();
        
    }

    


    private void SnapToGrid()
    {
        var position = new Vector3(
            Mathf.RoundToInt(this.transform.position.x),
            Mathf.RoundToInt(this.transform.position.y),
            Mathf.RoundToInt(this.transform.position.z)
            );
        this.transform.position = position;

    }

    private void SnapToGrid2()
    {
        var position = new Vector3(
            Mathf.RoundToInt(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
            Mathf.RoundToInt(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
            Mathf.RoundToInt(this.transform.position.z / this.gridSize.z) * this.gridSize.x
            );
        this.transform.position = position;
    }
}
