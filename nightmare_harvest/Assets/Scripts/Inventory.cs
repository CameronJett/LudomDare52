using UnityEngine;

public class Inventory : MonoBehaviour
{
	public int green_seed;
	public int blue_seed;
	public int red_seed;

	private string[] seedTypes = { "green", "blue", "red" };
	private int seedIndex = 0;

	private void Awake()
	{
		green_seed = 5;
		blue_seed = 3;
		red_seed = 3;
	}

	public void Cycle() 
	{
		if (seedIndex == 2) 
		{
			seedIndex = 0;
		} else 
		{
			seedIndex++;
		}
		Debug.Log( "seed index: " + seedIndex + " current seed: " + seedTypes[seedIndex] );
	}

	public string UseSeed()
	{
		if (seedIndex == 0)
		{
			green_seed--;
		}
		else if (seedIndex == 1)
		{
			blue_seed--;
		}
		else if (seedIndex == 2)
		{
			red_seed--;
		}
		return seedTypes[seedIndex];
	}

}