using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    List<Observer> observers = new List<Observer>();

    public void Notify(Collider collectible)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify(collectible);
        }
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }
}
