using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSomethingToEatState : IState
{
    public void OnStateEnter(Player player)
    {
        if (player.GetLocation() == Location.Restaurant) return;
        Debug.Log("Mah belly's purrin'. Time to gulp down a corndog yeehaa");
        player.SetLocation(Location.Restaurant);
    }

    public void Update(Player player)
    {
        if (player.Hungry())
        {
            player.BuyAndEatFood();
            Debug.Log("Twas a dang good corndog");
            player.ChangeState(new EnterMineAndDigForNuggetState());
        }

        else
        {
            Debug.Log("ERROR! ERROR! ERROR!");
        }
    }

    public void OnStateExit(Player player)
    {
        Debug.Log("Leavin' the restaurant feelin' damn good");
    }
}
