using UnityEngine;
using UnityEngine.UIElements;

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

		VisualElement ui = GameObject.Find("Ui").GetComponent<UIDocument>().rootVisualElement;
		VisualElement greenStar = ui.Q<VisualElement>("GreenStar");
		VisualElement blueStar = ui.Q<VisualElement>("BlueStar");
		VisualElement redStar = ui.Q<VisualElement>("RedStar");

		if (seedIndex == 0)
        {
			greenStar.visible = true;
			blueStar.visible = false;
			redStar.visible = false;
		} 
		else if (seedIndex == 1) {
			greenStar.visible = false;
			blueStar.visible = true;
			redStar.visible = false;
		} 
		else
		{
			greenStar.visible = false;
			blueStar.visible = false;
			redStar.visible = true;
		}
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

	public bool HasSeed()
	{
		if (seedIndex == 0)
		{
			return green_seed > 0;
		}
		else if (seedIndex == 1)
		{
			return blue_seed > 0;
		}
		else if (seedIndex == 2)
		{
			return red_seed > 0;
		}
		return false;
	}

}