using UnityEngine;
using System.Collections;
using TMPro;


public class PoolGameController : MonoBehaviour {
	public GameObject club1;
	public GameObject club2;
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject scoreBar;
	public GameObject winnerMessage;
	
	public IGameObjectState currentState;

	public Player CurrentPlayer;
	public Player OtherPlayer;

	private MessageController Message;

	private bool currentPlayerContinuesToPlay = false;

	// This is kinda hacky but works
	static public PoolGameController GameInstance {
		get;
		private set;
	}

	void Start() {
		CurrentPlayer = new Player("John");
		OtherPlayer = new Player("Doe");
		GameInstance = this;
		Message = GameObject.FindObjectOfType<MessageController>();
		winnerMessage.GetComponent<Canvas>().enabled = false;
	}

	public void BallPocketed(int ballNumber) {
		currentPlayerContinuesToPlay = true;
		CurrentPlayer.Collect(ballNumber);
	}

	public void Foul(){
		Message.ShowWarningMessage();
	}

	public void NextPlayer() {
		if (currentPlayerContinuesToPlay) {
			currentPlayerContinuesToPlay = false;
			Debug.Log(CurrentPlayer.Name + " continues to play");
			return;
		}

		Debug.Log(OtherPlayer.Name + " will play");
		var aux = CurrentPlayer;
		CurrentPlayer = OtherPlayer;
		OtherPlayer = aux;
	}

	public void EndMatch() {
		Player winner = null;
		if (CurrentPlayer.Points > OtherPlayer.Points)
			winner = CurrentPlayer; 
		else if (CurrentPlayer.Points < OtherPlayer.Points)
			winner = OtherPlayer;

		var msg = "Game Over\n";

		if (winner != null)
			msg += string.Format("The winner is '{0}'", winner.Name);
		else
			msg += "It was a draw!";

		var text = winnerMessage.GetComponentInChildren<UnityEngine.UI.Text>();
		text.text = msg;
		winnerMessage.GetComponent<Canvas>().enabled = true;
	}
}
