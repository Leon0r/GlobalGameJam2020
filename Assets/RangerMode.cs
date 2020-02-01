using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMode
{
    private bool rangerMode = false;

    public void SetRangerMode(bool state)
    {
        rangerMode = state;
    }

    public bool GetRangerMode()
    {
        return rangerMode;
    }
}
