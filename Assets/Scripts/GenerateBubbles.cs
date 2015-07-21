using UnityEngine;
using System.Collections;

public class GenerateBubbles : MonoBehaviour
{
  
  public GameObject blueBubblePrefab;
  public GameObject cyanBubblePrefab;
  public GameObject greenBubblePrefab;
  public GameObject yellowBubblePrefab;
  public GameObject orangeBubblePrefab;
  public GameObject pinkBubblePrefab;
  public GameObject purpleBubblePrefab;
  
  public float blueSpawnRate = .5f;
  public float cyanSpawnRate = 1f;
  public float greenSpawnRate = 1.5f;
  public float yellowSpawnRate = 2f;
  public float orangeSpawnRate = 2.5f;
  public float pinkSpawnRate = 3f;
  public float purpleSpawnRate = 3.5f;
  
  private System.Collections.Generic.List<GameObject> bubbles = new System.Collections.Generic.List<GameObject>();
  private const float _too_close = 1.5f;
  private readonly float start_delay = TapConstants.start_delay;
  
  // Use this for initialization
  void Awake()
  {
    TapConstants.gameover = false;
    TapConstants.user_score = 0;
    Screen.orientation = ScreenOrientation.LandscapeLeft;
    //starts our function in charge of spawning the bubbles in the playable area
    StartCoroutine("BlueSpawnLoop");
    StartCoroutine("CyanSpawnLoop");
    StartCoroutine("GreenSpawnLoop");
    StartCoroutine("YellowSpawnLoop");
    StartCoroutine("OrangeSpawnLoop");
    StartCoroutine("PinkSpawnLoop");
    StartCoroutine("PurpleSpawnLoop");
  }
  
  void Update()
  {
    System.Collections.Generic.List<GameObject> must_destroy = new System.Collections.Generic.List<GameObject>();
    foreach (GameObject bubble in bubbles)
    {
      Animator animator = bubble.GetComponent<Animator>();
      //if((animator.GetBool("alive") == false) && (animator.GetBool("ended") || animator.GetBool("over")))
      if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hidden"))
      {
        must_destroy.Add(bubble);
      }
    }
    foreach (GameObject item in must_destroy)
    {
      bubbles.Remove(item);
      Destroy(item);
    }
  }
  
  IEnumerator BlueSpawnLoop()
  {
    yield return new WaitForSeconds(blueSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(blueBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(blueSpawnRate));
      
      yield return new WaitForSeconds(blueSpawnRate);
    }
  }
  
  IEnumerator CyanSpawnLoop()
  {
    yield return new WaitForSeconds(cyanSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(cyanBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(cyanSpawnRate));
      
      yield return new WaitForSeconds(cyanSpawnRate);
    }
  }
  
  IEnumerator GreenSpawnLoop()
  {
    yield return new WaitForSeconds(greenSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(greenBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(greenSpawnRate));
      
      yield return new WaitForSeconds(greenSpawnRate);
    }
  }
  
  IEnumerator YellowSpawnLoop()
  {
    yield return new WaitForSeconds(yellowSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(yellowBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(yellowSpawnRate));
      
      yield return new WaitForSeconds(yellowSpawnRate);
    }
  }
  
  IEnumerator OrangeSpawnLoop()
  {
    yield return new WaitForSeconds(orangeSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(orangeBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(orangeSpawnRate));
      
      yield return new WaitForSeconds(orangeSpawnRate);
    }
  }
  
  IEnumerator PinkSpawnLoop()
  {
    yield return new WaitForSeconds(pinkSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(pinkBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(pinkSpawnRate));
      
      yield return new WaitForSeconds(pinkSpawnRate);
    }
  }
  
  IEnumerator PurpleSpawnLoop()
  {
    yield return new WaitForSeconds(purpleSpawnRate + start_delay);
    while (!TapConstants.gameover)
    {
      //Creating object
      GameObject new_bubble = (GameObject)Instantiate(purpleBubblePrefab);
      bubbles.Add(new_bubble);
      //set new position
      SetNewBubblePosition(new_bubble);
      //set bubble point
      new_bubble.GetComponent<Bubbles_Script>().SetScore(GetCalculatedScore(purpleSpawnRate));
      
      yield return new WaitForSeconds(purpleSpawnRate);
    }
  }
  
  private void SetNewBubblePosition(GameObject new_bubble) {
    //To spawn a bubble, get the current spawner position...
    Vector3 pos = transform.position;
    //Re-calculate position indicator
    bool overit = true;
    
    while (overit)
    {
      //...set a random x, y position...
      float randomX = Random.Range(0, Screen.width);
      float randomY = Random.Range(0, Screen.height);
      if (randomY < Screen.height / 2)
      {
        randomY = randomY + 29;
      }
      if (randomX < Screen.width / 2)
      {
        randomX = randomX + 29;
      }
      else
      {
        randomX = randomX - 29;
      }
      Vector2 spawnPosition = new Vector2(randomX, randomY);
      pos = Camera.main.ScreenToWorldPoint(new Vector3(spawnPosition.x, spawnPosition.y, 10));
      if (pos.y > 3)
      {
        pos.y = pos.y - 2;
      }
      
      //getting closest bubble distance
      float closest = 1000;
      for (int i = 0; i < bubbles.Count; i++)
      {
        if (new_bubble != bubbles[i])
        {
          float dist = Vector3.Distance(pos, bubbles[i].transform.position);
          if (closest > dist)
          {
            closest = dist;
          }
        }
      }
      if (closest > _too_close)
      {
        overit = false;
      }
    }
    new_bubble.transform.position = pos;
  }
  
  private float GetCalculatedScore(float spawn_rate) {
    return Mathf.Round(spawn_rate * 4);
  }

  public void RestartGame () {
    Debug.Log("Entered the restart button");
    Application.LoadLevel("Practice");
  }
}