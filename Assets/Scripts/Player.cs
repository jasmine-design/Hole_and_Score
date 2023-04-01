using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Player {
	private IList<Int32> ballsCollected = new List<Int32>();

	public Player(int number) {
		Number = number;
	}

	public int Number {
		get;
		private set;
	}

	public int Points {
		get { return ballsCollected.Count; }
	}

	public void Collect(int ballNumber) {
		Debug.Log("Player" + Number + " collected ball " + ballNumber);
		ballsCollected.Add(ballNumber);
	}
}
