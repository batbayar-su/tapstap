using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

  public int wait_seconds = 5;
  private UnityEngine.UI.Text second_text;

	// Use this for initialization
	void Start () {
    second_text = GetComponent<UnityEngine.UI.Text> ();
    second_text.text = wait_seconds + "";
    iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutExpo", "loopType", "loop", "oncomplete", "ChangeCountdown", "delay", .4));
	}
	
	// Update is called once per frame
  void ChangeCountdown () {
    if(wait_seconds != 0) {
      wait_seconds--;
      if(wait_seconds == 0) {
        second_text.text = "GO!";
      } else {
        second_text.text = wait_seconds + "";
      }
    } else {
      Destroy(gameObject);
    }
	}
}
