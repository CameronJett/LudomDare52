using UnityEngine;
using UnityEngine.UIElements;

public class NightmareHarvestUi : MonoBehaviour {

    private float time = 300;
    private int score = 0;
    private void Update()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Label timerLabel = root.Q<Label>("TimerLabel");
        Label scoreLabel = root.Q<Label>("ScoreLabel");

        timerLabel.text = this.getTime();

        if (time <= 0) {
            // TODO: end game
            timerLabel.text = "Time: 0:00";
        }

        scoreLabel.text = "Score: " + score.ToString();
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