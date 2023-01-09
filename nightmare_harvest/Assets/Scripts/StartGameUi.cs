using UnityEngine;
using UnityEngine.UIElements;

public class StartGameUi : MonoBehaviour
{

	private void Awake()
	{
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		root.Q<Button>("StartButton").clicked += () => StartGame();
		root.Q<Button>("QuitButton").clicked += () => QuitGame();
	}

	public void StartGame()
	{
		Player player = GameObject.Find("Player").GetComponent<Player>();
		Camera camera = GameObject.Find("Camera").GetComponent<Camera>();
		Inventory inventory = GameObject.Find("Player").GetComponent<Inventory>();
		VisualElement main_ui = GameObject.Find("Ui").GetComponent<UIDocument>().rootVisualElement;
		NightmareHarvestUi harvest_ui = GameObject.Find("Ui").GetComponent<NightmareHarvestUi>();


		harvest_ui.score = 0;
		harvest_ui.time = 180;

		inventory.green_seed = 5;
		inventory.blue_seed = 3;
		inventory.red_seed = 3;

		player.transform.SetPositionAndRotation(new Vector3((float)-13.68, (float)-4.07, -5), player.transform.rotation);
		camera.transform.SetPositionAndRotation(new Vector3((float)-13.68, (float)-1.9, camera.transform.position.z), player.transform.rotation);

		// Reset all starting variables here

		VisualElement game_over_ui = GameObject.Find("Game Over Ui").GetComponent<UIDocument>().rootVisualElement;
		main_ui.visible = true;
		game_over_ui.visible = false;

		VisualElement root = GetComponent<UIDocument>().rootVisualElement;
		root.visible = false;
	}

	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}
}