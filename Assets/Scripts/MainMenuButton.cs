using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	Texture2D image;
	
	void  Start (){
		image = Resources.Load("yeah") as Texture2D;
		Debug.Log("Hello meun0503");

	}
	
	void  OnGUI (){
		if (GUI.Button (new Rect (20, 40, 80, 20), "Level 1")) {
			Debug.Log ("WW Click");
			Application.LoadLevel("level2");
		}
	}
	void StartGame(){
		Debug.Log("Hello meun0503");
		Application.LoadLevel("Menu0503");
	}
	void ExitQuit(){
		Application.Quit();
	}


}
