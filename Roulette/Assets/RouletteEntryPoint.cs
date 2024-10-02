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

        pseudoChipPresenter = new PseudoChipPresenter(new PseudoChipModel(), viewContainer.GetView<PseudoChipView>());
        pseudoChipPresenter.Initialize();

        chipPresenter = new ChipPresenter(new ChipModel(), viewContainer.GetView<ChipView>());
        chipPresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();


        ActivateEvents();

        sceneRoot.Activate();
    }

    private void ActivateEvents()
    {
        pseudoChipPresenter.OnSpawnChip += chipPresenter.SpawnChip;
    }

    private void DeactivateEvents()
    {
        pseudoChipPresenter.OnSpawnChip -= chipPresenter.SpawnChip;
    }

    private void Dispose()
    {
        DeactivateEvents();
        sceneRoot?.Deactivate();

        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();

        pseudoChipPresenter?.Dispose();
        chipPresenter?.Dispose();
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
