using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    bool isSleeping = false;
    bool isAboutToWakeUp = false;
    int count = 0;
    int seedLevel = 0;
    GameObject sleepPlaceholder;
    Transform sleepBubble;
    UnityEngine.U2D.Animation.SpriteLibrary sl;
    string seedType = null;

    // Start is called before the first frame update
    void Start()
    {
        sleepBubble = transform.GetChild(1);
        sl = sleepBubble.GetComponent<UnityEngine.U2D.Animation.SpriteLibrary>();
        WakeUp();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (count >= 30 * 10) // only update every 10 seconds
                {
                    RunSleepCycle();
                    PromoteSeedLevel();
                    count = 0;
                }

            if (count % 30 == 0)
            {
                FlickerIfWakingUp();
            }
            count++;
        }
    }

    void RunSleepCycle()
    {
            if ( isSleeping )
            {
                TryToWakeUp();
            }
            else
            {
                TryToGotoSleep();
            }
                
    }

    void TryToGotoSleep() 
    {
        var StrB = Random.Range(0, 20);
        if (StrB >= 18)
        {
            GoToSleep();
        }
    }

    void GoToSleep()
    {
        isSleeping = true;
        sleepBubble.GetComponent<Renderer>().enabled = true;
    }

    void TryToWakeUp()
    {
        var StrB = Random.Range(0, 20);
        if (StrB >= 12 && isAboutToWakeUp)
        {
            WakeUp();
        }
        else if (StrB >= 18)
        {
            HitSnoozeButton();
        }
    }

    void WakeUp() 
    {
        isSleeping = false;
        isAboutToWakeUp = false;
        sleepBubble.GetComponent<Renderer>().enabled = false;
        seedType = null;
        sleepBubble.GetComponent<SpriteRenderer>().sprite = sl.GetSprite("dream", "0");
    }

    void HitSnoozeButton()
    {
        isAboutToWakeUp = true;
    }

    void FlickerIfWakingUp() {
        if (isAboutToWakeUp)
        {
            sleepBubble.GetComponent<Renderer>().enabled = !sleepBubble.GetComponent<Renderer>().enabled;
        }
    }

    public bool CanPlantSeedHere()
    {   
        return isSleeping && !HasSeed();
    }

    public bool HasSeed() 
    {
        return seedType != null;
    }

    public void PlantSeed(string seedType)
    {
        this.seedType = seedType;
        this.seedLevel = 0;
        sleepBubble.GetComponent<SpriteRenderer>().sprite = sl.GetSprite(seedType, "" + this.seedLevel);
    }

    void PromoteSeedLevel() {
        if (seedLevel < 2 && HasSeed()) {
            seedLevel++;
            sleepBubble.GetComponent<SpriteRenderer>().sprite = sl.GetSprite(seedType, "" + this.seedLevel);
        }
    }

    public int Harvest()
    {
        int score = 100 * ( seedLevel + 1 ) ;
        WakeUp();
        return score;
    }
}
