using UnityEngine;
using System.Collections;
using System.Threading;

public class Finish : MonoBehaviour
{
  private UnityEngine.UI.Text _finishText;
  private GUITexture _fader;
  private const float _endDelay = 2f;
  private bool _endingscene = true;
  private bool _ended = false;
  
  // Use this for initialization
  void Start () 
  {
    _finishText = GetComponent<UnityEngine.UI.Text>();
    _fader = GameObject.FindGameObjectWithTag("Fader").guiTexture;
    _fader.color = Color.clear;
    _fader.transform.localScale = new Vector3(1f, 1f);
  }
  
  // Update is called once per frame
  void Update () 
  {
    if (TapConstants.gameover && !_finishText.enabled && _endingscene)
    {
      _finishText.text = "Score: "+TapConstants.user_score+"\nTap to menu";
      iTween.MoveFrom(gameObject, iTween.Hash("y", 6, "easeInSine", "easeInSine", "onComplete", "SwitchEndingScene"));
      
      _finishText.enabled = true;
    }
    if (TapConstants.gameover && _finishText.enabled && !_endingscene)
    {
      if (Input.GetMouseButton(0) || Input.touchCount > 0)
      {
        TapConstants.gameover = false;
        TapConstants.user_score = 0;
        _ended = true;
      }
    }
    if (_ended)
    {
      _fader.color = Color.Lerp(_fader.color, Color.black, TapConstants.fadeSpeed * Time.deltaTime);
      
      // If the screen is almost black...
      if (_fader.color.a >= 0.7f)
        // ... load the level.
        Application.LoadLevel("MainMenu");
    }
  }
  
  void SwitchEndingScene() {
    _endingscene = false;
  }
}
