using UnityEngine;
using TMPro;
using System.Collections;

public class MessageController : MonoBehaviour {

    public TMP_Text warningText;
	public float displayTime = 3f;
    private Coroutine coroutine;
    private string warningMessage = "Message: FOUL - you can't use the cueball to hit the ball.";

    public void ShowWarningMessage(){
       
        warningText.text = warningMessage;
         
        warningText.gameObject.SetActive(true);

        if (coroutine != null){
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CloseMessage());
    }
        
    IEnumerator CloseMessage(){
        yield return new WaitForSeconds(displayTime);
        warningText.gameObject.SetActive(false);
    
    
    }
}
