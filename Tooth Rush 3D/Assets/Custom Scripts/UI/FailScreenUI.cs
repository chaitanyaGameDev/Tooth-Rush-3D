using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class FailScreenUI : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [SerializeField] TextMeshProUGUI m_FinalScore_Text;
    [SerializeField] TextMeshProUGUI m_FinalCoins_Text;

    [SerializeField] Button m_Continue_Button;

    //----------------------------------------------Actions--------------------------------------------------

    public static event Action s_ContinueButtonClick_Event;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        m_Continue_Button.interactable = true;
        UpdateFinalScoreAndCoinsText();
    }
    private void UpdateFinalScoreAndCoinsText()
    {
       
    }


    public void ContinueButtonClicked()
    {
        s_ContinueButtonClick_Event?.Invoke();

        m_Continue_Button.interactable = false;

        Debug.Log("ContinueClicked");
    }

  
}
