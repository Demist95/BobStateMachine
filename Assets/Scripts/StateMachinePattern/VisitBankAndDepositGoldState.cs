using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitBankAndDepositGoldState : IState
{

    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() == Location.Bank) return;
        Debug.Log("Goin' to the bank. Yes siree");
        player.SetLocation(Location.Bank);
    }

    public void Update(Player player)
    {
        player.AddToWealth(player.GetGoldCarried());
        player.SetGoldCarried(0);

        Debug.Log("Depositing gold. Total savings now: " + player.GetMoneyInBank());

        if (player.GetMoneyInBank() >= player.GetComfortLevel())
        {
            Debug.Log("WooHoo! Rich enough for now. Back home to mah li'lle lady");
            player.ChangeState(new GoHomeAndSleepTilRestedState());
        }

        else
        {
            Debug.Log("I need me some more of that Mooo-la. Back to work");
            player.ChangeState(new EnterMineAndDigForNuggetState());
        }
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Leavin' the bank");
    }
}
