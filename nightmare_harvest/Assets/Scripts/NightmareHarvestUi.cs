using UnityEngine;
using UnityEngine.UIElements;

public class NightmareHarvestUi : MonoBehaviour {

    private float time = 180;
    private int score = 0;
    private void Update()
    {
        VisualElement game_over_ui = GameObject.Find("Game Over Ui").GetComponent<UIDocument>().rootVisualElement;
        game_over_ui.visible = false;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Label timerLabel = root.Q<Label>("TimerLabel");
        Label scoreLabel = root.Q<Label>("ScoreLabel");

        timerLabel.text = this.getTime();

        if (time <= 0) {
            timerLabel.text = "Time: 0:00";
            root.visible = false;

            game_over_ui.Q<Label>("ScoreLabel").text = "Score: " + score.ToString();
            game_over_ui.visible = true;
        }

        scoreLabel.text = "Score: " + score.ToString();

        Label greenLabel = root.Q<Label>("GreenLabel");
        Label blueLabel = root.Q<Label>("BlueLabel");
        Label redLabel = root.Q<Label>("RedLabel");

        Inventory inventory = GameObject.Find("Player").GetComponent<Inventory>();

        greenLabel.text = "Green: " + inventory.green_seed;
        blueLabel.text = "Blue: " + inventory.blue_seed;
        redLabel.text = "Red: " + inventory.red_seed;
    }
    private string getTime() { 
        time -= Time.deltaTime;
 
        var minutes = Mathf.FloorToInt(time / 60); //Divide the guiTime by sixty to get the minutes.
        var seconds = Mathf.FloorToInt(time % 60); //Use the euclidean division for the seconds.
 
        //update the label value
        return ("Time: " + string.Format ("{0:00} : {1:00}", minutes, seconds));
     }

    public void increaseScore(int amount) {
        score += amount;
    }


	
}