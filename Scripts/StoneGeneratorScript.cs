using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StoneGeneratorScript : MonoBehaviour {

	public TextMesh TextPoints;
	public TextMesh TextReplay;
	public TextMesh TextGameOver;


	private int point;
	public GameObject stone;
	public GameObject Enemy;
	public float nextSpawn;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool gameover;
	private bool replay;


	void Start(){
		gameover = false;
		replay = false;


		TextReplay.text = "";
		TextGameOver.text = "";
	

		point=0;
		UpdateScore ();
		StartCoroutine (Spawn());
	}
	void Update ()
	{   

		if (replay) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
		IEnumerator Spawn()
		{
			yield return new WaitForSeconds (startWait);
			while (true)
			{
			
			for (int i = 0; i < nextSpawn; i++)
				{
					float randomYPosition = Random.Range (transform.position.y/2, -transform.position.y/2);
					Vector2 randomPosition = new Vector2 (transform.position.x, randomYPosition);
				    Instantiate (stone, randomPosition, Quaternion.identity);
				    Instantiate (Enemy, randomPosition, Quaternion.identity);
					yield return new WaitForSeconds (spawnWait);
				}
				yield return new WaitForSeconds (waveWait);

			if (gameover) {
				TextReplay.text = "Нажмите 'R' для начала нового космическиго сражения";
				replay = true;
				break;
			}
		}
	}
	public void AddScore (int newPointsValue)
	{
		point += newPointsValue;
		UpdateScore ();
	}
		void UpdateScore ()
	{
		TextPoints.text = "Очки: " + point; 
	}
	public void GameOver(){
		TextGameOver.text = "Па Паааам, битва оконченна! ";
		gameover = true;
	}
}

//	while (true) {
/*if (Time.time > nextSpawn) {
				float randomYPosition = Random.Range (transform.position.y, -transform.position.y);
				Vector2 randomPosition = new Vector2 (transform.position.x, randomYPosition);
				Instantiate (stone, randomPosition, Quaternion.identity);
				nextSpawn += Random.Range (minDelay, maxDelay);
			//}*/

//	public float minDelay;
//public float maxDelay;






