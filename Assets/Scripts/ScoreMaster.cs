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
		int rollNum = 0;
		int total = 0;
		int spareTotal = 0;
		int strikeTotal = 0;
		int strikeSequence = 2;
		bool isStrike = false;
		
		
		foreach (int roll in rolls) {
			rollNum++;

			if (rollNum > 21) {
				if (strikeTotal > 0) {
					strikeTotal += roll;
					frameList.Add (strikeTotal);
				} else {
					spareTotal += roll;
					frameList.Add (spareTotal);
				}
				continue;
			}

			if (roll == 10) {
				rollNum++;
				isStrike = true;
				if (strikeSequence > 0) {
					strikeSequence--;
					strikeTotal += roll;
					continue;
				}
			}
			
			if (isStrike) {
				strikeTotal += roll;
				if (strikeSequence == 0) {
					frameList.Add (strikeTotal);
					strikeTotal -= 10;
				}
			}
			
			if (spareTotal > 0 && !isStrike) {
				spareTotal += roll;
				frameList.Add (spareTotal);
				spareTotal = 0;
			}
			
			total += roll;
			
			if (rollNum % 2 == 0) {
				if (total % 10 == 0 && total > 0) {
					spareTotal += total;
					total = 0;
				} else {
					if (strikeTotal >= 10) {
						frameList.Add (strikeTotal);
						strikeTotal -= 10;
						isStrike = false;
					}
					frameList.Add (total);
					strikeTotal = 0;
					strikeSequence = 2;
					total = 0;
				}
			}
		} 
		return frameList;
	}
}
