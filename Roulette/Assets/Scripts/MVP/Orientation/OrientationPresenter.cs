using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationPresenter
{
    private OrientationModel orientationModel;

    public OrientationPresenter(OrientationModel orientationModel)
    {
        this.orientationModel = orientationModel;
    }

    public void Initialize()
    {
        
    }

    public void Dispose()
    {

    }

    #region Input

    public void LandscapeLeftOrientation()
    {
        orientationModel.LandscapeLeftOrientation();
    }

    #endregion
}
