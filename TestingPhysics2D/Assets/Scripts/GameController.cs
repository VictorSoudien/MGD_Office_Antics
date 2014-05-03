using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private static int tempCoins;
	private static int totalCoins; // All coins collected thus far in the game

	private static GameObject[] coins;
	private static GameObject ball;
	private static Vector3 initBallPosition;
	
	private static AudioSource mainAudioSrc;
	private static AudioSource coinCollectSrc;
	private static AudioSource levelCompleteSrc;

	// Use this for initialization
	void Start () 
	{		
		mainAudioSrc = audio;
		coinCollectSrc = GameObject.Find("CoinCollectSound").audio;
		levelCompleteSrc = GameObject.Find("LevelCompleteSound").audio;
		
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
				
	}
	
	// Used instead of start so that the values are updated for each level
	public static void initForLevel()
	{	
		coins = GameObject.FindGameObjectsWithTag("Coin");
		ball = GameObject.FindGameObjectWithTag("Ball");
		initBallPosition = ball.transform.position;
	}
	
	// Allows gravity to act on the ball
	public static void runTrial()
	{
		ball.rigidbody2D.isKinematic = false;
	}
	
	// Resets the level in terms of ball posistion and  coins
	public static void resetLevel()
	{
		ball.transform.position = initBallPosition;
		ball.transform.rotation = Quaternion.identity;
		ball.rigidbody2D.angularVelocity = 0;
		ball.rigidbody2D.velocity = Vector2.zero;
		ball.rigidbody2D.isKinematic = true;
		
		// Add all coins back to the level and reset amount collected thus far
		foreach (GameObject c in coins)
		{
			c.SetActive(true);
		}
		
		tempCoins = 0;
	}
	
	// Coins collected during a single run of a level
	public static void addTempCoin()
	{
		tempCoins += 1;
		coinCollectSrc.Play();
	}
	
	// Once the ball reached the bucket the temp coins are added to the total coin count
	public static void addCoinsToTotal()
	{
		totalCoins += tempCoins;
		tempCoins = 0;
		
		levelCompleteSrc.Play();
	}
}
