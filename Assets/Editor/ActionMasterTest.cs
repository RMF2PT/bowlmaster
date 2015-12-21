using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {
	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	
	[SetUp]
	public void Setup () {
		pinFalls = new List<int>();
	}
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual(1, 1);
	}
	
	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		pinFalls.Add (10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
	}
	
	[Test]
	public void T02Bowl8ReturnsTidy () {
		pinFalls.Add (8);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}
	
	[Test]
	public void T03Bowl8ThenBowl2SpareReturnsEndTurn() {
		int[] rolls = {8,2};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T04StrikeInBowl19ReturnsReset() {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 10};
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T05Bowl1Then9SpareInBowls19And20ReturnsReset () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,9};
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T06Bowl1And1InBowls19And20ReturnsEndGame () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T07StrikeAtBowl19PlusStrikeAtBowl20ReturnsReset () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10,10};
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T08Bowl21ReturnsEndGame () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T09StrikeAtBowl19Plus0AtBowl20ReturnsTidy () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10,0};
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T10StrikeAtBowl19Plus5AtBowl20ReturnsTidy () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10,5};
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T11BowlCountAtEndOfSecondFrameWhitStrikeAtEndOfFirstFrame () {
		int[] rolls = {0,10 , 5,1};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T12Dondi10thFrameTurkey () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 1,1 , 10,10 , 10};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}
	
	[Test]
	public void T13Bowl6Then4ThenStrikeReturnsEndTurn () {
		int[] rolls = {6,4 , 10};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
}