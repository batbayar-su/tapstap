using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Bubbles_Script : MonoBehaviour {

  public Font guifont;

	private float score;
	private Animator animator;
  private AudioSource audio;
	private UnityEngine.UI.Text score_num;
	private float lifetime = .5f;
	private float timecount = 0f;
  private Vector3 point;
  private GUIStyle guiStyle = new GUIStyle();

	void Start() {
		animator = gameObject.GetComponent<Animator> ();
		score_num = GameObject.Find("ScoreNum").GetComponent<UnityEngine.UI.Text>();
    audio = GetComponent<AudioSource>();
	}
	
	void Update () { 
		timecount += Time.deltaTime;
		if(timecount > lifetime)
		{
			animator.SetBool ("alive", false);
			animator.SetBool ("over", true);
		}
    if (Input.GetKeyDown(KeyCode.Escape)) 
      Application.Quit();
	}

	void OnMouseDown () {
    if (!TapConstants.gameover && (!animator.GetBool ("ended"))) {
      //Getting object position
      point = Camera.main.WorldToScreenPoint(this.transform.position);
      point.x = point.x;
      point.y = Screen.height - point.y;
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", true);

			string temp = ((System.Convert.ToInt32(score_num.text) + score) + "");
			score_num.text = temp;

      audio.Play();
		}
	}

	void OnTouchDown () {
    if (!TapConstants.gameover && (animator.GetBool ("ended"))) {
      //Getting object position
      point = Camera.main.WorldToScreenPoint(this.transform.position);
      point.x = point.x;
      point.y = Screen.height - point.y;
			//set the hitten bubble position to out of screen.
			animator.SetBool ("alive", false);
			animator.SetBool ("ended", true);
      
      string temp = ((System.Convert.ToInt32(score_num.text) + score) + "");
      score_num.text = temp;

			audio.Play();
			Handheld.Vibrate();
		}
	}

  void OnGUI() {
    guiStyle.fontSize = 75;
    guiStyle.normal.textColor = Color.white;
    guiStyle.fontStyle = FontStyle.Bold;
    guiStyle.font = guifont;
    if (animator.GetBool ("ended")) {
      GUI.Label(new Rect(point.x - 40, point.y - 50, 0, 0), "+"+score, guiStyle);
    }
  }

  public void SetScore(float score) {
    this.score = score;
  }
}