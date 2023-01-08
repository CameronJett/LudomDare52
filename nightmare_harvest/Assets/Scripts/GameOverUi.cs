using UnityEngine;
using UnityEngine.UIElements;

public class GameOverUi : MonoBehaviour {

	private void Awake()
	{
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		root.Q<Button>("RestartButton").clicked += () => Debug.Log("RESTART CLICKED TODO");
		root.Q<Button>("QuitButton").clicked += () => QuitGame();
	}

	private void QuitGame() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
			Application.Quit();
		}
}