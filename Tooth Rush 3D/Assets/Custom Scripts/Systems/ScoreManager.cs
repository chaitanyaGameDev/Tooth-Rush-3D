using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : GenericSingleton<ScoreManager>
{
    //----------------------------------------------Variables-----------------------------------------------

    public static readonly int ToothPaste_Score = 5;
    public static readonly int Brushing_Score = 25;
    public static readonly int Coin_Score = 3;


    public int CurrentScore { private set; get; }

    //----------------------------------------------Delegate--------------------------------------------------

    public static event Action s_ScoreUpdated_event;

    //----------------------------------------------Methods---------------------------------------------------
  
    private void ResetScore()
    {
        CurrentScore = 0;
    }
    public void UpdateScore(int amount)
    {
        CurrentScore += amount;

        //event
        s_ScoreUpdated_event?.Invoke();
    }

}
