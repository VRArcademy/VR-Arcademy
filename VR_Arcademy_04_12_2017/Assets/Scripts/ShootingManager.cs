namespace VRTK{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class ShootingManager : MonoBehaviour {

		public static ShootingManager instance;

		//Button
		//public GameObject InteractBtn;
		//public string btnString;
		//public Text btnText;
		//public float fadeInTime;
		//public float dist;
		//public Transform Player;

		//UI Control
		public GameObject ScorePlate;
		public GameObject TimerPlate;
		public GameObject HighScorePlate;

		TextMesh scoreText;
		TextMesh TimerText;
		TextMesh HighestScoreText;

		public int score = 0;
		public int highestScore = 0;
		public float currentTime = 60.0f;


		void Start () {
			//UI Setting
			scoreText = ScorePlate.GetComponentInChildren<TextMesh>();
			TimerText = TimerPlate.GetComponentInChildren<TextMesh> ();
			HighestScoreText = HighScorePlate.GetComponentInChildren<TextMesh> ();

			//Press Button
			//btnText = InteractBtn.GetComponentInChildren<Text> ();
			//btnText.color = Color.clear;
			
		}

		void Update () {
			//BtnUI_Interaction ();

			//Text
			scoreText.text = "Score: " + score.ToString ();
			TimerText.text = "Time: " + ((int)currentTime).ToString ();
			HighestScoreText.text = "HigherScore: " + highestScore.ToString ();

			//Method
			GameOnStarted();
			GameIsOver ();
			
		}

		void GameOnStarted(){
			if (GameManager.singleton.shootingCurState == GameManager.ShootingGameState.GameStart) {
				currentTime -= Time.deltaTime;
			}
			if (currentTime <= 0) {
				GameManager.singleton.shootingCurState = GameManager.ShootingGameState.Gameover;
			}
		}

		void GameIsOver(){
			if (GameManager.singleton.shootingCurState == GameManager.ShootingGameState.Gameover){
				GameManager.singleton.shootingCurState = GameManager.ShootingGameState.WaitForStart;
				currentTime = 60.0f;
				if (score >= highestScore) {
					highestScore = score;
				}
				score = 0;
			}
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
