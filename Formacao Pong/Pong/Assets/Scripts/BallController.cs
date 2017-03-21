using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private Rigidbody rb;
	private Transform tr;
	private GameObject player;
	private Transform playerTr;
	public float speed;

	private const float MAX_BOUNCE_ANGLE = 5 * Mathf.PI / 12; //Equivalent to 75 degrees

	void Start () {
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();

		//TODO change this code because it is ugly
		player = GameObject.FindGameObjectsWithTag("Player")[0];

		playerTr = player.GetComponent<Transform> ();

		rb.velocity = (new Vector3(-1 * 15, 0.0f, 0.0f));
	}

	void OnCollisionEnter (Collision col) {
		Vector3 vel;
		if (col.gameObject.tag == "Player") {
			vel = CalculateVelocityAgainstPlayer (playerTr);
			rb.velocity = speed * (vel.normalized);
		}

		if (col.gameObject.tag == "Wall") {
			vel = new Vector3(
				rb.velocity.x,
				-rb.velocity.y,
				0.0f
			);
			rb.velocity = speed * (vel.normalized);
		}
	}

	Vector3 CalculateVelocityAgainstPlayer(Transform trans) {
		float relativeIntersectY = (trans.position.y + (trans.localScale.y / 2)) - tr.position.y;
		float normalizedRelativeIntersectionY = relativeIntersectY / (trans.localScale.y / 2);
		float bounceAngle = normalizedRelativeIntersectionY * MAX_BOUNCE_ANGLE;

		Vector3 vel = new Vector3 (
			speed * Mathf.Sin(bounceAngle), 
			speed * Mathf.Cos(bounceAngle),
			0.0f
		);
		return vel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
