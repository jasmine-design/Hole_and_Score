using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public GameObject cueBall;
    public GameObject[] redBalls;
    public GameObject[] gravityWalls;

    private void Start() {
        
    }

    private void MoveToNearestGravityWall(GameObject ball) {
        float minDistance = Mathf.Infinity;
        Vector3 closestWallPosition = Vector3.zero;

        foreach (GameObject wall in gravityWalls) {
            float distance = Vector3.Distance(ball.transform.position, wall.transform.position);
            if (distance < minDistance) {
                minDistance = distance;
                closestWallPosition = wall.transform.position;
            }
        }

        ball.GetComponent<Rigidbody>().MovePosition(closestWallPosition + Vector3.up * 0.01f);
    }

    public void StartGame() {
        // 將所有球移到最接近的重力牆上
        MoveToNearestGravityWall(cueBall);
        foreach (GameObject ball in redBalls) {
            MoveToNearestGravityWall(ball);
        }
    }
}