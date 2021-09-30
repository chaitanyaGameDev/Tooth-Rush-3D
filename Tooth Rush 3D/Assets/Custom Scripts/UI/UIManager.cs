using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : GenericSingleton<UIManager>
{
    //----------------------------------------------Variables-----------------------------------------------
    [Header("[UI Screens]")]
    [SerializeField] GameObject m_Start_Screen;
    [SerializeField] GameObject m_Active_Screen;
    [SerializeField] GameObject m_Win_Screen;
    [SerializeField] GameObject m_Fail_Screen;

    [SerializeField] GameObject m_Coins_Screen;


    //----------------------------------------------Actions--------------------------------------------------

    


    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        Player.s_OnStateChanged_event += CheckPlayerStateAndEnableUI;

        WinScreenUI.s_NextButtonClicked_event += DisableAllDisplay;
        FailScreenUI.s_ContinueButtonClick_Event += DisableAllDisplay;
    } 
    private void OnDisable()
    {
        Player.s_OnStateChanged_event -= CheckPlayerStateAndEnableUI;

        WinScreenUI.s_NextButtonClicked_event -= DisableAllDisplay;
        FailScreenUI.s_ContinueButtonClick_Event -= DisableAllDisplay;
    }


    //Logic to UIScreens at a particuar Player State
    private void CheckPlayerStateAndEnableUI(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.WaitingForInput:

                QuickAllUIDisable();
                ShowDisplayUIScreen(UIScreenType.StartScreen,0.01f,true);          
                break;
            case PlayerState.Playing:
                QuickAllUIDisable();
                ShowDisplayUIScreen(UIScreenType.ActiveScreen,0.01f,true);
                break;
            case PlayerState.LevelCompleted:
                QuickAllUIDisable();
                ShowDisplayUIScreen(UIScreenType.WinScreen,5f,true);
                ShowDisplayUIScreen(UIScreenType.CoinsScreen,5f,true);
                break;
            case PlayerState.LevelFailed:
                QuickAllUIDisable();
                ShowDisplayUIScreen(UIScreenType.FailScreen, 3f, true);
                ShowDisplayUIScreen(UIScreenType.CoinsScreen, 3f, true);
                break;
            default:
                break;
        }
    }


    //Displayes UI Screen 
    private void ShowDisplayUIScreen(UIScreenType screenType ,float delay,bool status)
    {
        StartCoroutine(DelayUIDisplay(screenType,delay,status));
    }
    private IEnumerator DelayUIDisplay(UIScreenType screenType,float delay,bool status)
    {
        yield return new WaitForSeconds(delay);

        switch (screenType)
        {
            case UIScreenType.StartScreen:
                m_Start_Screen.gameObject.SetActive(status);
                break;
            case UIScreenType.ActiveScreen:
                m_Active_Screen.gameObject.SetActive(status);
                break;
            case UIScreenType.WinScreen:
                m_Win_Screen.gameObject.SetActive(status);
                break;
            case UIScreenType.FailScreen:
                m_Fail_Screen.gameObject.SetActive(status);
                break;
            case UIScreenType.CoinsScreen:
                m_Coins_Screen.gameObject.SetActive(status);
                break;
        }
    }

    //Disables UI Screen
    private void DisableAllDisplay()
    {
        StartCoroutine(DelayDisableAll());
    }
    private IEnumerator DelayDisableAll()
    {
        yield return new WaitForSeconds(1f);
        m_Start_Screen.gameObject.SetActive(false);
        m_Active_Screen.gameObject.SetActive(false);
        m_Win_Screen.gameObject.SetActive(false);
        m_Fail_Screen.gameObject.SetActive(false);
        m_Coins_Screen.gameObject.SetActive(false);
    }

    //Disables All UI Screen
    private void QuickAllUIDisable()
    {
        m_Start_Screen.gameObject.SetActive(false);
        m_Active_Screen.gameObject.SetActive(false);
        m_Win_Screen.gameObject.SetActive(false);
        m_Fail_Screen.gameObject.SetActive(false);
        m_Coins_Screen.gameObject.SetActive(false);
    }
}
public enum UIScreenType
{
    StartScreen,
    ActiveScreen,
    WinScreen,
    FailScreen,
    CoinsScreen
}

