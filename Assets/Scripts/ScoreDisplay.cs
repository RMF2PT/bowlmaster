using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRolls (List<int> rolls) {
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

		for (int i = 0; i < rolls.Count; i++) {
			int rollBox = output.Length + 1; 								// rollBox starts at 1

			if (rolls[i] == 0) {											// 0 is shown as "-"
				output += "-";
			} else if ((rollBox % 2 == 0 || rollBox == 21) && rolls[i-1] + rolls[i] == 10) {	// SPARE
				output += "/";
			} else if (rolls[i] == 10 && rollBox < 18) {					// STRIKE before last frame
				output += "X ";
			} else if (rolls[i] == 10) {									// STRIKE in last frame
				output += "X";
			}  else {
				output += rolls[i].ToString();
			}
		}

		return output;
	}
}
