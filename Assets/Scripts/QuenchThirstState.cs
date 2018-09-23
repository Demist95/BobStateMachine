using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchThirstState : IState
{

    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() != Location.saloon)
        {
            Debug.Log("Boy, ah sure is thusty! Walking to the saloon");
            player.SetLocation(Location.saloon);
        }
    }

    public void Update(Player player)
    {
        if (player.Thirsty())
        {
            player.BuyAndDrinkAWhisky();
            Debug.Log("That's mighty fine sippin liquer");
            player.ChangeState(new EnterMineAndDigForNuggetState());
        }

        else
        {
            Debug.Log("ERROR! ERROR! ERROR!");
        }
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Leaving the saloon, feelin' good");
    }
}
