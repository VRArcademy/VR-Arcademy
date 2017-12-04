namespace VRTK
{
using UnityEngine;

public class GunController : VRTK_InteractableObject {
		public GameObject Emitter;
		public GameObject BulletPrefab;

		[SerializeField]private float speed = 1000f;


		public override void StartUsing(VRTK_InteractUse usingObject){

			base.StartUsing (usingObject);
			GunFire ();
		}

		protected void Start(){
			
		}

		public void GunFire(){
			Rigidbody gunRig;
			GameObject shootBullet = Instantiate (BulletPrefab, Emitter.transform.position, Emitter.transform.rotation);
			gunRig = shootBullet.GetComponent<Rigidbody> ();
			VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(usingObject.gameObject), 1.0f );
			gunRig.AddForce (transform.forward * speed);
			Destroy (shootBullet, 10.0f);
		}
	}
}