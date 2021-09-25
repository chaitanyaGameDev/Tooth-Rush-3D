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
    [SerializeField] Transform m_StateText_PlaceHolder;

    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        ToothHealth.s_OnHealthUpdated_event += UpdateProgressBar;
        ToothAgeing.s_OnStateChanged_event += UpdateStateText;
    }
    private void OnDisable()
    {
        ToothHealth.s_OnHealthUpdated_event -= UpdateProgressBar;
        ToothAgeing.s_OnStateChanged_event -= UpdateStateText;
    }
    private void UpdateProgressBar()
    {
        float fillValue = ToothHealth.s_Health / 100f;
        m_Fill_image.fillAmount = fillValue;
    }
    private void UpdateStateText(ToothAgeState state)
    {
        switch (state)
        {
            case ToothAgeState.none:
                break;
            case ToothAgeState.Shiny:

                m_State_text.text = "Shiny";
                break;
            case ToothAgeState.Healthy:

                m_State_text.text = "Healthy";
                break;
            case ToothAgeState.Germs:

                m_State_text.text = "Germs";
                break;
            case ToothAgeState.Plague1:

                m_State_text.text = "Plague";
                break;
            case ToothAgeState.Plague2:

                m_State_text.text = "Plague";
                break;
            case ToothAgeState.Plague3:

                m_State_text.text = "Plague";
                break;
            case ToothAgeState.Cavity1:

                m_State_text.text = "Cavities";
                break;
            case ToothAgeState.Cavity2:
                m_State_text.text = "Cavities";
                break;
            case ToothAgeState.Rotten:

                m_State_text.text = "Rotten";
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        Vector3 sliderPos = Camera.main.WorldToScreenPoint(m_Slider_PlaceHolder.position);
        m_Case_image.transform.position = sliderPos;


        Vector3 stateTextPos = Camera.main.WorldToScreenPoint(m_StateText_PlaceHolder.position);
        m_State_text.transform.position = stateTextPos;
    }
}
