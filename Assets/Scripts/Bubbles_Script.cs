using UnityEngine;
using System.Collections;

public class Bubbles_Script : MonoBehaviour {
	
	public UnityEngine.UI.Scrollbar scorebar;
	public float score = 0;

	private Animator animator;

	void Start() {
		//initialize animator
		animator = this.GetComponent<Animator> ();
		//initialize scorebar
		scorebar = (UnityEngine.UI.Scrollbar) this.transform.parent.GetComponent("Score").GetComponent("ScrollBar");
	}

	void OnMouseDown () {
		//set the hitten bubble position to out of screen.
		animator.SetBool("alive", false);
		score += 10;
		//scorebar.size = score / 100f;
		Debug.Log ("Score = "+score+", Size = "+scorebar.size);
	}
}