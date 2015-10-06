﻿using UnityEngine;
using System.Collections;

public class StartPage : MonoBehaviour 
{  
  private UnityEngine.UI.Text _taptoplay;
	private bool _sceneStarting = true;
	private GUITexture _fader;
	
	void Awake() 
  {
    Screen.orientation = ScreenOrientation.Portrait;;
    _fader = GameObject.FindGameObjectWithTag("Fader").guiTexture;
    _fader.transform.localScale = new Vector3(1f, 1f);
    _taptoplay = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<UnityEngine.UI.Text>()[1];
	}
	
	void OnMouseDown() 
  {
		if(_sceneStarting)
			_sceneStarting = false;
	}
	
	void Update()
	{
    if(_fader.color == Color.black) 
      _taptoplay.color = Color.Lerp(Color.black, Color.white, TapConstants.fadeSpeed * Time.deltaTime);
    else
      _taptoplay.color = Color.Lerp(Color.white, Color.black, TapConstants.fadeSpeed * Time.deltaTime);
    
		if(_sceneStarting)
			StartScene();
		else
			EndScene();
	}
	
	void StartScene ()
	{
		_fader.color = Color.Lerp(_fader.color, Color.clear, TapConstants.fadeSpeed * Time.deltaTime);
		if(_fader.color.a <= 0.5f)
		{
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
