﻿using UnityEngine;
using System.Collections;

namespace GameStates {
	public class StrikingState : AbstractGameObjectState {
		private PoolGameController gameController;
		private CueBallController playerDetector;

		private Club currentplayerClub;
		private GameObject cueBall;
		private int currentplayerNumber;
		

		private float cueDirection = -1;
		private float speed = 7;

		public StrikingState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			cueBall = gameController.cueBall;
			playerDetector = GameObject.FindObjectOfType<CueBallController>();
			currentplayerNumber = gameController.CurrentPlayer.Number;
			currentplayerClub = gameController.CurrentPlayer.club;
		}

		public override void Update() {

			int playerIndex = playerDetector.lastPlayerIndex;
			if (playerIndex == currentplayerNumber){
				gameController.currentState = new GameStates.StrikeState(gameController);
			}
		}

		public override void FixedUpdate () {
			/*
			var distance = Vector3.Distance(club1.transform.position, cueBall.transform.position);
			if (distance < PoolGameController.MIN_DISTANCE || distance > PoolGameController.MAX_DISTANCE)
			cueDirection *= -1;
			club1.transform.Translate(Vector3.down * speed * cueDirection * Time.fixedDeltaTime);
			*/
		}
	}
}