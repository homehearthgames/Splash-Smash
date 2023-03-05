using UnityEngine;
using System.Collections.Generic;

public class LeaderBoardSample : MonoBehaviour {
	
	int totalScore = 0;
	string playerName = "";

	dreamloLeaderBoard dl;
	List<dreamloLeaderBoard.Score> scoreList;

	bool gotScores = false;

	void Start () 
	{
		dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

		//dl.AddScore(this.playerName, totalScore);
		dl.GetScores();
	}
	
	void Update()
	{
		scoreList = dl.ToListHighToLow();

		if (scoreList.Count > 0 && gotScores==false)
        {
			gotScores = true;
			PopulateScores();
		}
	}
	
	void PopulateScores()
    {
		int maxToDisplay = 10;
		int count = 0;
		foreach (dreamloLeaderBoard.Score currentScore in scoreList)
		{
			count++;
			Debug.Log(currentScore.playerName + "   " + currentScore.score.ToString());
			if (count >= maxToDisplay) break;
		}
	}
}
