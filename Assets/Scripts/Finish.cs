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
  private AudioSource backaudio;
  private float temp_volume = TapConstants.sound_volume;
  private bool fadeout = false, fadein = false, themesong = false;

  void Awake()
  {
    backaudio = GameObject.FindGameObjectWithTag("BackAudio").audio;
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
      fadeout = false;
      fadein = false;
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
      {
        // ... load the level.
        Application.LoadLevel("MainMenu");
      }
    }
  }

  void FixedUpdate() 
  {
    if(!fadeout && !fadein) 
    {
      backaudio.volume = temp_volume;
      if (temp_volume > 0.0) 
      {
        temp_volume -= 0.01f;
      } 
      else 
      {
        fadeout = true;
        if(themesong)
        {
          backaudio.clip = TapConstants.theme_song;
        }
        else 
        {
          backaudio.clip = TapConstants.ending_song;
        }
        backaudio.Play();
      }
    } 
    else if(fadeout && !fadein)
    {
      backaudio.volume = temp_volume;
      if (temp_volume < TapConstants.sound_volume) 
      {
        temp_volume += 0.01f;
      } 
      else 
      {
        fadein = true;
        themesong = true;
      }
    }
  }
  
  void SwitchEndingScene() {
    _endingscene = false;
  }
}
