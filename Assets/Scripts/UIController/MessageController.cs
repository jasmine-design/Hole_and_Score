using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class MessageController : MonoBehaviour {

    public TMP_Text Text;
	public float displayTime = 3f;
    private Coroutine coroutine;
    private string warningMessage = "Message: FOUL - you can't use the cueball to hit the ball.";
    private string turnMessage = "";

    public void ShowTurnMessage(){

        var currentPlayer = PoolGameController.GameInstance.CurrentPlayer;
        Text.text = String.Format("Now is Player{0}'s turn.", currentPlayer.Number);
        
    }

    public void ShowWarningMessage(){
       
        Text.text = warningMessage;
         
        Text.gameObject.SetActive(true);

        if (coroutine != null){
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CloseMessage());
    }
        
    IEnumerator CloseMessage(){
        yield return new WaitForSeconds(displayTime);
        Text.gameObject.SetActive(false);
    
    
    }

    public void ShowWhoseRound(){
        
    }
}
