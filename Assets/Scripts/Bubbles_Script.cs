using UnityEngine;
using System.Collections;

public class Bubbles_Script : MonoBehaviour {

	void OnMouseDown () {
		Debug.Log ("clicking on bubble");
		//...then set the current bubble to that position.
		gameObject.transform.position = new Vector3(-400, -400);
	}

}