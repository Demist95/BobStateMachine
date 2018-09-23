using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Location { shack, goldmine, bank, saloon, restaurant, casino }

public class Player : MonoBehaviour
{
    private float timeToGo;

    private const int ComfortLevel = 5;
    private const int MaxNuggets = 3;
    private const int ThirstLevel = 5;
    private const int TirednessThreshold = 5;
    private const int HungerLevel = 8;

    private IState m_currentState;
    private Location m_location;
    private int m_goldCarried;
    private int m_moneyInBank;
    private int m_thirst;
    private int m_fatigue;
    private int m_hunger;

    //public methods:
    //-----------------------------------------------------------------------------
    public void ChangeState(IState newState)
    {
        m_currentState.OnStateExit(this);
        m_currentState = newState;
        m_currentState.OnStateEnter(this);
    }

    public IState GetCurrentState()
    {
        return m_currentState;
    }

    //-----------------------------------------------------------------------------
    public Location GetLocation()
    {
        return m_location;
    }

    public void SetLocation(Location location)
    {
        m_location = location;
    }

    //-----------------------------------------------------------------------------
    public int GetGoldCarried()
    {
        return m_goldCarried;
    }

    public void SetGoldCarried(int val)
    {
        m_goldCarried = val;
    }

    public void AddToGoldCarried(int val)
    {
        m_goldCarried += val;
        if (m_goldCarried < 0)
            m_goldCarried = 0;
    }

    public bool PocketsFull()
    {
        return m_goldCarried >= MaxNuggets;
    }

    //-----------------------------------------------------------------------------
    public int GetMoneyInBank()
    {
        return m_moneyInBank;
    }

    public void AddToWealth(int val)
    {
        m_moneyInBank += val;
    }

    public void RemoveFromBank(int val)
    {
        m_moneyInBank -= val;
    }

    //-----------------------------------------------------------------------------
    public int GetThirst()
    {
        return m_thirst;
    }

    public void IncreaseThirst()
    {
        m_thirst += 1;
    }

    public bool Thirsty()
    {
        return m_thirst >= ThirstLevel;
    }

    public void BuyAndDrinkAWhisky()
    {
        m_thirst = 0;
        m_moneyInBank -= 2;
    }

    public bool Drunk()
    {
        return Random.value > 0.50f ? true : false;
    }

    //-----------------------------------------------------------------------------
    public int GetFatigue()
    {
        return m_fatigue;
    }

    public void IncreaseFatigue()
    {
        m_fatigue += 1;
    }

    public void DecreaseFatigue()
    {
        m_fatigue -= 1;
    }

    public bool Fatigued()
    {
        return m_fatigue >= TirednessThreshold;
    }

    //-----------------------------------------------------------------------------
    public int GetHunger()
    {
        return m_hunger;
    }

    public void IncreaseHunger()
    {
        m_hunger += 1;
    }

    public bool Hungry()
    {
        return m_hunger >= HungerLevel;
    }

    public void BuyAndEatFood()
    {
        m_hunger = 0;
        m_moneyInBank -= 2;
    }

    //-----------------------------------------------------------------------------
    public bool WinMoney()
    {
        return Random.value > 0.66f ? true : false;
    }

    //-----------------------------------------------------------------------------
    public int GetComfortLevel()
    {
        return ComfortLevel;
    }

    //private methods:
    private void Awake()
    {
        m_currentState = new EnterMineAndDigForNuggetState();
        m_location = Location.goldmine;
    }

    private void Start()
    {
        timeToGo = Time.fixedTime + 0.0f;
    }

    // Run every 3 seconds
    private void FixedUpdate()
    {
        if (Time.fixedTime >= timeToGo)
        {
            IncreaseHunger();
            IncreaseThirst();
            m_currentState.Update(this);

            timeToGo = Time.fixedTime + 3.0f;
        }

    }
}