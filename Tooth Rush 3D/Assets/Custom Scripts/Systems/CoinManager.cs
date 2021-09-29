using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinManager : GenericSingleton<CoinManager>
{
    //----------------------------------------------Variables-----------------------------------------------

    public static readonly int PerPiece_Coin = 1;

    public int CurrentCoins { private set; get; }

    //----------------------------------------------Delegate--------------------------------------------------

    public static event Action s_CoinsUpdated_event;

    //----------------------------------------------Methods---------------------------------------------------

    private void ResetCoins()
    {
        CurrentCoins = 0;
    }
    public void UpdateCoins(int amount)
    {
        CurrentCoins += amount;

        //event
        s_CoinsUpdated_event?.Invoke();
    }

}
