using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchThirstState : IState
{

    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() != Location.Saloon)
        {
            Debug.Log("Boy, ah sure is thusty! Walking to the saloon");
            player.SetLocation(Location.Saloon);
        }
    }

    public void Update(Player player)
    {
        if (player.Thirsty())
        {
            player.BuyAndDrinkAWhisky();
            Debug.Log("That's mighty fine sippin liquer");
            if (player.Drunk())
            {
                Debug.Log("That whisky strong!!!1!");
                player.ChangeState(new SpendMoneyAtCasinoState());
            }

            else
            {
                Debug.Log("Back to work");
                player.ChangeState(new EnterMineAndDigForNuggetState());
            }
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
