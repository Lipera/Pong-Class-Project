using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private Transform tr;
	public float speed;
	public Boundary boundary;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (0.0f, moveVertical, 0.0f);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			tr.position.x,
			Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);
	}
}
