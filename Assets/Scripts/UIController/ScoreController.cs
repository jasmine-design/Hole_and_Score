using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var text = GetComponent<TMP_Text>();
		var currentPlayer = PoolGameController.GameInstance.CurrentPlayer;
		var otherPlayer = PoolGameController.GameInstance.OtherPlayer;
		text.text = String.Format("Player{0} - {1}\nPlayer{2} - {3}", currentPlayer.Number, currentPlayer.Points, otherPlayer.Number, otherPlayer.Points);
	}
}
