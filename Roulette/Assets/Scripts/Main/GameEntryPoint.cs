using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint instance;
    private UIRootView rootView;
    private Coroutines coroutines;
    public GameEntryPoint()
    {
        coroutines = new GameObject("[Coroutines]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRootView");
        rootView = Object.Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(rootView.gameObject);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Autorun()
    {
        GlobalGameSettings();

        instance = new GameEntryPoint();
        instance.Run();

    }

    private static void GlobalGameSettings()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Run()
    {
        coroutines.StartCoroutine(LoadAndStartMainMenu());
    }

    private IEnumerator LoadAndStartMainMenu()
    {
        rootView.SetLoadScreen(0);

        yield return rootView.ShowLoadingScreen();

        yield return new WaitForSeconds(0.4f);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MAIN_MENU);

        yield return null;

        var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.GoToRouletteGame_Action += () => coroutines.StartCoroutine(LoadAndStartRouletteScene());
        sceneEntryPoint.GoToSlots1_Action += () => coroutines.StartCoroutine(LoadAndStartSlots1Scene());
        sceneEntryPoint.GoToSlots2_Action += () => coroutines.StartCoroutine(LoadAndStartSlots2Scene());
        sceneEntryPoint.GoToSlots3_Action += () => coroutines.StartCoroutine(LoadAndStartSlots3Scene());

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartRouletteScene()
    {
        rootView.SetLoadScreen(1);
        yield return rootView.ShowLoadingScreen();

        yield return new WaitForSeconds(0.4f);
        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.ROULETTE);
        yield return null;

        var sceneEntryPoint = Object.FindObjectOfType<RouletteEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.GoToMainMenu_Action += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartSlots1Scene()
    {
        rootView.SetLoadScreen(2);
        yield return rootView.ShowLoadingScreen();

        yield return new WaitForSeconds(0.4f);
        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.SLOTS1);
        yield return null;

        var sceneEntryPoint = Object.FindObjectOfType<Slots1SceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.GoToMainMenu_Action += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartSlots2Scene()
    {
        rootView.SetLoadScreen(3);
        yield return rootView.ShowLoadingScreen();

        yield return new WaitForSeconds(0.4f);
        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.SLOTS2);
        yield return null;

        var sceneEntryPoint = Object.FindObjectOfType<Slots2SceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.GoToMainMenu_Action += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartSlots3Scene()
    {
        rootView.SetLoadScreen(4);
        yield return rootView.ShowLoadingScreen();

        yield return new WaitForSeconds(0.4f);
        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.SLOTS3);
        yield return null;

        var sceneEntryPoint = Object.FindObjectOfType<Slots3SceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.GoToMainMenu_Action += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string scene)
    {
        Debug.Log("Загрузка сцены - " + scene);
        yield return SceneManager.LoadSceneAsync(scene);
    }
}
