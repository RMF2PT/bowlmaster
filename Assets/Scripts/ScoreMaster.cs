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
		int totalOfRolls = rolls.Count;
		int rollNum = 0;
		int total = 0;
		int spareTotal = 0;

		foreach (int roll in rolls) {
			rollNum++;
			if (roll == 10) {
				rollNum++;
			}
			total += roll;
			if (spareTotal > 0) {
				spareTotal += total;
				frameList.Add (spareTotal);
				spareTotal = 0;
			}
			if (rollNum % 2 == 0 && rollNum < totalOfRolls) {
				if (total == 10) {
					spareTotal += total;
					total = 0;
				} else {
					frameList.Add (total);
					total = 0;
				}
			}
		}
		
		// End of frame
		if (totalOfRolls % 2 == 0 && total < 10) {
				frameList.Add (total);
		}
		
		return frameList;
	}
	
	// TODO TDD really works. At first I create very ugly and messy code, and when it all starts working green,
	// I sculpt it into a clean and beautiful code. I didn't knew about TDD until I heard it here in the course.
	// I'm a huge fan now.
}
