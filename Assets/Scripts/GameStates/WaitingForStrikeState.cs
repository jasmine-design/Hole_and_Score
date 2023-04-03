using UnityEngine;
using System.Collections;

namespace GameStates {
	public class WaitingForStrikeState  : AbstractGameObjectState {
		private Club currentplayerClub;
		private GameObject cueBall;
		private int currentplayerNumber;
		//private GameObject mainCamera;

		private PoolGameController gameController;
		private CueBallController playerDetector;



		public WaitingForStrikeState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			currentplayerClub = gameController.CurrentPlayer.club;
			cueBall = gameController.cueBall;
			currentplayerClub.GetComponent<Renderer>().enabled = true;
			playerDetector = GameObject.FindObjectOfType<CueBallController>();
			currentplayerNumber = gameController.CurrentPlayer.Number;
			
		}

		public override void Update() {
			/*
			var x = Input.GetAxis("Horizontal");
			
			if (x != 0) {
				var angle = x * 75 * Time.deltaTime;
				gameController.strikeDirection = Quaternion.AngleAxis(angle, Vector3.up) * gameController.strikeDirection;
				mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
				club1.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
			}
			Debug.DrawLine(cueBall.transform.position, cueBall.transform.position + gameController.strikeDirection * 10);
			
			*/
			int playerIndex = playerDetector.lastPlayerIndex;
			if (playerIndex == currentplayerNumber){
				Debug.Log("playerIndex=" + playerIndex);
				gameController.currentState = new GameStates.StrikingState(gameController);
			}
		}
	}
}