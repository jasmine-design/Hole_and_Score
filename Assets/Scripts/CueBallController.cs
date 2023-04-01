using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallController : MonoBehaviour
{
    public int lastPlayerIndex = -1;

    // 檢查母球是否被擊打
    void OnCollisionEnter(Collision collision){
    // 檢查碰撞物體是否是球拍
        if(collision.gameObject.CompareTag("Club")){
        // 碰撞物體是球拍，獲取該球拍所屬的玩家編號
            int playerIndex = collision.gameObject.GetComponentInParent<Club>().playerIndex;
        // 更新最後一次擊打母球的玩家編號
            lastPlayerIndex = playerIndex;
        }

    }

}