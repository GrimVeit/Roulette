using System;
using UnityEngine;

public class Slots1SceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private Combination combination;
    [SerializeField] private UISlots1SceneRoot menuRootPrefab;

    private UISlots1SceneRoot sceneRoot;
    private ViewContainer viewContainer;

    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;
    private BankPresenter bankPresenter;

    private SlotMachinePresenter slotMachinePresenter;
    private SlotBetPresenter slotBetPresenter;
    private SlotEffectPresenter slotEffectPresenter;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(menuRootPrefab);

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

        slotMachinePresenter = new SlotMachinePresenter
            (new SlotMachineModel(5, 3, combination, bankPresenter, soundPresenter, particleEffectPresenter), 
            viewContainer.GetView<SlotMachineView>());
        slotMachinePresenter.Initialize();

        slotBetPresenter = new SlotBetPresenter
            (new SlotBetModel(), 
            viewContainer.GetView<SlotBetView>());
        slotBetPresenter.Initialize();

        slotEffectPresenter = new SlotEffectPresenter
            (new SlotEffectModel(), 
            viewContainer.GetView<SlotEffectView>());
        slotEffectPresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();


        ActivateTransitionsSceneEvents();
        ActivateEvents();

        sceneRoot.Activate();
    }

    private void ActivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToMainMenu += HandleGoToMainMenu;
        slotBetPresenter.OnClickToBet += sceneRoot.OpenBetPanel;
        slotBetPresenter.OnChooseBet += sceneRoot.CloseBetPanel;

        slotMachinePresenter.OnVisibleWin += sceneRoot.OpenWinPanel;
        sceneRoot.OnCloseWinPanel += sceneRoot.CloseWinPanel;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToMainMenu -= HandleGoToMainMenu;
        slotBetPresenter.OnClickToBet -= sceneRoot.OpenBetPanel;
        slotBetPresenter.OnChooseBet -= sceneRoot.CloseBetPanel;

        slotMachinePresenter.OnVisibleWin -= sceneRoot.OpenWinPanel;
        sceneRoot.OnCloseWinPanel -= sceneRoot.CloseWinPanel;
    }

    private void ActivateEvents()
    {
        slotBetPresenter.OnChooseBet_Count += slotMachinePresenter.SetBet;

        slotMachinePresenter.OnStartSpin += slotBetPresenter.Deactivate;
        slotMachinePresenter.OnStopSpin += slotBetPresenter.Activate;

        slotMachinePresenter.OnWinCombination += slotEffectPresenter.SetSlotGrid;
    }

    private void DeactivateEvents()
    {
        slotBetPresenter.OnChooseBet_Count -= slotMachinePresenter.SetBet;

        slotMachinePresenter.OnStartSpin -= slotBetPresenter.Deactivate;
        slotMachinePresenter.OnStopSpin -= slotBetPresenter.Activate;

        slotMachinePresenter.OnWinCombination -= slotEffectPresenter.SetSlotGrid;
    }

    private void Dispose()
    {
        DeactivateTransitionsSceneEvents();
        DeactivateEvents();

        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();
        slotMachinePresenter?.Dispose();
        slotBetPresenter?.Dispose();
        slotEffectPresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input actions

    public event Action GoToMainMenu_Action;


    private void HandleGoToMainMenu()
    {
        sceneRoot.Deactivate();

        GoToMainMenu_Action?.Invoke();
    }

    #endregion
}
