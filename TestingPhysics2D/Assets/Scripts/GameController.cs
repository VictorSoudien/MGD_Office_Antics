using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private static int tempCoins;
	private static int totalCoins; // All coins collected thus far in the game

	private static GameObject[] coins;
	private static GameObject[] placedInventory;
	private static GameObject ball;
	private static GameObject bin;
	private static GameObject selectionCircle;
	
	private static Vector3 initBallPosition;
	private static Vector3 initBinPosition;
	
	private static AudioSource mainAudioSrc;
	private static AudioSource coinCollectSrc;
	private static AudioSource springBounceSrc;
	private static AudioSource levelCompleteSrc;
	
	// Used to track if another inventory item is selected
	private static bool itemSelected;
	
	public static bool ItemSelected
	{
		get{return itemSelected;}
		set{itemSelected = value;}
	}

	// Use this for initialization
	void Start () 
	{		
		mainAudioSrc = audio;
		coinCollectSrc = GameObject.Find("CoinCollectSound").audio;
		springBounceSrc = GameObject.Find("SpringSound").audio;
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
		bin = GameObject.FindGameObjectWithTag ("Bin");
		selectionCircle = GameObject.Find("SelectionCircle");

		initBallPosition = ball.transform.position;
		initBinPosition = bin.transform.position;
		
		bin.rigidbody2D.isKinematic = true;
		itemSelected = false;

		//Destroys game objects from previous level no longer in use
		GameObject[] toBeDestroyed = GameObject.FindGameObjectsWithTag ("Destroy");
		foreach (GameObject gameObj in toBeDestroyed) 
		{
			Destroy (gameObj);
		}
	}
	
	// Allows gravity to act on the ball
	public static void runTrial()
	{
		bin.rigidbody2D.isKinematic = false;
		ball.rigidbody2D.isKinematic = false;
		selectionCircle.SetActive(false);

		placedInventory = GameObject.FindGameObjectsWithTag ("PlacedInventory");

		foreach (GameObject gameObj in placedInventory)
		{
			gameObj.GetComponent<MoveByDragging>().isMovable = false;
		}
	}
	
	// Resets the level in terms of ball posistion and  coins
	public static void resetLevel()
	{
		SpringController.releaseControlOfBall();
		bin.rigidbody2D.isKinematic = true;
		selectionCircle.SetActive(true);
		
		ball.transform.position = initBallPosition;
		ball.transform.rotation = Quaternion.identity;
		ball.rigidbody2D.angularVelocity = 0;
		ball.rigidbody2D.velocity = Vector2.zero;
		ball.rigidbody2D.isKinematic = true;

		bin.transform.position = initBinPosition;
		bin.transform.rotation = Quaternion.identity;
		bin.rigidbody2D.angularVelocity = 0;
		bin.rigidbody2D.velocity = Vector2.zero;
		
		// Add all coins back to the level and reset amount collected thus far
		foreach (GameObject c in coins)
		{
			c.SetActive(true);
		}

		foreach (GameObject gameObj in placedInventory)
		{
			gameObj.GetComponent<MoveByDragging>().isMovable = true;
		}
		
		tempCoins = 0;
		FollowBall.resetCamera = true;
	}

	// Perform anctions that need to occur on level complete
	public static void levelComplete(int indexOfNextLevel)
	{
		// Display end of level screen

		Application.LoadLevel (indexOfNextLevel);
		ball.tag = "Destroy";
	}
	
	// Play a sound when the ball is shot off a spring
	public static void playSpringSound()
	{
		springBounceSrc.Play();
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
