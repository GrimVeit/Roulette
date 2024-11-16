using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;
    private BankPresenter bankPresenter;

    private DailyRewardPresenter dailyRewardPresenter;
    private CooldownPresenter cooldownDailyRewardPresenter;

    private RouletteColorPresenter rouletteColorPresenter;

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

        cooldownDailyRewardPresenter = new CooldownPresenter
            (new CooldownModel(PlayerPrefsKeys.NEXT_DAILY_REWARD_TIME, TimeSpan.FromDays(1), soundPresenter),
            viewContainer.GetView<CooldownView>("DailyReward"));
        cooldownDailyRewardPresenter.Initialize();

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        bankPresenter.Initialize();

        dailyRewardPresenter = new DailyRewardPresenter
            (new DailyRewardModel(soundPresenter, particleEffectPresenter),
            viewContainer.GetView<DailyRewardView>());
        dailyRewardPresenter.Initialize();

        rouletteColorPresenter = new RouletteColorPresenter
            (new RouletteColorModel(soundPresenter), 
            viewContainer.GetView<RouletteColorView>());
        rouletteColorPresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();


        ActivateTransitionsSceneEvents();
        ActivateEvents();

        sceneRoot.Activate();
        cooldownDailyRewardPresenter.Activate();
    }

    private void ActivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToRouletteGame_Action += HandleGoToRouletteGame;
        sceneRoot.OnGoToSlots1_Action += HandleGoToSlots1Game;
        sceneRoot.OnGoToSlots2_Action += HandleGoToSlots2Game;
        sceneRoot.OnGoToSlots3_Action += HandleGoToSlots3Game;

        dailyRewardPresenter.OnGetDailyReward += sceneRoot.OpenMainPanel;
        cooldownDailyRewardPresenter.OnClickToActivatedButton += sceneRoot.OpenDailyRewardPanel;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToRouletteGame_Action -= HandleGoToRouletteGame;
        sceneRoot.OnGoToSlots1_Action -= HandleGoToSlots1Game;
        sceneRoot.OnGoToSlots2_Action -= HandleGoToSlots2Game;
        sceneRoot.OnGoToSlots3_Action -= HandleGoToSlots3Game;

        dailyRewardPresenter.OnGetDailyReward -= sceneRoot.OpenMainPanel;
        cooldownDailyRewardPresenter.OnClickToActivatedButton -= sceneRoot.OpenDailyRewardPanel;
    }

    private void ActivateEvents()
    {
        dailyRewardPresenter.OnGetDailyReward += cooldownDailyRewardPresenter.ActivateCooldown;
        dailyRewardPresenter.OnGetDailyReward_Count += bankPresenter.SendMoney;
    }

    private void DeactivateEvents()
    {
        dailyRewardPresenter.OnGetDailyReward -= cooldownDailyRewardPresenter.ActivateCooldown;
        dailyRewardPresenter.OnGetDailyReward_Count -= bankPresenter.SendMoney;
    }

    private void Dispose()
    {
        DeactivateTransitionsSceneEvents();
        DeactivateEvents();

        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();
        dailyRewardPresenter?.Dispose();
        cooldownDailyRewardPresenter?.Dispose();
        rouletteColorPresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input actions

    public event Action GoToRouletteGame_Action;
    public event Action GoToSlots1_Action;
    public event Action GoToSlots2_Action;
    public event Action GoToSlots3_Action;


    private void HandleGoToRouletteGame()
    {
        sceneRoot.Deactivate();

        GoToRouletteGame_Action?.Invoke();
    }

    private void HandleGoToSlots1Game()
    {
        sceneRoot.Deactivate();

        GoToSlots1_Action?.Invoke();
    }

    private void HandleGoToSlots2Game()
    {
        sceneRoot.Deactivate();

        GoToSlots2_Action?.Invoke();
    }

    private void HandleGoToSlots3Game()
    {
        sceneRoot.Deactivate();

        GoToSlots3_Action?.Invoke();
    }
    
    #endregion
}
