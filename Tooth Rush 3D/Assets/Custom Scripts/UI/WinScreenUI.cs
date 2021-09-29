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

    public static event Action s_NextButtonClicked_Event;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        m_Next_Button.interactable = true;
       
    }
    


    public void NextButtonClicked()
    {
        s_NextButtonClicked_Event?.Invoke();

        m_Next_Button.interactable = false;

        Debug.Log("Next Clicked");
    }
}
