using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRealtimePresenter
{
    private TimeRealtimeModel timeRealtimeModel;

    public TimeRealtimePresenter(TimeRealtimeModel timeRealtimeModel)
    {
        this.timeRealtimeModel = timeRealtimeModel;
    }

    public void Initialize()
    {
        timeRealtimeModel.Initialize();
    }

    public void Dispose()
    {
        timeRealtimeModel.Dispose();
    }
}
