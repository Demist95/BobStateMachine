using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeAndSleepTilRestedState : IState
{
    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() != Location.shack)
        {
            Debug.Log("Walkin home");
            player.SetLocation(Location.shack);
        }
    }

    public void Update(Player player)
    {
        if (!player.Fatigued())
        {
            Debug.Log("What a God darn fantastic nap! Time to find more gold");
            player.ChangeState(new EnterMineAndDigForNuggetState());
        }

        else
        {
            player.DecreaseFatigue();
            Debug.Log("ZZZZ... ");
        }
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Leaving the house");
    }
}