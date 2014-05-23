﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour 
{
	private GameController gc;
	private static int tempCoins;
	private static int totalCoins; // All coins collected thus far in the game

	private static GameObject[] coins;
	private static GameObject[] placedInventory;
	private static GameObject ball;
	private static GameObject bin;
	private static GameObject selectionCircle;

	private static GameObject winScreen;
	private static GameObject nextButton;
	
	private static Vector3 initBallPosition;
	private static Vector3 initBinPosition;
	
	private static AudioSource mainAudioSrc;
	private static AudioSource coinCollectSrc;
	private static AudioSource springBounceSrc;
	private static AudioSource fanSrc;
	private static AudioSource pipeEnterSrc;
	private static AudioSource eraserBounceSrc;
	private static AudioSource freezeSrc;
	private static AudioSource incineratorSrc;
	private static AudioSource levelCompleteSrc;

	private static int indexOfNextLevel;
	
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
		mainAudioSrc = GameObject.Find("backgroundSound").audio;
		coinCollectSrc = GameObject.Find("CoinCollectSound").audio;
		springBounceSrc = GameObject.Find("SpringSound").audio;
		fanSrc = GameObject.Find ("FanSound").audio;
		pipeEnterSrc = GameObject.Find ("PipeEnterSound").audio;
		eraserBounceSrc = GameObject.Find ("EraserBounceSound").audio;
		freezeSrc = GameObject.Find ("FreezingSound").audio;
		incineratorSrc = GameObject.Find ("IncineratorSound").audio;
		levelCompleteSrc = GameObject.Find("LevelCompleteSound").audio;

		winScreen = GameObject.Find ("WinScreen");
		nextButton = GameObject.Find ("NextButton");
		indexOfNextLevel = 0;
		
		mainAudioSrc.Play ();
		
		//loadData();
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	// Will save the game when the user closes the it
	/*void OnApplicationPause()
	{
		BinaryFormatter binForm = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/gameSave.dat", FileMode.OpenOrCreate);
		GameData saveData =  new GameData();
		saveData.currentLevelIndex = 3;
		
		binForm.Serialize(file, saveData);
		file.Close();
	}*/
	
	/*public void loadData()
	{
		if (File.Exists(Application.persistentDataPath + "/gameSave.dat"))
		{
			BinaryFormatter binForm = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameSave.dat", FileMode.Open);
			GameData loadedData = (GameData) binForm.Deserialize(file);
			file.Close();
			Application.LoadLevel(loadedData.currentLevelIndex);
		}
	}*/
	
	// Used instead of start so that the values are updated for each level
	public static void initForLevel()
	{	
		Debug.Log(Application.loadedLevel);
		mainAudioSrc.Stop();
		
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
		ball.rigidbody2D.gravityScale = 1;
		ball.collider2D.sharedMaterial = null;

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
	public static void levelComplete()
	{
		Application.LoadLevel (indexOfNextLevel);
		ball.tag = "Destroy";

		winScreen.renderer.enabled = false;
		nextButton.renderer.enabled = false;
		nextButton.collider2D.enabled = false;
	}
	
	// Play a sound when the ball is shot off a spring
	public static void playSpringSound()
	{
		springBounceSrc.Play();
	}

	// Play a sound when the ball passes in front of a sprite
	public static void playFanSound()
	{
		fanSrc.Play ();
	}
	
	// Play a sound when the ball enters a pipe
	public static void playPipeEnter()
	{
		pipeEnterSrc.Play ();
	}

	// Play a sound when the ball bounces off an eraser
	public static void playEraserBounce()
	{
		eraserBounceSrc.Play ();
	}
	
	// Play the freeze sound when the ball enters a frost pipe
	public static void playFreeze()
	{
		freezeSrc.Play();
	}
	
	// Play explosion when the ball enters the incinerator
	public static void playExplosion()
	{
		incineratorSrc.Play();
	}
	
	// Coins collected during a single run of a level
	public static void addTempCoin()
	{
		tempCoins += 1;
		coinCollectSrc.Play();
	}
	
	// Once the ball reached the bucket the temp coins are added to the total coin count
	public static void addCoinsToTotal(int nextLevel, int call)
	{
		totalCoins += tempCoins;
		tempCoins = 0;

		indexOfNextLevel = nextLevel;
		displayWinScreen ();

		if (call == 0) 
		{
			levelCompleteSrc.Play ();
		}
	}

	// Display the win screen
	public static void displayWinScreen()
	{
		winScreen.renderer.enabled = true;
		nextButton.renderer.enabled = true;
		nextButton.collider2D.enabled = true;
	}
}

[Serializable]
class GameData
{
	public int currentLevelIndex;
}
