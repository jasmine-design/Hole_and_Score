using UnityEngine;
using System.Collections;
using TMPro;


public class PoolGameController : MonoBehaviour {
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject scoreBar;
	public GameObject winnerMessage;
	
	public float maxForce;
	public float minForce;
	public Vector3 strikeDirection;

	public const float MIN_DISTANCE = 27.5f;
	public const float MAX_DISTANCE = 32f;

	public IGameObjectState currentState;

	public Player CurrentPlayer;
	public Player OtherPlayer;
	
	public Club club1;
	public Club club2;

	private MessageController Message;

	private bool currentPlayerContinuesToPlay = false;

	// This is kinda hacky but works
	static public PoolGameController GameInstance {
		get;
		private set;
	}

	void Start() {
		club1 = GameObject.Find("Club1").GetComponent<Club>();
    	club2 = GameObject.Find("Club2").GetComponent<Club>();

		CurrentPlayer =  new Player(1, club1);
		OtherPlayer = new Player(2, club2);
		
		GameInstance = this;
		Message = GameObject.FindObjectOfType<MessageController>();
		winnerMessage.GetComponent<Canvas>().enabled = false;

		currentState = new GameStates.WaitingForStrikeState(this);
	}

	void Update() {
		currentState.Update();
	}

	void FixedUpdate() {
		currentState.FixedUpdate();
	}

	void LateUpdate() {
		currentState.LateUpdate();
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
			Debug.Log(CurrentPlayer.Number + " continues to play");
			return;
		}

		Debug.Log(OtherPlayer.Number + " will play");
		var aux = CurrentPlayer;
		CurrentPlayer = OtherPlayer;
		OtherPlayer = aux;
		Message.ShowTurnMessage();
	}

	public void EndMatch() {
		Player winner = null;
		if (CurrentPlayer.Points > OtherPlayer.Points)
			winner = CurrentPlayer; 
		else if (CurrentPlayer.Points < OtherPlayer.Points)
			winner = OtherPlayer;

		var msg = "Game Over\n";

		if (winner != null)
			msg += string.Format("The winner is '{0}'", winner.Number);
		else
			msg += "It was a draw!";

		var text = winnerMessage.GetComponentInChildren<UnityEngine.UI.Text>();
		text.text = msg;
		winnerMessage.GetComponent<Canvas>().enabled = true;
	}
}
