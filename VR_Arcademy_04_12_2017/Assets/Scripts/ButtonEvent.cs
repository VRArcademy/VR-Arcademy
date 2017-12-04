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

		public override void StartUsing(VRTK_InteractUse usingObject){
			base.StartUsing (usingObject);
			StartGame ();
			if (GameManager.singleton.shootingCurState == GameManager.ShootingGameState.GameStart ) {
				GameManager.singleton.currentTime = GameManager.singleton.Timeleft;
				StartCoroutine (TargetTimer ());
			}
		}

		protected void Start(){
			
		}

		public void StartGame(){
			GameManager.singleton.shootingCurState = GameManager.ShootingGameState.GameStart;
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
			while (GameManager.singleton.currentTime >= 0) {
				TargetSpawner ();
				yield return new WaitForSeconds (spawnRate);
			}
		}
	}
}