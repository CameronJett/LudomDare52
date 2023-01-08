using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    bool isSleeping = false;
    bool isAboutToWakeUp = false;
    int count = 0;
    GameObject sleepPlaceholder;

    // Start is called before the first frame update
    void Start()
    {

        // Debug.Log(gameObject.transform.Find("SleepPlaceholder"));
        Transform t1 = transform.GetChild(0).GetChild(0);
        t1.GetComponent<Renderer>().enabled = false;
        // sleepPlaceholder = gameObject.transform.Find("SleepPlaceholder").GetComponent<GameObject>();
        // sleepPlaceholder.GetComponent<Renderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (count >= 60 * 30) // only update every 30 seconds
                {
                    RunSleepCycle();
                    count = 0;
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
            isSleeping = true;
        }
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
    }

    void HitSnoozeButton()
    {
        isAboutToWakeUp = true;
    }
}
