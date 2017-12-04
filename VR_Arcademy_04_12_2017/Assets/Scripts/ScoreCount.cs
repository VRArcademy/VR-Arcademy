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
			if (other.gameObject.tag == ("Bullet")) {
				GameManager.singleton.score++;
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
		}
	}
}
