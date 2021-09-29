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
   

    private void UpdateScoreText(int value)
    {
        m_Score_Text.text = value.ToString();
    }
  
}
