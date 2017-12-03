	namespace VRTK{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ScoreCount : MonoBehaviour {

		void Start () {
			
		}

		void Update () {
			
		}

		void OnTriggerEnter(Collider other){
			if (other.gameObject.CompareTag("Bullet")) {
				Destroy (gameObject);
				Destroy (other.gameObject);
				GameManager.singleton.score++;
			}
		}
	}
}
