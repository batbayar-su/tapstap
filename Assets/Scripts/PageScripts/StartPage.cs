using UnityEngine;
using System.Collections;

public class StartPage : MonoBehaviour 
{  
  private UnityEngine.UI.Text _taptoplay;
	private bool _sceneStarting = true;
  private GUITexture _fader;
  private AudioSource backaudio;
	
	void Awake() 
  {
    Screen.orientation = ScreenOrientation.Portrait;;
    _fader = GameObject.FindGameObjectWithTag("Fader").guiTexture;
    _fader.transform.localScale = new Vector3(1f, 1f);
    _taptoplay = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<UnityEngine.UI.Text>()[1];
    backaudio = GameObject.FindGameObjectWithTag("BackAudio").audio;
    backaudio.volume = TapConstants.sound_volume;
	}
	
	void OnMouseDown() 
  {
		if(_sceneStarting)
			_sceneStarting = false;
	}
	
	void Update()
	{
    if(_sceneStarting)
      StartScene();
    else
      EndScene();
	}
	
	void StartScene ()
  {
    _fader.color = Color.Lerp(_fader.color, Color.clear, TapConstants.fadeSpeed * Time.deltaTime);
    if(_fader.color.a <= 0.05f)
    {
      // ... set the colour to clear and disable the GUITexture.
      _fader.color = Color.clear;
      _fader.enabled = false;
    }
	}
	
	public void EndScene ()
  {
    // Make sure the texture is enabled.
    _fader.enabled = true;
    
    // Start fading towards black.
    _fader.color = Color.Lerp(_fader.color, Color.black, TapConstants.fadeSpeed * Time.deltaTime);
    
    // If the screen is almost black...
    if(_fader.color.a >= 0.7f)
      // ... reload the level.
      Application.LoadLevel("MainMenu");
	}
}
