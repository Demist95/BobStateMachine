using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMineAndDigForNuggetState : IState
{

    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() == Location.Goldmine) return;
        Debug.Log("Walkin' to the goldmine");
        player.SetLocation(Location.Goldmine);
    }

    public void Update(Player player)
    {
        player.AddToGoldCarried(1);

        player.IncreaseFatigue();

        Debug.Log("Pickin' up a nugget");

        if (player.PocketsFull())
        {
            Debug.Log("Pockets full. Going to bank");
            player.ChangeState(new VisitBankAndDepositGoldState());
        }

        if (!player.Thirsty()) return;
        Debug.Log("Thirst AF! Going for some beer");
        player.ChangeState(new QuenchThirstState());
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Exit gold mine");
    }
}
