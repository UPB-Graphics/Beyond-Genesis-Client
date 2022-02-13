using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public float precision = 0.02f;
    public PathCreator pathCreator;

    private int pointIndex = -1;
    private List<Vector3> pointsPositions;

    public enum Mode
    {
        Normal,
        IgnoreYAxis
    }

    private void Start()
    {
        pointsPositions = new List<Vector3>();
        foreach (var pathCreatorPoint in pathCreator.points)
        {
            pointsPositions.Add(pathCreatorPoint.transform.position);
        }
    }

    public Vector3 GetDirection(Vector3 currentPosition, Mode mode = Mode.Normal)
    {
        if (pointIndex == -1)
        {
            SelectClosesPoint(currentPosition);
        }
        
        if ( pointIndex < pointsPositions.Count && (currentPosition - pointsPositions[pointIndex]).magnitude < precision)
        {
            pointIndex += 1;
        }

        if (pointIndex >= pointsPositions.Count)
        {
            return Vector3.zero;
        }
        
        switch (mode)
        {
            case Mode.Normal:
                return (pointsPositions[pointIndex] - currentPosition).normalized;
            case Mode.IgnoreYAxis:
                var curr = new Vector3(currentPosition.x, 0, currentPosition.z);
                var target = new Vector3(pointsPositions[pointIndex].x, 0, pointsPositions[pointIndex].z);
                return (target - curr).normalized;
            default:
                return Vector3.zero;
        }
    }
    
    private void SelectClosesPoint(Vector3 currentPosition)
    {
        
        var closesPoint = 0;

        var currDist = (pointsPositions[closesPoint] - currentPosition).sqrMagnitude;


        for (var i = 0; i < pointsPositions.Count; ++i)
        {
            var dist = (currentPosition - pointsPositions[i]).sqrMagnitude;
            if ( dist < currDist)
            {
                currDist = dist;
                closesPoint = i;
            }
        }

        pointIndex = closesPoint;
    }
}
