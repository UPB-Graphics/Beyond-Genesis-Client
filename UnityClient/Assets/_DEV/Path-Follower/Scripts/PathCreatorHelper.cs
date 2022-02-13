using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class PathCreatorHelper : MonoBehaviour
{
    public bool displayPath = true;
    public bool autoRefreshWhenChildrenChange = false;
    public Color pathColor = Color.magenta;
    public Color pointColor = Color.gray;
    public Color startingPointColor = Color.green;
    public Color endingPointColor = Color.red;

    [SerializeField] private PathCreator pathCreator;
    // Start is called before the first frame update
    private void Start()
    {
        pathCreator = GetComponent<PathCreator>();
        UpdateColor();
    }

    private void Update()
    {
        if (displayPath && pathCreator != null)
        {
            DisplayPath();
        }
    }

    private void OnTransformChildrenChanged()
    {
        if (autoRefreshWhenChildrenChange && pathCreator != null)
        {
            pathCreator.points = GetComponentsInChildren<PathPoint>().ToList();
        }
        UpdateColor();
    }

    private void DisplayPath()
    {
        var points = pathCreator.points;
        for (var i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(points[i].transform.position, points[i + 1].transform.position, pathColor);
        }
    }

    private void UpdateColor()
    {
        for (var i = 0; i < pathCreator.points.Count; i++)
        {
            if (i == 0)
            {
                pathCreator.points[i].color = startingPointColor;
            } else if (i == pathCreator.points.Count - 1)
            {
                pathCreator.points[i].color = endingPointColor;
            }
            else
            {
                pathCreator.points[i].color = pointColor;
            }
        }
    }
}
