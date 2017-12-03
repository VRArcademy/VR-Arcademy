namespace VRTK{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;

public class GameManager : MonoBehaviour {
		//Singleton
		public static GameManager singleton;

		//UI Control
		public GameObject InteractBtn;
		public string btnString;
		public Text btnText;
		public float fadeInTime;
		public float dist;
		public Transform Player;

		public int score = 0;
		public Text scoretxt;



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
			btnText = InteractBtn.GetComponentInChildren<Text> ();
			btnText.color = Color.clear;

		}
			
		void Update () {
			BtnUI_Interaction ();
			scoretxt.text = score.ToString ();
		}

		void BtnUI_Interaction (){
			
			dist = Vector3.Distance (InteractBtn.transform.position, Player.position);
			if (dist <= 1.0f) {
				btnText.text = btnString;
				btnText.color = Color.Lerp (btnText.color, Color.red, fadeInTime * Time.deltaTime);
			} else {
				btnText.color = Color.Lerp (btnText.color, Color.clear, fadeInTime * Time.deltaTime);
			}



			
		}

	}
}