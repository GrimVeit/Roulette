using System;
using UnityEngine;

public class RouletteEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIRouletteRoot sceneRootPrefab;

    private UIRouletteRoot sceneRoot;
    private ViewContainer viewContainer;

    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;
    private BankPresenter bankPresenter;

    private PseudoChipPresenter pseudoChipPresenter;
    private ChipPresenter chipPresenter;

    private RouletteBallPresenter rouletteBallPresenter;
    private RoulettePresenter roulettePresenter;
    private RouletteBetPresenter rouletteBetPresenter;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(sceneRootPrefab);

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
            viewContainer.GetView<SoundView>());
        soundPresenter.Initialize();

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());
        particleEffectPresenter.Initialize();

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        bankPresenter.Initialize();

        pseudoChipPresenter = new PseudoChipPresenter(new PseudoChipModel(bankPresenter), viewContainer.GetView<PseudoChipView>());
        pseudoChipPresenter.Initialize();

        chipPresenter = new ChipPresenter(new ChipModel(), viewContainer.GetView<ChipView>());
        chipPresenter.Initialize();

        rouletteBallPresenter = new RouletteBallPresenter(new RouletteBallModel(), viewContainer.GetView<RouletteBallView>());
        rouletteBallPresenter.Initialize();

        roulettePresenter = new RoulettePresenter(new RouletteModel(), viewContainer.GetView<RouletteView>());
        roulettePresenter.Initialize();

        rouletteBetPresenter = new RouletteBetPresenter(new RouletteBetModel(bankPresenter), viewContainer.GetView<RouletteBetView>());
        rouletteBetPresenter.Initialize();

        ActivateTransferEvents();
        ActivateEvents();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();
        sceneRoot.Activate();
    }

    private void ActivateEvents()
    {
        pseudoChipPresenter.OnSpawnChip += chipPresenter.SpawnChip;
        rouletteBallPresenter.OnBallStopped += roulettePresenter.RollBallToSlot;
    }

    private void ActivateTransferEvents()
    {
        sceneRoot.OnClickToBackButton += HandleGoToMainMenu;
        sceneRoot.OnClickToSpinButton += sceneRoot.OpenSpinPanel;
    }

    private void DeactivateEvents()
    {
        pseudoChipPresenter.OnSpawnChip -= chipPresenter.SpawnChip;
        rouletteBallPresenter.OnBallStopped -= roulettePresenter.RollBallToSlot;
    }

    private void DeactivateTransferEvents()
    {
        sceneRoot.OnClickToBackButton -= HandleGoToMainMenu;
        sceneRoot.OnClickToSpinButton -= sceneRoot.OpenSpinPanel;
    }

    private void Dispose()
    {
        DeactivateEvents();
        DeactivateTransferEvents();
        sceneRoot?.Deactivate();

        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();

        pseudoChipPresenter?.Dispose();
        chipPresenter?.Dispose();
        rouletteBallPresenter?.Dispose();
        roulettePresenter?.Dispose();
        rouletteBetPresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input actions

    public event Action GoToMainMenu_Action;


    private void HandleGoToMainMenu()
    {
        GoToMainMenu_Action?.Invoke();
    }

    #endregion
}
