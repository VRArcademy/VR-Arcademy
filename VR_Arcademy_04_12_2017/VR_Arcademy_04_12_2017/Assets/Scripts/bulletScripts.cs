namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class bulletScripts : MonoBehaviour {

		void Start () {
			
		}

		void Update () {
			Destroy (gameObject, 3.0f);
		}

		/*void OnTriggerEnter(Collider other){
			if (other) {
				Destroy (this.gameObject);
			}
		}*/
	}
}
