using UnityEngine;
using System.Collections;

public class Bubbles_Script : MonoBehaviour {

	public float score;

	private Animator animator;
	private UnityEngine.UI.Scrollbar scorebar;

	void Start() {
		//initialize animator
		animator = this.GetComponent<Animator> ();
		//initialize scorebar
		scorebar = FindObjectOfType<UnityEngine.UI.Scrollbar> ();
	}

	void OnMouseDown () {
		if (animator.GetBool ("alive")) {
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", false);
			scorebar.size += score;
			Debug.Log (score);
			if (scorebar.size == 1) {
				Time.timeScale = 0;
			}
		}
	}

	void OnTouchDown () {
		if (animator.GetBool ("alive")) {
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", false);
			scorebar.size += score;
			if (scorebar.size == 1) {
				Time.timeScale = 0;
			}
		}
	}

	void SetScore(float score) {
		this.score = score;
	}
}