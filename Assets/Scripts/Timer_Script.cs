using UnityEngine;
using System.Collections;

public class Timer_Script : MonoBehaviour
{
  public int left_seconds = 5;

	private UnityEngine.UI.Text time;
  private GenerateBubbles bubble_generator;

	// Use this for initialization
	void Start () {
		time = this.GetComponentInChildren<UnityEngine.UI.Text> ();
    //bubble_generator = GameObject.Find("background").GetComponent<GenerateBubbles>();
    bubble_generator = GameObject.FindGameObjectWithTag("Background").GetComponent<GenerateBubbles>();
		time.text = left_seconds + "";
		InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
	}

	void Update() {
		if (left_seconds < 0) {
			GameOver();
		} else {
			time.text = left_seconds + "";
		}
	}	
	
	void decreaseTimeRemaining()
	{
		left_seconds--;
	}

	void GameOver ()
	{
    TapConstants.gameover = true;
	}
}
