using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInFrustum : MonoBehaviour
{
    private Renderer _renderer;
    private Camera _cam;
    protected virtual void Start()
    {
        _renderer = GetComponent<Renderer>();
        _cam = Camera.main;
    }

    public bool IsObjectInFrustum()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_cam);
        return GeometryUtility.TestPlanesAABB(planes, _renderer.bounds);
    }
}