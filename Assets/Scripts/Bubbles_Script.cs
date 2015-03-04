using UnityEngine;
using System.Collections;

public class Bubbles_Script : MonoBehaviour {
	public GameObject columnPrefab;		//the column game object
	public int columnPoolSize = 5;		//how many bubbles to keep on standby
	public float spawnRate = 3f;		//how quickly bubbles spawn
	public float columnMin = -1f;		//minimum y value of the column position
	public float columnMax = 3.5f;		//maximum y value of the column position
	
	GameObject[] bubbles;				//collection of pooled bubbles
	int currentBubble = 0;				//index of the current column in the collection

	// Use this for initialization
	void Start () {
		//initialize the bubbles collection
		bubbles = new GameObject[columnPoolSize];
		//loop through the collection and create the individual bubbles
		for(int i = 0; i < columnPoolSize; i++)
		{
			//note that bubbles will have the exact position and rotation of the prefab asset.
			//this is because we did not specify the position and rotation in the 
			//Instantiate() method call
			bubbles[i] = (GameObject)Instantiate(columnPrefab);
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
			//To spawn a column, get the current spawner position...
			Vector3 pos = transform.position;
			//...set a random y position...
			pos.y = Random.Range(columnMin, columnMax);
			//...then set the current column to that position.
			bubbles[currentBubble].transform.position = pos;
			
			//increase the value of currentBubble. If the new size is too big, set it back to zero
			if(++currentBubble >= columnPoolSize)
				currentBubble = 0;
			//leave this coroutine until the proper amount of time has passed
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
