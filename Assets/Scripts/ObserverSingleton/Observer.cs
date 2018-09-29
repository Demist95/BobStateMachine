using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Observer
{
    protected Text TextCounter;
    protected int Count = 0;

    protected Observer(Text textCounter)
    {
        TextCounter = textCounter;
        UpdateText();
    }

    public abstract void OnNotify(Collider collectible);
    protected abstract void UpdateText();
}

public class YellowCounterObserver : Observer
{
    public YellowCounterObserver(Text textCounter)
        : base(textCounter){}

    public override void OnNotify(Collider collectible)
    {
        if (collectible.gameObject.CompareTag("YellowCollectible"))
        {
            ++Count;
            UpdateText();
        }
    }

    protected override void UpdateText()
    {
        TextCounter.text = "Yellow: " + Count.ToString();
    }
}

public class GreenCounterObserver : Observer
{
    public GreenCounterObserver(Text textCounter)
        : base(textCounter){}

    public override void OnNotify(Collider collectible)
    {
        if (collectible.gameObject.CompareTag("GreenCollectible"))
        {
            ++Count;
            UpdateText();
        }
    }

    protected override void UpdateText()
    {
        TextCounter.text = "Green: " + Count.ToString();
    }
}

public class BlueCounterObserver : Observer
{
    public BlueCounterObserver(Text textCounter)
        : base(textCounter){}

    public override void OnNotify(Collider collectible)
    {
        if (collectible.gameObject.CompareTag("BlueCollectible"))
        {
            ++Count;
            UpdateText();
        }
    }

    protected override void UpdateText()
    {
        TextCounter.text = "Blue: " + Count.ToString();
    }
}

public class TotalCounterObserver : Observer
{
    public TotalCounterObserver(Text textCounter)
        : base(textCounter){}

    public override void OnNotify(Collider collectible)
    {
        ++Count;
        UpdateText();
    }

    protected override void UpdateText()
    {
        TextCounter.text = "Total: " + Count.ToString();
    }
}