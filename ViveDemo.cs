using UnityEngine;
using System.Collections;

public class ViveDemo : MonoBehaviour {

	public Transform player;
	public SteamVR_TrackedObject left, right;
	public GameObject bullet;
	public float fadeTime = 0.25f;

	private RaycastHit hit;
	
	void Update () {
		// Click trigger
		if(SteamVR_Controller.Input((int)right.index).GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) {
			Rigidbody rb = (Instantiate(bullet, right.transform.position, Quaternion.identity) as GameObject).GetComponent<Rigidbody>();
			rb.AddForce(right.transform.forward * 1000);
		}

		// Teleport
		if(SteamVR_Controller.Input((int)right.index).GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
			if(Physics.Raycast(right.transform.position, right.transform.forward, out hit, Mathf.Infinity, 1 << 8)) {
				StartCoroutine(Teleport(hit.point));
			}
		}
	}

	// IEnumerator is a timed function which you start with StartCoroutine(fnName)
	private IEnumerator Teleport(Vector3 pos) {
		SteamVR_Fade.View(Color.black, fadeTime);
		yield return new WaitForSeconds(fadeTime); // Wait for some number of seconds
		player.position = hit.point;
		SteamVR_Fade.View(Color.clear, fadeTime);
	}
}