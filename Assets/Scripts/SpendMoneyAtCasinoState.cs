using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendMoneyAtCasinoState : IState
{
    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() != Location.casino)
        {
            Debug.Log("Time to spend some of my hard-earned cash.");
            player.SetLocation(Location.restaurant);
        }
    }

    public void Update(Player player)
    {
        // win
        if (player.WinMoney())
        {
            player.AddToGoldCarried(3);
            Debug.Log("w00t. time to cash out");
            player.ChangeState(new VisitBankAndDepositGoldState());
        }

        // lose
        else
        {
            player.RemoveFromBank(3);
            Debug.Log("Dangit, now my moneys gone");
            player.ChangeState(new GoHomeAndSleepTilRestedState());
        }
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Leavin' casino");
    }
}
