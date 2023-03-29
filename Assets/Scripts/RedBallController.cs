using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController : MonoBehaviour
{
    // Start is called before the first frame update
    private string lastTouchBallObject = "None";

    void OnCollisionEnter(Collision collision){
        // 檢查碰撞物體是否是球桿，是的話提醒犯規
        if(collision.gameObject.CompareTag("Club")){
            lastTouchBallObject = "Club";
            PoolGameController.GameInstance.Foul();
        }
    }

}
