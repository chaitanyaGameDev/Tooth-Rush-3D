using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToothAgeingProgressBar : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [SerializeField] Image m_Case_image;
    [SerializeField] Image m_Fill_image;
    [SerializeField] TextMeshProUGUI m_State_text;

    [Header("Place Holder")]
    [SerializeField] Transform m_Slider_PlaceHolder;
   // [SerializeField] Transform m_StateText_PlaceHolder;


    [Header("Fill Colors")]

    [SerializeField] Color m_Red;
    [SerializeField] Color m_Blue;
    [SerializeField] Color m_Green;
    [SerializeField] Color m_Yellow;
    [SerializeField] Color m_Orange;

    

    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        ToothHealth.s_OnHealthUpdated_event += UpdateProgressBar;
        ToothAgeing.s_OnStateChanged_event += UpdateOnToothState;

        Player.s_OnStateChanged_event += EnableProgressBar;
    }
    private void OnDisable()
    {
        ToothHealth.s_OnHealthUpdated_event -= UpdateProgressBar;
        ToothAgeing.s_OnStateChanged_event -= UpdateOnToothState;

        Player.s_OnStateChanged_event -= EnableProgressBar;
    }

    private void UpdateProgressBar()
    {
        float fillValue = ToothHealth.s_Health / 100f;
        m_Fill_image.fillAmount = fillValue;

    }
    private void UpdateOnToothState(ToothAgeState state)
    {
        switch (state)
        {
            case ToothAgeState.none:
                break;
            case ToothAgeState.Shiny:
                m_State_text.text = "Shiny Tooth";
                ChangeFillColor(m_Green);
                break;
            case ToothAgeState.Healthy:

                m_State_text.text = "Healthy Tooth";
                ChangeFillColor(m_Green);
                break;
            case ToothAgeState.Germs:

                m_State_text.text = "Germs";
                ChangeFillColor(m_Blue);
                break;
            case ToothAgeState.Plague1:

                m_State_text.text = "Plague Tooth";
                ChangeFillColor(m_Yellow);
                break;
            case ToothAgeState.Plague2:

                m_State_text.text = "Plague Tooth";
                ChangeFillColor(m_Yellow);
                break;
            case ToothAgeState.Plague3:

                m_State_text.text = "Plague Tooth";
                ChangeFillColor(m_Yellow);
                break;
            case ToothAgeState.Cavity1:

                m_State_text.text = "Cavity Tooth";
                ChangeFillColor(m_Orange);
                break;
            case ToothAgeState.Cavity2:
                m_State_text.text = "Cavity Tooth";
                ChangeFillColor(m_Orange);
                break;
            case ToothAgeState.Rotten:

                m_State_text.text = "Rotten Tooth";
                ChangeFillColor(m_Red);
                break;
            default:
                break;
        }
    }

    private void EnableProgressBar(PlayerState state)
    {
        if (state == PlayerState.LevelCompleted)
        {
            m_Case_image.gameObject.SetActive(true);
        }
    }
    private void ChangeFillColor(Color color)
   {
        m_Fill_image.color = color;
   }

    private void Update()
    {
        Vector3 sliderPos = Camera.main.WorldToScreenPoint(m_Slider_PlaceHolder.position);
        m_Case_image.transform.position = sliderPos;


        //  Vector3 stateTextPos = Camera.main.WorldToScreenPoint(m_StateText_PlaceHolder.position);
        //  m_State_text.transform.position = stateTextPos;
    }
}

