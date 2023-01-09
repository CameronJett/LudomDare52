using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool interactable = true;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlantSeed planter = GameObject.Find("Player").GetComponent<PlantSeed>();
            Window window = transform.gameObject.GetComponent<Window>();
            if (window.HasSeed())
            {
                NightmareHarvestUi ui = GameObject.Find("Ui").GetComponent<NightmareHarvestUi>();
                ui.increaseScore(window.Harvest());
            }
            else 
            {
                planter.SetWindow( transform.gameObject.GetComponent<Window>() );
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlantSeed planter = GameObject.Find("Player").GetComponent<PlantSeed>();
            planter.SetWindow( null );
        }
    }

    public void Interact()
    {
        Debug.Log("Try to plant a seed");
    }
}
