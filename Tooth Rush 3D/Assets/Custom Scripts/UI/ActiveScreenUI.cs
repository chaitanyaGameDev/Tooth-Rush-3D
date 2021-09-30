using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveScreenUI : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [SerializeField] TextMeshProUGUI m_Level_Text;
    [SerializeField] TextMeshProUGUI m_Score_Text;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        ScoreManager.s_ScoreUpdated_event += UpdateScoreText;
    }
    private void OnDisable()
    {
        ScoreManager.s_ScoreUpdated_event -= UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        m_Score_Text.text = ScoreManager.Instance.CurrentScore.ToString();
    }
  
}
