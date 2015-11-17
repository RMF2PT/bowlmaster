using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {
	
	private ActionMaster actionMaster;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	
	[SetUp]
	public void Setup () {
		actionMaster = new ActionMaster();
	}
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual(1, 1);
	}
	
	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}
	
	[Test]
	public void T02Bowl8ReturnsTidy () {
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
	}
	
	[Test]
	public void T03Bowl8ThenBowl2SpareReturnsEndTurn() {
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
		Assert.AreEqual(endTurn, actionMaster.Bowl(2));
	}
	
	[Test]
	public void T04StrikeInBowl19ReturnsReset() {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
	}
	
	[Test]
	public void T05Bowl1Then9SpareInBowls19And20ReturnsReset () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(9));
	}
	
	[Test]
	public void T06Bowl1And1InBowls19And20ReturnsEndGame () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endGame, actionMaster.Bowl(1));
	}
	
	[Test]
	public void T07StrikeAtBowl19PlusStrikeAtBowl20ReturnsReset () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
	}
	
	[Test]
	public void T08Bowl21ReturnsEndGame () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endGame, actionMaster.Bowl(1));
	}
	
	[Test]
	public void T09StrikeAtBowl19Plus0AtBowl20ReturnsTidy () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(tidy, actionMaster.Bowl(0));
	}
	
	[Test]
	public void T10StrikeAtBowl19Plus5AtBowl20ReturnsTidy () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(tidy, actionMaster.Bowl(5));
	}
}