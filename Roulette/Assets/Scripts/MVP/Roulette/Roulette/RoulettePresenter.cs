using UnityEngine;

public class RoulettePresenter
{
    private RouletteModel rouletteModel;
    private RouletteView rouletteView;

    public RoulettePresenter(RouletteModel rouletteModel, RouletteView rouletteView)
    {
        this.rouletteModel = rouletteModel;
        this.rouletteView = rouletteView;
    }

    public void Initialize()
    {
        ActivateEvents();

        rouletteView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        rouletteView.Dispose();
    }

    private void ActivateEvents()
    {
        rouletteView.OnStartSpin += rouletteModel.StartSpin;

        rouletteModel.OnStartSpin += rouletteView.StartSpin;
        rouletteModel.OnRollBallToSlot += rouletteView.RollBallToSlot;
    }

    private void DeactivateEvents()
    {
        rouletteView.OnStartSpin -= rouletteModel.StartSpin;

        rouletteModel.OnStartSpin -= rouletteView.StartSpin;
        rouletteModel.OnRollBallToSlot -= rouletteView.RollBallToSlot;
    }

    #region Input

    public void RollBallToSlot(Vector3 vector)
    {
        rouletteModel.RollBallToSlot(vector);
    }

    #endregion
}
