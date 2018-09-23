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

    }

    public void OnStateExit(Player player)
    {

    }
}
