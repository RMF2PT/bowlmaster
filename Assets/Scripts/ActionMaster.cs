using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	public static Action NextAction (List<int> rolls) {
		Action nextAction = Action.Undefined;

		List<int> clonedRollList = new List<int>(rolls);
		for (int i = 0; i < clonedRollList.Count; i++) { // Step through rolls
			
			if (i == 20) {
				Debug.Log ("do I ever get here?! i = 20");
				nextAction = Action.EndGame;
			} else if (i >= 18 && clonedRollList[i] == 10 ){ // Handle last-frame special cases
				nextAction = Action.Reset;
			} else if (i == 19) {
				if (clonedRollList[18] == 10 && clonedRollList[19] == 0) {
					nextAction = Action.Tidy;
				} else if (clonedRollList[18] + clonedRollList[19] == 10) {
					nextAction = Action.Reset;
				} else if (clonedRollList [18] + clonedRollList[19] >= 10) {  // Roll 21 awarded
					nextAction = Action.Tidy;
				} else {
					Debug.Log ("do I ever get here?!");
					nextAction = Action.EndGame;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (clonedRollList[i] == 10) {
					clonedRollList.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = Action.EndTurn;
				} else {
					nextAction = Action.Tidy;
				}
			} else { // Second bowl of frame
				nextAction = Action.EndTurn;
			}
		}
		
		return nextAction;
	}
}