namespace VRTK{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;
	using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
		//Singleton
		public static GameManager singleton;

		//UI Control
		public GameObject InteractBtn;
		public GameObject ScorePlate;
		public GameObject TimerPlate;
		public GameObject HighScorePlate;

		public string btnString;
		public Text btnText;
		public float fadeInTime;
		public float dist;
		public Transform Player;
		TextMesh scoreText;
		TextMesh TimerText;
		TextMesh HighestScoreText;

		public int score = 0;
		public int highestScore = 0;
		public float Timeleft = 60.0f;
		public float currentTime = 0;

		//GameState
		public ShootingGameState shootingCurState;


		public enum ShootingGameState{
			WaitForStart,
			GameStart,
			Gameover
		}

		void Awake(){
			if (singleton == null) {
				singleton = this;
			}else if(singleton != this){
				Destroy (this.gameObject);
			}

			DontDestroyOnLoad(this.gameObject);
			shootingCurState = ShootingGameState.WaitForStart;
		}


		void Start () {
			//UI Setting
			scoreText = ScorePlate.GetComponentInChildren<TextMesh>();
			TimerText = TimerPlate.GetComponentInChildren<TextMesh> ();
			HighestScoreText = HighScorePlate.GetComponentInChildren<TextMesh> ();
			btnText = InteractBtn.GetComponentInChildren<Text> ();
			btnText.color = Color.clear;
		}
			
		void Update () {
			//BtnUI_Interaction ();
			scoreText.text = "Score: " + score.ToString ();
			TimerText.text = "Time: " + ((int)currentTime).ToString ();
			HighestScoreText.text = "HigherScore: " + highestScore.ToString ();

			//Method
			GameOnStarted();
			GameIsOver ();


		}
			
		void GameOnStarted(){
			if (shootingCurState == ShootingGameState.GameStart) {
				currentTime -= Time.deltaTime;
				if (currentTime <= 0) {
					shootingCurState = ShootingGameState.Gameover;
				}
			}
		}

		void GameIsOver(){
			if (shootingCurState == ShootingGameState.Gameover){
				if (score >= highestScore) {
					highestScore = score;
				} else {
					highestScore = highestScore;
				}
				score = 0;
			}
		}

			

		//Scene Management
		public void LobbyToShootOnClicked(){
			SceneManager.LoadScene (1);
			
		}

		public void BackToLobbyOnClicked(){
			SceneManager.LoadScene (0);
			
		}

		/* void BtnUI_Interaction (){
			dist = Vector3.Distance (InteractBtn.transform.position, Player.position);
			if (dist <= 1.0f) {
				btnText.text = btnString;
				btnText.color = Color.Lerp (btnText.color, Color.red, fadeInTime * Time.deltaTime);
			} else {
				btnText.color = Color.Lerp (btnText.color, Color.clear, fadeInTime * Time.deltaTime);
			}
		}*/
	}
}