using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;

	void Start() {
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 4) {
			winText.text = "YOU WIN!";
		}
	}
}