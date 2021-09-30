using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothProgressionResult : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    [SerializeField] GameObject m_ShinyReport;
    [SerializeField] GameObject m_HealthyReport;
    [SerializeField] GameObject m_GermsReport;
    [SerializeField] GameObject m_Plague1Report;
    [SerializeField] GameObject m_Plague2Report;
    [SerializeField] GameObject m_Plague3Report;
    [SerializeField] GameObject m_Cavity1Report;
    [SerializeField] GameObject m_Cavity2Report;
    [SerializeField] GameObject m_RottenReport;
    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        Player.s_OnStateChanged_event += CheckPlayerState;
        WinScreenUI.s_WinScreenEnabled_event += DisableAllReports;
    }
    private void OnDisable()
    {
        Player.s_OnStateChanged_event -= CheckPlayerState;
        WinScreenUI.s_WinScreenEnabled_event -= DisableAllReports;
    }

    private void CheckPlayerState(PlayerState state)
    {
        if (state == PlayerState.LevelCompleted)
        {
            ShowReport(ToothAgeing.s_CurrentState);
        }
    }
    private void ShowReport(ToothAgeState state)
    {

        switch (state)
        {
            case ToothAgeState.none:
                break;
            case ToothAgeState.Shiny:
                m_ShinyReport.gameObject.SetActive(true);
                break;

            case ToothAgeState.Healthy:
                m_HealthyReport.gameObject.SetActive(true);
                break;

            case ToothAgeState.Germs:
                m_GermsReport.gameObject.SetActive(true);
                break;

            case ToothAgeState.Plague1:
                m_Plague1Report.gameObject.SetActive(true);
                break;

            case ToothAgeState.Plague2:
                m_Plague2Report.gameObject.SetActive(true);
                break;

            case ToothAgeState.Plague3:
                m_Plague3Report.gameObject.SetActive(true);
                break;

            case ToothAgeState.Cavity1:
                m_Cavity1Report.gameObject.SetActive(true);
                break;

            case ToothAgeState.Cavity2:
                m_Cavity2Report.gameObject.SetActive(true);
                break;

            case ToothAgeState.Rotten:
                m_RottenReport.gameObject.SetActive(true);
                break;

            default:
                break;
        }
    }
    private void DisableAllReports()
    {
        m_ShinyReport.gameObject.SetActive(false);
        m_HealthyReport.gameObject.SetActive(false);
        m_GermsReport.gameObject.SetActive(false);
        m_Plague1Report.gameObject.SetActive(false);
        m_Plague2Report.gameObject.SetActive(false);
        m_Plague3Report.gameObject.SetActive(false);
        m_Cavity1Report.gameObject.SetActive(false);
        m_Cavity2Report.gameObject.SetActive(false);
        m_RottenReport.gameObject.SetActive(false);
    }
    
}
