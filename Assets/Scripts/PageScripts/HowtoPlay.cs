using UnityEngine;
using System.Collections;

public class HowtoPlay : MonoBehaviour {

  private bool _sceneStarting = true;
  private GUITexture _fader;
  
  void Awake()
  {
    Screen.orientation = ScreenOrientation.Portrait;
    _fader = GameObject.FindGameObjectWithTag("Fader").guiTexture;
    _fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
  }
  
  void Update()
  {
    if (_sceneStarting)
      StartScene();
    else
      EndScene();
  }
  
  void StartScene()
  {
    _fader.color = Color.Lerp(_fader.color, Color.clear, TapConstants.fadeSpeed * Time.deltaTime);
    if (_fader.color.a <= 0.05f)
    {
      // ... set the colour to clear and disable the GUITexture.
      _fader.color = Color.clear;
      _fader.enabled = false;
    }
  }
  
  public void EndScene()
  {
    // Save changed values to file
    TapConstants.Save();
    
    // Make sure the texture is enabled.
    _fader.enabled = true;
    
    // Start fading towards black.
    _fader.color = Color.Lerp(_fader.color, Color.black, TapConstants.fadeSpeed * Time.deltaTime);
    
    // If the screen is almost black...
    if (_fader.color.a >= 0.7f)
      // ... reload the level.
      Application.LoadLevel("MainMenu");
  }
  
  public void LoadScene()
  {
    if (!_sceneStarting) return;
    _sceneStarting = false;
  }
}
