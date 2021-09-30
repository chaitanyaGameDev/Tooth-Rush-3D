using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [SerializeField] TextMeshProUGUI m_FinalScore_Text;
    [SerializeField] TextMeshProUGUI m_FinalCoins_Text;

    [SerializeField] Button m_Next_Button;

    //----------------------------------------------Actions--------------------------------------------------

    public static event Action s_NextButtonClicked_event;
    public static event Action s_WinScreenEnabled_event;
    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        m_Next_Button.interactable = true;

        //event
        s_WinScreenEnabled_event?.Invoke();


        UpdateFinalScoreText();
        UpdateFinalCoinsText();
    }
    

    public void NextButtonClicked()
    {
        s_NextButtonClicked_event?.Invoke();

        m_Next_Button.interactable = false;

        Debug.Log("Next Clicked");
    }

    private void UpdateFinalScoreText()
    {
        m_FinalScore_Text.text = ScoreManager.Instance.CurrentScore.ToString();
    }
    private void UpdateFinalCoinsText()
    {
        m_FinalCoins_Text.text = CoinManager.Instance.CurrentCoins.ToString();
    }

}
