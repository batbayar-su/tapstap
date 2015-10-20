using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	private bool _sceneStarting = true;
	private GUITexture _fader;
	private string level;
	
	void Awake() {
    Screen.orientation = ScreenOrientation.Portrait;
		_fader = GameObject.FindGameObjectWithTag("Fader").guiTexture;
    _fader.transform.localScale = new Vector3(1f, 1f);
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
			Application.LoadLevel(level);
	}

	public void LoadScene(string level)
	{
		if(!_sceneStarting) return;
		_sceneStarting = false;
		this.level = level;
  }
}
