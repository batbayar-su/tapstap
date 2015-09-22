using UnityEngine;
using System.Collections;
using System.Threading;

public class Finish : MonoBehaviour
{
  private UnityEngine.UI.Text finishText;
  private GUITexture fader;
  private const float _endDelay = 2f;
  private bool endingscene = true;
  private bool ended = false;

  // Use this for initialization
  void Start () 
  {
    finishText = GetComponent<UnityEngine.UI.Text>();
	  fader = GameObject.FindGameObjectWithTag("Fader").guiTexture;
	  fader.color = Color.clear;
    fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
  }
	
  // Update is called once per frame
  void Update () 
  {
    if (TapConstants.gameover && !finishText.enabled && endingscene)
    {
      finishText.text = "Score: "+TapConstants.user_score+"\nTap to menu";
      iTween.MoveFrom(gameObject, iTween.Hash("y", 6, "easeInSine", "easeInSine", "onComplete", "SwitchEndingScene"));
      
      finishText.enabled = true;
	  }
    if (TapConstants.gameover && finishText.enabled && !endingscene)
	  {
	    if (Input.GetMouseButton(0))
	    {
	      TapConstants.gameover = false;
		    TapConstants.user_score = 0;
	      ended = true;
	    }
	  }
    if (ended)
    {
      fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
      fader.color = Color.Lerp(fader.color, Color.black, TapConstants.fadeSpeed * Time.deltaTime);

      // If the screen is almost black...
      if (fader.color.a >= 0.7f)
        // ... load the level.
        Application.LoadLevel("MainMenu");
    }
  }

  void SwitchEndingScene() {
    endingscene = false;
  }
}
