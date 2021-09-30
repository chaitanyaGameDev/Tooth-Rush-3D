using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScreenUI : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    [SerializeField] TextMeshProUGUI m_Coins_Text;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        UpdateCoinsText_OnEnable();

        WinScreenUI.s_NextButtonClicked_event += UpdateCoinsText_OnNextClicked;
    }
    private void OnDisable()
    {
        WinScreenUI.s_NextButtonClicked_event -= UpdateCoinsText_OnNextClicked;
    }

    private void UpdateCoinsText_OnEnable()
    {
        int savedCoins = PlayerPrefs.GetInt(SimpleSaveSystem.s_CoinsKey,0);

        m_Coins_Text.text = savedCoins.ToString();
    }

    private void UpdateCoinsText_OnNextClicked()
    {
        int savedCoins = PlayerPrefs.GetInt(SimpleSaveSystem.s_CoinsKey, 0);

     
        m_Coins_Text.text = savedCoins.ToString();
    }
}
