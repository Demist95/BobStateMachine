using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IState
{
    void OnStateEnter(Player player);
    void Update(Player player);
    void OnStateExit(Player player);
}