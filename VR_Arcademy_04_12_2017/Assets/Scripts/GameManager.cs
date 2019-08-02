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
		}
			
		void Update () {

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