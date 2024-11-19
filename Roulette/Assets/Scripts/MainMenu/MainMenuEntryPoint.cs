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

    private GameProgressPresenter gameProgressPresenter;
    private GameTrackerPresenter gameTrackerPresenter;

    private TimeRealtimePresenter timeRealtimePresenter;
    private TimeGameSessionPresenter timeGameSessionPresenter;

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

        gameTrackerPresenter = new GameTrackerPresenter
            (new GameTrackerModel(), 
            viewContainer.GetView<GameTrackerView>());
        gameTrackerPresenter.Initialize();

        gameProgressPresenter = new GameProgressPresenter
            (new GameProgressModel());

        timeRealtimePresenter = new TimeRealtimePresenter(new TimeRealtimeModel(gameProgressPresenter));

        timeGameSessionPresenter = new TimeGameSessionPresenter(new TimeGameSessionModel(gameProgressPresenter));

        ActivateTransitionsSceneEvents();
        ActivateEvents();

        gameProgressPresenter.Initialize();
        timeGameSessionPresenter.Initialize();
        timeRealtimePresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();

        sceneRoot.Activate();
        cooldownDailyRewardPresenter.Activate();
    }

    private void ActivateTransitionsSceneEvents()
    {
        dailyRewardPresenter.OnGetDailyReward += sceneRoot.OpenMainPanel;
        cooldownDailyRewardPresenter.OnClickToActivatedButton += sceneRoot.OpenDailyRewardPanel;

        gameTrackerPresenter.OnGoToRouletteGame += HandleGoToRouletteGame;
        gameTrackerPresenter.OnGoSlots1Game += HandleGoToSlots1Game;
        gameTrackerPresenter.OnGoSlots2Game += HandleGoToSlots2Game;
        gameTrackerPresenter.OnGoSlots3Game += HandleGoToSlots3Game;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        dailyRewardPresenter.OnGetDailyReward -= sceneRoot.OpenMainPanel;
        cooldownDailyRewardPresenter.OnClickToActivatedButton -= sceneRoot.OpenDailyRewardPanel;

        gameTrackerPresenter.OnGoToRouletteGame -= HandleGoToRouletteGame;
        gameTrackerPresenter.OnGoSlots1Game -= HandleGoToSlots1Game;
        gameTrackerPresenter.OnGoSlots2Game -= HandleGoToSlots2Game;
        gameTrackerPresenter.OnGoSlots3Game -= HandleGoToSlots3Game;
    }

    private void ActivateEvents()
    {
        dailyRewardPresenter.OnGetDailyReward += cooldownDailyRewardPresenter.ActivateCooldown;
        dailyRewardPresenter.OnGetDailyReward_Count += bankPresenter.SendMoney;

        gameProgressPresenter.OnGetData += gameTrackerPresenter.SetData;
    }

    private void DeactivateEvents()
    {
        dailyRewardPresenter.OnGetDailyReward -= cooldownDailyRewardPresenter.ActivateCooldown;
        dailyRewardPresenter.OnGetDailyReward_Count -= bankPresenter.SendMoney;

        gameProgressPresenter.OnGetData -= gameTrackerPresenter.SetData;
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
        gameProgressPresenter?.Dispose();
        gameTrackerPresenter?.Dispose();
        timeRealtimePresenter?.Dispose();
        timeGameSessionPresenter?.Dispose();
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
