using UnityEngine;
using System.Collections;

public class Bubble_Generator : MonoBehaviour {
	
	public GameObject bubblePrefab;		//the bubble game object
	public int bubblePoolSize = 5;		//how many bubbles to keep on standby
	public float spawnRate = 0.3f;		//how quickly bubbles spawn
	
	GameObject[] bubbles;				//collection of pooled bubbles
	int currentBubble = 0;				//index of the current bubble in the collection

	// Use this for initialization
	void Start () {
		//initialize the bubbles collection
		bubbles = new GameObject[bubblePoolSize];
		//loop through the collection and create the individual bubbles
		for(int i = 0; i < bubblePoolSize; i++)
		{
			//note that bubbles will have the exact position and rotation of the prefab asset.
			//this is because we did not specify the position and rotation in the 
			//Instantiate() method call
			bubbles[i] = (GameObject)Instantiate(bubblePrefab);
			//set the hitten bubble position to out of screen.
			bubbles[i].transform.position = new Vector3(-400, -400);
		}
		//starts our function in charge of spawning the bubbles in the playable area
		StartCoroutine ("SpawnLoop");
	}
	

	//this is a coroutine which manages when bubbles are spawned
	IEnumerator SpawnLoop()
	{
		//initializing helper variables
		int first_appear_helper = 1;
		float spawnRate_helper = 0.2f;
	

		//infinite loop: use with caution
		while (true) 
		{
			//get animator
			Animator animator = bubbles[currentBubble].GetComponent<Animator>();

			//checking first or not and changing spawn_rate
			if(first_appear_helper >= bubblePoolSize){
				spawnRate_helper = spawnRate;
			} else {
				first_appear_helper++;
			}
			
			//setting random bubble color
			//bubbles[currentBubble].GetComponent<SpriteRenderer>().sprite = bubbleSprites[Random.Range (0, 4)];

			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;
			//Re-calculate position indicator
			bool overit = true;

			while(overit) {
				//...set a random x, y position...
				float randomX = Random.Range (0, Screen.width);
				float randomY = Random.Range (0, Screen.height);
				if(randomY < Screen.height/2) {
					randomY = randomY + 29;
				}
				if(randomX < Screen.width/2) {
					randomX = randomX + 29;
				} else {
					randomX = randomX - 29;
				}
				Vector2 spawnPosition = new Vector2 (randomX, randomY);
				pos = Camera.main.ScreenToWorldPoint(new Vector3(spawnPosition.x, spawnPosition.y, 10));
				if(pos.y > 3) {
					pos.y = pos.y - 2;
				}

				//getting closest bubble distance
				float closest = 1000;
				for(int i = 0; i < bubblePoolSize; i++) {
					if(bubbles[currentBubble] != bubbles[i]) {
						float dist = Vector3.Distance(pos, bubbles[i].transform.position);
						if(closest > dist) {
							closest = dist;
						}
					}
				}
				if(closest > 1.3f) {
					overit = false;
				}
			}

			//...then set the current bubble to that position.
			bubbles[currentBubble].transform.position = pos;

			//end next bubble
			int next = ((currentBubble + 1) >= bubblePoolSize) ? 0 : currentBubble + 1;
			bubbles[next].GetComponent<Animator>().SetBool("ended", true);

			//reset its alive status
			animator.SetBool("alive", true);
			animator.SetBool("ended", false);
			
			//increase the value of currentBubble. If the new size is too big, set it back to zero
			if(++currentBubble >= bubblePoolSize)
				currentBubble = 0;
			//leave this coroutine until the proper amount of time has passed
			yield return new WaitForSeconds(spawnRate_helper);
		}
	}
}
