using UnityEngine;

public class Inventory : MonoBehaviour
{
	public int green_seed;
	public int blue_seed;
	public int red_seed;
	private void Awake()
	{
		green_seed = 5;
		blue_seed = 3;
		red_seed = 3;
	}

}