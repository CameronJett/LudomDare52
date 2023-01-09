using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory inventory;
    Window window;

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        Debug.Log("Plant Seed loaded");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CycleInventory();
            Debug.Log("R Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            TryToPlantSeed();
            Debug.Log("E Pressed");
        }
    }

    void CycleInventory() 
    {
        inventory.Cycle();
    }

    void TryToPlantSeed()
    {
        if (window != null && window.CanPlantSeedHere())
        {
            window.PlantSeed( inventory.UseSeed() );
        }
    }

    public void SetWindow(Window window)
    {
        this.window = window;
    }
}
