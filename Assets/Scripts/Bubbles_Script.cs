using UnityEngine;
using System.Collections;

public class Bubbles_Script : MonoBehaviour {

	private Animator animator;

	void Start() {
		animator = this.GetComponent<Animator> ();
	}

	void OnMouseDown () {
		//set the hitten bubble position to out of screen.
		animator.SetBool("alive", false);
	}
}