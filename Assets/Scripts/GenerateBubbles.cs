using ExitGames.Client.Photon;
using UnityEngine;
using System.Collections;

public class GenerateBubbles : MonoBehaviour {
	
	public GameObject blueBubblePrefab;
	public GameObject greenBubblePrefab;
	public GameObject pinkBubblePrefab;
	public GameObject purpleBubblePrefab;
	public GameObject orangeBubblePrefab;
	
	public float blueSpawnRate = .2f;
	public float greenSpawnRate = .5f;
	public float pinkSpawnRate = 1f;
	public float purpleSpawnRate = 2f;
	public float orangeSpawnRate = 5f;

	private System.Collections.Generic.List<GameObject> bubbles = new System.Collections.Generic.List<GameObject>();
	private float bubbleIdleTime = 1f;

  #region CONNECTION HANDLING

  public void Awake()
  {
    if (!PhotonNetwork.connected)
    {
      PhotonNetwork.autoJoinLobby = false;
      PhotonNetwork.ConnectUsingSettings("0.9");
    }
  }

  // This is one of the callback/event methods called by PUN (read more in PhotonNetworkingMessage enumeration)
  public void OnConnectedToMaster()
  {
    PhotonNetwork.JoinRandomRoom();
  }

  // This is one of the callback/event methods called by PUN (read more in PhotonNetworkingMessage enumeration)
  public void OnPhotonRandomJoinFailed()
  {
    PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 4 }, null);
  }

  // This is one of the callback/event methods called by PUN (read more in PhotonNetworkingMessage enumeration)
  public void OnJoinedRoom()
  {
  }

  // This is one of the callback/event methods called by PUN (read more in PhotonNetworkingMessage enumeration)
  public void OnCreatedRoom()
  {
    Application.LoadLevel(Application.loadedLevel);
  }

  #endregion

	// Use this for initialization
	void Start () {
		//starts our function in charge of spawning the bubbles in the playable area
		StartCoroutine ("BlueSpawnLoop");
		StartCoroutine ("GreenSpawnLoop");
		StartCoroutine ("PinkSpawnLoop");
		StartCoroutine ("PurpleSpawnLoop");
		StartCoroutine ("OrangeSpawnLoop");
	}

	void FixedUpdate () {
		System.Collections.Generic.List<GameObject> must_destroy = new System.Collections.Generic.List<GameObject>();
		foreach (GameObject bubble in bubbles) {
			Animator animator = bubble.GetComponent<Animator>();
//			if((animator.GetBool("alive") == false) || (animator.GetBool("ended") == true)) {
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hidden")) {
				must_destroy.Add(bubble);
			} 
//			else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("BubbleShow") &&
//			          !animator.GetCurrentAnimatorStateInfo(0).IsName("BubbleIdle")) {
//				animator.SetBool("ended", true);
//			}
		}
		foreach (GameObject bubble in must_destroy) {
			bubbles.Remove(bubble);
			Destroy(bubble);
		}
	}
	
	IEnumerator BlueSpawnLoop() {
		while (true) {
			GameObject new_bubble = (GameObject)Instantiate (blueBubblePrefab);
			bubbles.Add(new_bubble);

			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;

			//...set a random x, y position...
			float randomX = Random.Range (0, Screen.width);
			float randomY = Random.Range (0, Screen.height);
			if (randomY < Screen.height / 2) {
				randomY = randomY + 29;
			}
			if (randomX < Screen.width / 2) {
				randomX = randomX + 29;
			} else {
				randomX = randomX - 29;
			}
			Vector2 spawnPosition = new Vector2 (randomX, randomY);
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (spawnPosition.x, spawnPosition.y, 10));
			if (pos.y > 3) {
				pos.y = pos.y - 2;
			}

			// setting position
			new_bubble.transform.position = pos;
      new_bubble.GetComponent<PhotonView>().viewID = 1;
			new_bubble.GetComponent<Bubbles_Script>().score = blueSpawnRate / 10f;

			yield return new WaitForSeconds (blueSpawnRate);
		}
	}
	
	IEnumerator GreenSpawnLoop() {
		while (true) {
			GameObject new_bubble = (GameObject)Instantiate (greenBubblePrefab);
			bubbles.Add(new_bubble);

			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;

			//...set a random x, y position...
			float randomX = Random.Range (0, Screen.width);
			float randomY = Random.Range (0, Screen.height);
			if (randomY < Screen.height / 2) {
				randomY = randomY + 29;
			}
			if (randomX < Screen.width / 2) {
				randomX = randomX + 29;
			} else {
				randomX = randomX - 29;
			}
			Vector2 spawnPosition = new Vector2 (randomX, randomY);
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (spawnPosition.x, spawnPosition.y, 10));
			if (pos.y > 3) {
				pos.y = pos.y - 2;
			}

			// setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<PhotonView>().viewID = 1;
      new_bubble.GetComponent<Bubbles_Script>().score = greenSpawnRate / 10f;

			yield return new WaitForSeconds (greenSpawnRate);
		}
	}
	
	IEnumerator PinkSpawnLoop() {
		while (true) {
			GameObject new_bubble = (GameObject)Instantiate (pinkBubblePrefab);
			bubbles.Add(new_bubble);

			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;

			//...set a random x, y position...
			float randomX = Random.Range (0, Screen.width);
			float randomY = Random.Range (0, Screen.height);
			if (randomY < Screen.height / 2) {
				randomY = randomY + 29;
			}
			if (randomX < Screen.width / 2) {
				randomX = randomX + 29;
			} else {
				randomX = randomX - 29;
			}
			Vector2 spawnPosition = new Vector2 (randomX, randomY);
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (spawnPosition.x, spawnPosition.y, 10));
			if (pos.y > 3) {
				pos.y = pos.y - 2;
			}

			// setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<PhotonView>().viewID = 1;
      new_bubble.GetComponent<Bubbles_Script>().score = pinkSpawnRate / 10f;

			yield return new WaitForSeconds (pinkSpawnRate);
		}
	}
	
	IEnumerator PurpleSpawnLoop() {
		while (true) {
			GameObject new_bubble = (GameObject)Instantiate (purpleBubblePrefab);
			bubbles.Add(new_bubble);

			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;

			//...set a random x, y position...
			float randomX = Random.Range (0, Screen.width);
			float randomY = Random.Range (0, Screen.height);
			if (randomY < Screen.height / 2) {
				randomY = randomY + 29;
			}
			if (randomX < Screen.width / 2) {
				randomX = randomX + 29;
			} else {
				randomX = randomX - 29;
			}
			Vector2 spawnPosition = new Vector2 (randomX, randomY);
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (spawnPosition.x, spawnPosition.y, 10));
			if (pos.y > 3) {
				pos.y = pos.y - 2;
			}

			// setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<PhotonView>().viewID = 1;
      new_bubble.GetComponent<Bubbles_Script>().score = purpleSpawnRate / 10f;

			yield return new WaitForSeconds (purpleSpawnRate);
		}
	}
	
	IEnumerator OrangeSpawnLoop() {
		while (true) {
			GameObject new_bubble = (GameObject)Instantiate (orangeBubblePrefab);
			bubbles.Add(new_bubble);

			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;

			//...set a random x, y position...
			float randomX = Random.Range (0, Screen.width);
			float randomY = Random.Range (0, Screen.height);
			if (randomY < Screen.height / 2) {
				randomY = randomY + 29;
			}
			if (randomX < Screen.width / 2) {
				randomX = randomX + 29;
			} else {
				randomX = randomX - 29;
			}
			Vector2 spawnPosition = new Vector2 (randomX, randomY);
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (spawnPosition.x, spawnPosition.y, 10));
			if (pos.y > 3) {
				pos.y = pos.y - 2;
			}

			// setting position
      new_bubble.transform.position = pos;
      new_bubble.GetComponent<PhotonView>().viewID = 1;
      new_bubble.GetComponent<Bubbles_Script>().score = orangeSpawnRate / 10f;

			yield return new WaitForSeconds (orangeSpawnRate);
		}
	}
}
