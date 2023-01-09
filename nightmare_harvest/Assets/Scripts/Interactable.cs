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
        Debug.Log("collision tag: " + collision.tag);
        if(collision.tag == "Player")
        {
            Debug.Log("player entered");
            PlantSeed planter = GameObject.Find("Player").GetComponent<PlantSeed>();
            planter.SetWindow( transform.gameObject.GetComponent<Window>() );
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("player exited");
            PlantSeed planter = GameObject.Find("Player").GetComponent<PlantSeed>();
            planter.SetWindow( null );
        }
    }

    public void Interact()
    {
        Debug.Log("Try to plant a seed");
    }
}
