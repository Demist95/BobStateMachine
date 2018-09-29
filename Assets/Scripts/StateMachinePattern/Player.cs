using UnityEngine;

public enum Location { Shack, Goldmine, Bank, Saloon, Restaurant, Casino }

public class Player : MonoBehaviour
{
    private float _timeToGo;

    private const int ComfortLevel = 5;
    private const int MaxNuggets = 3;
    private const int ThirstLevel = 5;
    private const int TirednessThreshold = 5;
    private const int HungerLevel = 8;

    private IState _currentState;
    private Location _location;
    private int _goldCarried;
    private int _moneyInBank;
    private int _thirst;
    private int _fatigue;
    private int _hunger;

    //public methods:
    //-----------------------------------------------------------------------------
    public void ChangeState(IState newState)
    {
        _currentState.OnStateExit(this);
        _currentState = newState;
        _currentState.OnStateEnter(this);
    }

    public IState GetCurrentState()
    {
        return _currentState;
    }

    //-----------------------------------------------------------------------------
    public Location GetLocation()
    {
        return _location;
    }

    public void SetLocation(Location location)
    {
        _location = location;
    }

    //-----------------------------------------------------------------------------
    public int GetGoldCarried()
    {
        return _goldCarried;
    }

    public void SetGoldCarried(int val)
    {
        _goldCarried = val;
    }

    public void AddToGoldCarried(int val)
    {
        _goldCarried += val;
        if (_goldCarried < 0)
            _goldCarried = 0;
    }

    public bool PocketsFull()
    {
        return _goldCarried >= MaxNuggets;
    }

    //-----------------------------------------------------------------------------
    public int GetMoneyInBank()
    {
        return _moneyInBank;
    }

    public void AddToWealth(int val)
    {
        _moneyInBank += val;
    }

    public void RemoveFromBank(int val)
    {
        _moneyInBank -= val;
    }

    //-----------------------------------------------------------------------------
    public int GetThirst()
    {
        return _thirst;
    }

    public void IncreaseThirst()
    {
        _thirst += 1;
    }

    public bool Thirsty()
    {
        return _thirst >= ThirstLevel;
    }

    public void BuyAndDrinkAWhisky()
    {
        _thirst = 0;
        _moneyInBank -= 2;
    }

    public bool Drunk()
    {
        return Random.value > 0.50f ? true : false;
    }

    //-----------------------------------------------------------------------------
    public int GetFatigue()
    {
        return _fatigue;
    }

    public void IncreaseFatigue()
    {
        _fatigue += 1;
    }

    public void DecreaseFatigue()
    {
        _fatigue -= 1;
    }

    public bool Fatigued()
    {
        return _fatigue >= TirednessThreshold;
    }

    //-----------------------------------------------------------------------------
    public int GetHunger()
    {
        return _hunger;
    }

    public void IncreaseHunger()
    {
        _hunger += 1;
    }

    public bool Hungry()
    {
        return _hunger >= HungerLevel;
    }

    public void BuyAndEatFood()
    {
        _hunger = 0;
        _moneyInBank -= 2;
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
        _currentState = new EnterMineAndDigForNuggetState();
        _location = Location.Goldmine;
    }

    private void Start()
    {
        _timeToGo = Time.fixedTime + 0.0f;
    }

    // Run every 3 seconds
    private void FixedUpdate()
    {
        if (!(Time.fixedTime >= _timeToGo)) return;
        IncreaseHunger();
        IncreaseThirst();
        _currentState.Update(this);
        _timeToGo = Time.fixedTime + 3.0f;
    }
}