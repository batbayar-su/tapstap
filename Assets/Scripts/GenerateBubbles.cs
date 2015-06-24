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
  private float _too_close = 1.5f;

  // Use this for initialization
  void Awake()
  {
    //starts our function in charge of spawning the bubbles in the playable area
    StartCoroutine("BlueSpawnLoop");
    StartCoroutine("CyanSpawnLoop");
    StartCoroutine("GreenSpawnLoop");
    StartCoroutine("YellowSpawnLoop");
    StartCoroutine("OrangeSpawnLoop");
    StartCoroutine("PinkSpawnLoop");
    StartCoroutine("PurpleSpawnLoop");
  }

  void FixedUpdate()
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
    yield return new WaitForSeconds(blueSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(blueBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = blueSpawnRate * 5;

      yield return new WaitForSeconds(blueSpawnRate);
    }
  }

  IEnumerator CyanSpawnLoop()
  {
    yield return new WaitForSeconds(cyanSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(cyanBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = cyanSpawnRate * 5;

      yield return new WaitForSeconds(cyanSpawnRate);
    }
  }

  IEnumerator GreenSpawnLoop()
  {
    yield return new WaitForSeconds(greenSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(greenBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = greenSpawnRate * 5;

      yield return new WaitForSeconds(greenSpawnRate);
    }
  }

  IEnumerator YellowSpawnLoop()
  {
    yield return new WaitForSeconds(yellowSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(yellowBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = yellowSpawnRate * 5;

      yield return new WaitForSeconds(yellowSpawnRate);
    }
  }

  IEnumerator OrangeSpawnLoop()
  {
    yield return new WaitForSeconds(orangeSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(orangeBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = orangeSpawnRate * 5;

      yield return new WaitForSeconds(orangeSpawnRate);
    }
  }

  IEnumerator PinkSpawnLoop()
  {
    yield return new WaitForSeconds(pinkSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(pinkBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = pinkSpawnRate * 5;

      yield return new WaitForSeconds(pinkSpawnRate);
    }
  }

  IEnumerator PurpleSpawnLoop()
  {
    yield return new WaitForSeconds(purpleSpawnRate);
    while (true)
    {
      GameObject new_bubble = (GameObject)Instantiate(purpleBubblePrefab);
      bubbles.Add(new_bubble);

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

      // setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<Bubbles_Script>().score = purpleSpawnRate * 5;

      yield return new WaitForSeconds(purpleSpawnRate);
    }
  }
}