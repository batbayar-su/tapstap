using UnityEngine;
using System.Collections;

public class Bubbles_Script : MonoBehaviour {

	public float score;

	public Animator animator;

	private UnityEngine.UI.Text score_num;
	private float lifetime = .5f;
	private float timecount = 0f;

	void Start() {
		animator = gameObject.GetComponent<Animator> ();
		score_num = GameObject.Find("ScoreNum").GetComponent<UnityEngine.UI.Text>();;
	}
	
	void Update () { 
		timecount += Time.deltaTime;
		if(timecount > lifetime)
		{
			animator.SetBool ("alive", false);
			animator.SetBool ("over", true);
		}
	}

	void OnMouseDown () {
		if (animator.GetBool ("alive") || animator.GetBool ("over")) {
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", true);

      		Handheld.Vibrate();
			string temp = ((System.Convert.ToInt32(score_num.text) + score) + "").PadLeft(7, '0');
			score_num.text = temp;
		}
	}

	void OnTouchDown () {
		if (animator.GetBool ("alive") || animator.GetBool ("over")) {
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", true);
			
			Handheld.Vibrate();
			string temp = ((System.Convert.ToInt32(score_num.text) + score) + "").PadLeft(7, '0');
			score_num.text = temp;
		}
	}

	void SetScore(float score) {
		this.score = score;
	}
}