using UnityEngine;
using System.Collections;

public class Timer_Script : MonoBehaviour
{
  public int left_seconds = 30;
  private UnityEngine.UI.Text time;

	// Use this for initialization
	void Awake () {
		time = this.GetComponentInChildren<UnityEngine.UI.Text> ();
    //bubble_generator = GameObject.Find("background").GetComponent<GenerateBubbles>();
		time.text = left_seconds + "";
    InvokeRepeating("decreaseTimeRemaining", TapConstants.start_delay, 1.0f);
	}

	void decreaseTimeRemaining()
	{
    left_seconds--;
    if (!TapConstants.gameover)
    {
      if (left_seconds == 0)
      {
        time.text = "0";
        GameOver();
      }
      else if (left_seconds > 0)
      {
        time.text = left_seconds + "";
      }
    }
	}

	void GameOver ()
	{
    TapConstants.gameover = true;
	}
}
