using UnityEngine;
using System.Collections;
using System.Threading;

public class Finish : MonoBehaviour
{
  private UnityEngine.UI.Text finishText;
  private GUITexture fader;
  private const float _endDelay = 2f;
  private bool startingscene = true;
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
    if (TapConstants.gameover && !finishText.enabled)
    {
      finishText.text = "Score: "+TapConstants.user_score+"\nTap to menu";
      iTween.MoveFrom(gameObject, iTween.Hash("y", 6, "easeInSine", "easeInSine"));
      
      finishText.enabled = true;
      Invoke("DelayInput", _endDelay);
	}
	if (TapConstants.gameover && finishText.enabled)
	{
	  if (Input.GetMouseButton(0) && ended)
	  {
	    TapConstants.gameover = false;
		TapConstants.user_score = 0;
		
	  }
	}
  }

  void DelayInput()
  {
    ended = true;
  }
}
