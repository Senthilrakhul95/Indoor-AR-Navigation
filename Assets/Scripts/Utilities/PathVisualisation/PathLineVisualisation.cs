using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathLineVisualisation : MonoBehaviour
{

    [SerializeField]
    private NavigationController navigationController;
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private Vector3[] calculatedPathAndOffset;

    private void Update()
    {
        path = navigationController.CalculatedPath;
        AddOffsetToPath();
        SetLineRendererPositions();
    }

    private void AddOffsetToPath()
    {
        calculatedPathAndOffset = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedPathAndOffset[i] = new Vector3(path.corners[i].x, transform.position.y, path.corners[i].z);
        }
    }

    private void SetLineRendererPositions()
    {
        line.positionCount = calculatedPathAndOffset.Length;
        line.SetPositions(calculatedPathAndOffset);
    }
}
