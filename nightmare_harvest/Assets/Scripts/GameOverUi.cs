using UnityEngine;
using UnityEngine.UIElements;

public class GameOverUi : MonoBehaviour {

	private void Awake()
	{
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;
		StartGameUi start_ui = GameObject.Find("Start Game Ui").GetComponent<StartGameUi>();

		root.Q<Button>("RestartButton").clicked += () => start_ui.StartGame();
		root.Q<Button>("QuitButton").clicked += () => start_ui.QuitGame();
	}

}