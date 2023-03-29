using UnityEngine;
using System.Collections;

public class HoleController : MonoBehaviour {
	public GameObject redBalls;
	public GameObject cueBall;

	private Vector3 originalCueBallPosition;

	void Start() {
		originalCueBallPosition = cueBall.transform.position;
	}

	void OnTriggerEnter(Collider other) {
		foreach (var transform in redBalls.GetComponentsInChildren<Transform>()) {
			if (transform.name == other.gameObject.name) {
				var objectName = other.gameObject.name;
				GameObject.Destroy(other.gameObject);

				var ballNumber = int.Parse(objectName.Replace("Ball", ""));
				PoolGameController.GameInstance.BallPocketed(ballNumber);
			}
		}

		if (cueBall.transform.name == other.gameObject.name) {
			cueBall.transform.position = originalCueBallPosition;
		}
	}
}