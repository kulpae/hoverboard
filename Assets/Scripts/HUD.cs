using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Font font;
	public Text velocityLabel, scoreLabel, timeLabel;
	float velocity, score, time;
	void OnGUI(){
		GUIStyle style = new GUIStyle (GUI.skin.GetStyle("label"));
		style.fontSize = 24;
		style.font = font;
		Rect left = new Rect(120, 150, Screen.width/2 - 120, 50);
		Rect right = new Rect(Screen.width/2 + 120, 150, Screen.width/2 - 120, 50);

		GUILayout.BeginArea(left);
		GUILayout.BeginHorizontal();
		GUILayout.Label("Speed: " +  ((int)(velocity * 10f)).ToString(), style);
		GUILayout.Label(time + "s", style);
		GUILayout.Label("Score: " + score, style);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		GUILayout.BeginArea(right);
		GUILayout.BeginHorizontal();
		GUILayout.Label("Speed: " +  ((int)(velocity * 10f)).ToString(), style);
		GUILayout.Label(time + "s", style);
		GUILayout.Label("Score: " + score, style);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		
	}


	public void SetValues (int score, int time, float velocity) {
		this.score = score;
		this.time = time;
		this.velocity = velocity;

		velocityLabel.text = "Speed: " +  ((int)(velocity * 10f)).ToString();
		scoreLabel.text = "Points: " +  score.ToString();
		timeLabel.text = time.ToString() + "s";
	}
}