using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMode : MonoBehaviour
{
    private bool rangerMode = false;

    public void SetRangerMode(bool state) {
        rangerMode = state;
    }

    public bool GetRangerMode() {
        return rangerMode;
    }
}

public static class CameraEx
{
    public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer renderer)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderer.bounds);
    }
}
