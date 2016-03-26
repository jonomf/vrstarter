using UnityEngine;
using System.Collections;

public class CardboardGearDemo : MonoBehaviour {
	
	void Update () {
		if(Cardboard.SDK.Triggered  // Cardboard trigger down
			|| Input.GetMouseButtonDown(0)) { // MouseButtonDown = GearVR
			
			Transform sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
			sphere.position = transform.position + transform.forward * 2;
		}

		if(Input.GetKeyDown(KeyCode.Escape)) { // GearVR back button
			// Back out of menu etc
		}

		//Input.mousePosition // GearVR touchpad input
	}
}