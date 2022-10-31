using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMitchManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goalTotalDisplay;
    
    public int goalDollarMin;
    public int goalDollarMax;
 
    private int goalDollars;
    private int goalCents;

    public decimal CurrentGoalTotal;

    void Start()
    {
        DetermineNewGoalTotal();
    }


    private void DetermineNewGoalTotal()
    {
        goalDollars = Random.Range(goalDollarMin, goalDollarMax);
        goalCents = Random.Range(0, 99);

        CurrentGoalTotal = (goalDollars + (goalCents/100));

        _goalTotalDisplay.text = goalDollars + "." + goalCents;
    }

    public void CheckTotal(decimal playerTotal)
    {
        if (playerTotal > CurrentGoalTotal)
        {
            Debug.Log("Bust!");
        }
        else if (playerTotal == CurrentGoalTotal)
        {
            Debug.Log("win!");
        }
    }


}
