using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Bubbles_Script : MonoBehaviour {

  public Font Guifont;

	private float _score;
	private Animator _animator;
  private AudioSource _audio;
	private Text _scoreNum;
  private const float Lifetime = .5f;
  private float _timecount = 0f;
  private Vector3 _point;
  private readonly GUIStyle _guiStyle = new GUIStyle();
  private Rect _pointLabel;
	void Start() {
		_animator = gameObject.GetComponent<Animator> ();
    _scoreNum = GameObject.Find("ScoreNum").GetComponent<Text>();
    GameObject.Find("Name").GetComponent<Text>().text = TapConstants.player_name;
    _audio = GetComponent<AudioSource>();
	}
	
	void Update () { 
		_timecount += Time.deltaTime;
		if(_timecount > Lifetime)
		{
			_animator.SetBool ("alive", false);
			_animator.SetBool ("over", true);
		}
    if (Input.GetKeyDown(KeyCode.Escape)) 
      Application.Quit();
	}

  void OnMouseDown () {
    if (!TapConstants.gameover && (!_animator.GetBool ("ended"))) {
      //Getting object position
      _point = Camera.main.WorldToScreenPoint(transform.position);
      _point.y = Screen.height - _point.y;
			//set the hitten bubble position to out of screen.
			_animator.SetBool ("alive", false);
			_animator.SetBool ("ended", true);

      TapConstants.user_score += _score;
      _scoreNum.text = TapConstants.user_score + "";
//      iTween.ValueTo(_scoreNum.gameObject, iTween.Hash("from", Int32.Parse(_scoreNum.text), "to", TapConstants.user_score, "onUpdate", "AnimateGUITextPixelOffset", "easeType", iTween.EaseType.easeInOutBounce));
//      Debug.Log(TapConstants.user_score);

      _audio.Play();
		}
	}

  void OnTouchDOwn()
  {
    if (!TapConstants.gameover && (_animator.GetBool("ended")))
    {
      //Getting object position
      _point = Camera.main.WorldToScreenPoint(transform.position);
      _point.y = Screen.height - _point.y;
      //set the hitten bubble position to out of screen.
      _animator.SetBool("alive", false);
      _animator.SetBool("ended", true);

      TapConstants.user_score += _score;
      _scoreNum.text = TapConstants.user_score + "";
//      iTween.ValueTo(_scoreNum.gameObject, iTween.Hash("from", Int32.Parse(_scoreNum.text), "to", TapConstants.user_score, "onUpdate", "AnimateGUITextPixelOffset", "easeType", iTween.EaseType.easeInOutBounce));

      _audio.Play();
      Handheld.Vibrate();
    }
  }

  void OnGUI() {
    _guiStyle.fontSize = 40;
    _guiStyle.normal.textColor = Color.white;
    _guiStyle.fontStyle = FontStyle.Bold;
    _guiStyle.font = Guifont;
    if (_animator.GetBool ("ended")) {
      GUI.Label(new Rect(_point.x - 30, _point.y - 25, 0, 0), "+"+_score, _guiStyle);
    }
  }

  public void SetScore(float score) {
    this._score = score;
  }

  void AnimateGUITextPixelOffset(Vector2 pixelOffset)
  {
    _scoreNum.gameObject.guiText.pixelOffset = pixelOffset;
  }
}