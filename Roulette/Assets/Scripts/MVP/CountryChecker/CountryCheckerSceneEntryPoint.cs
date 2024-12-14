using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryCheckerSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private UICountryCheckerSceneRoot sceneRootPrefab;

    private UICountryCheckerSceneRoot sceneRoot;
    private ViewContainer viewContainer;

    private GeoLocationPresenter geoLocationPresenter;
    private InternetPresenter internetPresenter;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(sceneRootPrefab);
        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        geoLocationPresenter = new GeoLocationPresenter(new GeoLocationModel());

        internetPresenter = new InternetPresenter(new InternetModel(), viewContainer.GetView<InternetView>());
        internetPresenter.Initialize();

        ActivateActions();

        internetPresenter.StartCkeckInternet();

    }

    public void Dispose()
    {
        DeactivateActions();

        internetPresenter?.Dispose();
    }

    private void ActivateActions()
    {
        internetPresenter.OnInternetAvailable += geoLocationPresenter.GetUserCountry;
        internetPresenter.OnInternetUnavailable += TransitionToMainMenu;
        geoLocationPresenter.OnGetCountry += ActivateSceneInCountry;
    }

    private void DeactivateActions()
    {
        internetPresenter.OnInternetAvailable -= geoLocationPresenter.GetUserCountry;
        internetPresenter.OnInternetUnavailable -= TransitionToMainMenu;
        geoLocationPresenter.OnGetCountry -= ActivateSceneInCountry;
    }

    private void ActivateSceneInCountry(string country)
    {
        switch (country)
        {
            case "AU":
                TransitionToOther();
                break;
            case "DE":
                TransitionToOther();
                break;
            case "IT":
                TransitionToOther();
                break;
            case "CA":
                TransitionToOther();
                break;
            case "AT":
                TransitionToOther();
                break;
            case "FR":
                TransitionToOther();
                break;
            case "ES":
                TransitionToOther();
                break;
            case "BR":
                TransitionToOther();
                break;
            case "PL":
                TransitionToOther();
                break;
            case "PT":
                TransitionToOther();
                break;
            default:
                TransitionToMainMenu();
                break;
        }
    }

    #region Input

    public event Action GoToMainMenu;
    public event Action GoToOther;

    private void TransitionToMainMenu()
    {
        Debug.Log("Go to main menu");
        Dispose();
        Debug.Log("Go to main menu");
        GoToMainMenu?.Invoke();
        Debug.Log("Go to main menu");
    }

    private void TransitionToOther()
    {
        Dispose();
        GoToOther?.Invoke();
    }

    #endregion
}
