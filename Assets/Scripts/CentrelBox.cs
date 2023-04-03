using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrelBox : MonoBehaviour
{
    public float redBallSpeed = 1f;

    private GameObject[] redBalls;
    private BallController ballController;

    private bool hasStarted = false;

    void Start()
    {
        // 初始化 redBalls 陣列
        redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        ballController = GameObject.Find("BallController").GetComponent<BallController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CueBall"))
        {
            StartRedBallMovement();
            Debug.Log("Start the game");
        }
    }

    private void StartRedBallMovement()
    {
        if(hasStarted)
        {
            return;
        }

        hasStarted = true;
        
        
        foreach (GameObject redBall in redBalls)
        {
            
            Debug.Log("enable redballcontroller");
            // 啟用 RedBallController
            RedBallController controller = redBall.GetComponent<RedBallController>();
            controller.enabled = true;

            // 設定子球速度
            Rigidbody rb = redBall.GetComponent<Rigidbody>();
            Vector3 moveDirection = Vector3.zero;
            float minDistance = Mathf.Infinity;
            // 子球初始移動方向朝著三面牆
            foreach (GameObject wall in ballController.gravityWalls) {
                float distance = Vector3.Distance(rb.transform.position, wall.transform.position);
                if (distance < minDistance) {
                    minDistance = distance;
                    moveDirection = (wall.transform.position - rb.transform.position).normalized;
                }
            }   
            rb.velocity = moveDirection * redBallSpeed;
        }
    }
}
