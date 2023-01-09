using UnityEngine;

public class SeedCollectInteraction : MonoBehaviour
{
	private Player player;
	private Inventory inventory;

	private bool collected;
	public int color_seed;

	private void Awake()
	{
		player = GameObject.Find("Player").GetComponent<Player>();
		inventory = GameObject.Find("Player").GetComponent<Inventory>();

		collected = true;

		SetSprite();
	}

	private void Update()
	{
		// Seeds regenerate when the player moves up and can't see them
		if (player.transform.position.y > 20)
		{
			collected = false;

			SetSprite();
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collected && collision.tag == "Player")
		{
			collected = true;

			SetSprite();

			if (color_seed == 0)
            {
				inventory.green_seed += Random.Range(2, 7);
			}
			else if (color_seed == 1)
			{
				inventory.blue_seed += Random.Range(2, 5);
			}
			else if (color_seed == 2)
			{
				inventory.red_seed += Random.Range(2, 4);
			}

		}
	}

	private void SetSprite()
    {
		Transform collectedTransform = transform.Find("Collected");
		Transform uncollectedTransform = transform.Find("Uncollected");

		uncollectedTransform.GetComponent<SpriteRenderer>().enabled = !collected;
		collectedTransform.GetComponent<SpriteRenderer>().enabled = collected;
	}
}