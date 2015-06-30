using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Bubbles_Script : MonoBehaviour {

	public float score;

	private Animator animator;
  private AudioSource audio;

	private UnityEngine.UI.Text score_num;
	private float lifetime = .5f;
	private float timecount = 0f;

	void Start() {
		animator = gameObject.GetComponent<Animator> ();
		score_num = GameObject.Find("ScoreNum").GetComponent<UnityEngine.UI.Text>();
    audio = GetComponent<AudioSource>();
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
		if (!TapConstants.gameover && (animator.GetBool ("alive") || animator.GetBool ("over"))) {
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", true);

			string temp = ((System.Convert.ToInt32(score_num.text) + score) + "").PadLeft(7, '0');
			score_num.text = temp;

      audio.Play();
		}
	}

	void OnTouchDown () {
    if (!TapConstants.gameover && (animator.GetBool ("alive") || animator.GetBool ("over"))) {
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", true);

			string temp = ((System.Convert.ToInt32(score_num.text) + score) + "").PadLeft(7, '0');
      score_num.text = temp;

			audio.Play();
			Handheld.Vibrate();
		}
	}
}