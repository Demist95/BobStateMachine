using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;

    public GameObject Player;

    public Text YellowCounter, GreenCounter, BlueCounter, TotalCounter;

    Subject subject = new Subject();

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Observer yellow = new YellowCounterObserver(YellowCounter);
        Observer green = new GreenCounterObserver(GreenCounter);
        Observer blue = new BlueCounterObserver(BlueCounter);
        Observer total = new TotalCounterObserver(TotalCounter);

        subject.AddObserver(yellow);
        subject.AddObserver(green);
        subject.AddObserver(blue);
        subject.AddObserver(total);
    }

    public void UpdateSubject(Collider collectible)
    {
        collectible.gameObject.SetActive(false);
        subject.Notify(collectible);
    }
}
