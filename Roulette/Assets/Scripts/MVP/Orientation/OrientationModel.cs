using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationModel
{
    public void LandscapeLeftOrientation()
    {
        Debug.Log("Change to landscape");
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
