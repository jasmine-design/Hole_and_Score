using UnityEngine;
using System.Collections;

namespace GameStates {
	public class WaitingForNextTurnState : AbstractGameObjectState {
		private PoolGameController gameController;
		private GameObject club1;
		private GameObject cueBall;
		private GameObject redBalls;
		private GameObject mainCamera;

		//private Vector3 cameraOffset;
		private Vector3 cueOffset;
		//private Quaternion cameraRotation;
		//private Quaternion cueRotation;

		public WaitingForNextTurnState(MonoBehaviour parent) : base(parent) {
			gameController = (PoolGameController)parent;

			club1 = gameController.club1;
			cueBall = gameController.cueBall;
			redBalls = gameController.redBalls;
			
			//cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			//cameraRotation = mainCamera.transform.rotation;
			//cueOffset = cueBall.transform.position - club1.transform.position;
			//cueRotation = club1.transform.rotation;
		}

		public override void FixedUpdate() {
			// 檢查子球還有幾顆沒被打進洞
			Debug.Log("Remained Ball:" + redBalls.GetComponentsInChildren<Transform>().Length);
			// 當場上子球剩下1顆時，結束比賽
			if (redBalls.GetComponentsInChildren<Transform>().Length == 1) {
				gameController.EndMatch();
			} 
			// 檢查場上還有沒有球在動，當球都停止移動時，結束這回合
			else {
				var cueBallBody = cueBall.GetComponent<Rigidbody>();
				if (!(cueBallBody.IsSleeping() || cueBallBody.velocity == Vector3.zero)){
					Debug.Log("cueball is sleeping");
					return;
				}
				foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>()) {
					if (!(rigidbody.IsSleeping() || rigidbody.velocity == Vector3.zero))
						return;
				}

				gameController.NextPlayer();
				Debug.Log("next player");
				// If all balls are sleeping, time for the next turn
				// This is kinda hacky but gets the job done
				gameController.currentState = new WaitingForStrikeState(gameController);
			}
		}

		public override void LateUpdate() {
			//mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			//mainCamera.transform.rotation = cameraRotation;
			
			//club1.transform.position = cueBall.transform.position - cueOffset;
			//club1.transform.rotation = cueRotation;
		}
	}
}