using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
	// config params
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlockDestroyed = 83;
	[SerializeField] TextMeshProUGUI scoreText;

	// state variables
	[SerializeField] int currentScore = 0;

	private void Awake()
	{
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
		if (gameStatusCount > 1)
		{
			// Destroy happends at end of lifecycle so need to make gameobject
			// inactive before then so it can't be used before it's destroyed
			gameObject.SetActive(false);
			ResetGame();
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	public void ResetGame()
	{
		Destroy(gameObject);
	}

	private void Start()
	{
		DisplayScore();
	}

	// Update is called once per frame
	void Update()
	{
		Time.timeScale = gameSpeed;
	}

	public void AddToScore()
	{
		currentScore += pointsPerBlockDestroyed;
		DisplayScore();
	}

	private void DisplayScore()
	{
		scoreText.text = $"Score: {currentScore}";
	}
	
}
