using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class ShowPreview : MonoBehaviour
{
    private LineRenderer lr;

    public static ShowPreview instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        lr = GetComponent<LineRenderer>();
    }

    public void setFirstPoint(Vector3 firstPoint)
    {
        lr.SetPosition(0, firstPoint);
    }

    public void setLastPoint(Vector3 lastPoint)
    { 
        lr.SetPosition(1, lastPoint);
    }

    
}
