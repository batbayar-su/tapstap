using UnityEngine;
using System.Collections;

public class Bubble_Generator : MonoBehaviour {
	
	public GameObject bubblePrefab;		//the bubble game object
	public int bubblePoolSize = 5;		//how many bubbles to keep on standby
	public float spawnRate = 0.3f;		//how quickly bubbles spawn
	
	GameObject[] bubbles;				//collection of pooled bubbles
	int currentBubble = 0;				//index of the current bubble in the collection

	private Ray ray; // The ray
	private RaycastHit hit; // What we hit
	
	// Use this for initialization
	void Start () {
		//initialize the bubbles collection
		bubbles = new GameObject[bubblePoolSize];
		//loop through the collection and create the individual bubbles
		for(int i = 0; i < bubblePoolSize; i++)
		{
			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;
			//...set a random y position...
			pos.y = Random.Range(-4f, 4f);
			pos.x = Random.Range(-7f, 7f);
			//note that bubbles will have the exact position and rotation of the prefab asset.
			//this is because we did not specify the position and rotation in the 
			//Instantiate() method call
			bubbles[i] = (GameObject)Instantiate(bubblePrefab);
			//...then set the current bubble to that position.
			bubbles[i].transform.position = pos;
		}
		//starts our function in charge of spawning the bubbles in the playable area
		StartCoroutine ("SpawnLoop");
	}
	
	//this is a coroutine which manages when bubbles are spawned
	IEnumerator SpawnLoop()
	{
		//infinite loop: use with caution
		while (true) 
		{
			//To spawn a bubble, get the current spawner position...
			Vector3 pos = transform.position;
			//...set a random y position...
			pos.y = Random.Range(-4f, 4f);
			pos.x = Random.Range(-7f, 7f);
			//...then set the current bubble to that position.
			bubbles[currentBubble].transform.position = pos;
			
			//increase the value of currentBubble. If the new size is too big, set it back to zero
			if(++currentBubble >= bubblePoolSize)
				currentBubble = 0;
			//leave this coroutine until the proper amount of time has passed
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
