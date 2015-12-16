using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRollCard (List<int> rolls) {
		string scoresString = FormatRolls(rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts[i].text = scoresString[i].ToString();
		}
	}

	public void FillFrames (List<int> frames) {
		for (int i = 0; i < frames.Count; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls (List<int> rolls) {		// This is our testable static helper method
		string output = "";

		// my code here

		return output;
	}


	// TODO erase this method
	void InitializeScoresTexts () {
		for (int i = 0; i < 21; i++) {
			rollTexts[i].text = "10";
		}
		
		for (int i = 0; i < 10; i++) {
			frameTexts[i].text = "300";
		}
	}
}
