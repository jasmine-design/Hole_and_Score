using UnityEngine;
using System;

namespace GameStates {
	public class StrikeState : AbstractGameObjectState {
		private PoolGameController gameController;
		
		private Club currentplayerClub;
		private GameObject cueBall;

		private float speed = 30f;
		private float force = 0f;
		
		public StrikeState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			cueBall = gameController.cueBall;

			currentplayerClub = gameController.CurrentPlayer.club;

			var forceAmplitude = gameController.maxForce - gameController.minForce;
			var relativeDistance = (Vector3.Distance(currentplayerClub.transform.position, cueBall.transform.position) - PoolGameController.MIN_DISTANCE) / (PoolGameController.MAX_DISTANCE - PoolGameController.MIN_DISTANCE);
			force = forceAmplitude * relativeDistance + gameController.minForce;
		}

		public override void FixedUpdate () {
			var distance = Vector3.Distance(currentplayerClub.transform.position, cueBall.transform.position);
			if (distance < PoolGameController.MIN_DISTANCE) {
				//cueBall.GetComponent<Rigidbody>().AddForce(gameController.strikeDirection * force);
				//club1.GetComponent<Renderer>().enabled = false;
				//club1.transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
				gameController.currentState = new GameStates.WaitingForNextTurnState(gameController);
			} else {
				//club1.transform.Translate(Vector3.down * speed * -1 * Time.fixedDeltaTime);
			}
		}
	}
}