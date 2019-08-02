namespace VRTK{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;

	public class ButtonEvent : VRTK_InteractableObject {

		Vector3 randPos;
		public GameObject spawnTarget;
		public List<GameObject> spawnedTarget;
		private float randX;
		private float randY;
		private float spawnRate = 1.5f;
		private float currentTime = 0;
		private float Timeleft = 60.0f;

		public override void StartUsing(VRTK_InteractUse usingObject){
			base.StartUsing (usingObject);
			StartGame ();
			if (GameManager.singleton.shootingCurState == GameManager.ShootingGameState.GameStart) {
				StartCoroutine (TargetTimer ());
			}
		}

		protected void Start(){
			
		}

		public void StartGame(){
			GameManager.singleton.shootingCurState = GameManager.ShootingGameState.GameStart;
			currentTime = Timeleft;
			currentTime -= Time.deltaTime;
		}

		public void TargetSpawner(){
			randX = Random.Range (-3.0f, 3.0f);
			randY = Random.Range (1.0f, 3.0f);
			randPos = new Vector3 (randX, randY, 5.8f);
			if (spawnedTarget.Count <= 10) {
				GameObject newTarget = Instantiate (spawnTarget, randPos, Quaternion.Euler (90.0f, 0, 0));
				spawnedTarget.Add (newTarget);
				Destroy (newTarget, 7.0f);
				spawnedTarget.Remove (null);
			}
		}
			
		IEnumerator TargetTimer(){
			while (currentTime>= 0 && GameManager.singleton.shootingCurState == GameManager.ShootingGameState.GameStart) {
				TargetSpawner ();
				yield return new WaitForSeconds (spawnRate);
			}
		}
	}
}