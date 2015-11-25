using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {


	// Returns a list of cumulative scores, like a normal score card
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;
		
		foreach (int frameScore in ScoreFrames (rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}
		return cumulativeScores;
	}
	
	// TODO Ben's solution has 18 lines...
	
	// Returns a list of individual frame scores, NOT cumulative
	public static List<int> ScoreFrames (List<int> rolls) {
		
		List<int> frameList = new List<int>();
		int totalOfRolls = 0;
		totalOfRolls = rolls.Count;
		
		int rollNum = 0;
		int total = 0;
		
		if (totalOfRolls % 2 == 0) {
			foreach (int roll in rolls) {
				rollNum++;
				total += roll;
				if (rollNum % 2 == 0 && rollNum < totalOfRolls) {
					frameList.Add (total);
					total = 0;
				}
			}
			frameList.Add (total);
		} else {
			foreach (int roll in rolls.GetRange(0, (totalOfRolls-1))) {
				rollNum++;
				total += roll;
			}
			frameList.Add (total);
		}
		
		return frameList;
	}
	
}
