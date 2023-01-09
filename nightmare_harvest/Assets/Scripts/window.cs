using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    bool isSleeping = false;
    bool isAboutToWakeUp = false;
    int count = 0;
    GameObject sleepPlaceholder;
    Transform sleepBubble; 

    // Start is called before the first frame update
    void Start()
    {
        sleepBubble = transform.GetChild(1);
        WakeUp();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (count >= 30 * 10) // only update every 10 seconds
                {
                    RunSleepCycle();
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
            Debug.Log("going to sleep: " + StrB);
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
            Debug.Log("Waking Up");
            WakeUp();
        }
        else if (StrB >= 18)
        {
            Debug.Log("Hitting the snooze button");
            HitSnoozeButton();
        }
    }

    void WakeUp() 
    {
        isSleeping = false;
        isAboutToWakeUp = false;
        sleepBubble.GetComponent<Renderer>().enabled = false;
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
}
