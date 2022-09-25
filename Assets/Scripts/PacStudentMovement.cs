using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
	public float speed = 0.35f;
	private Vector2 desti = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        desti = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, desti, speed);
		GetComponent<Rigidbody2D>().MovePosition(temp);
		if ((Vector2)transform.position==desti)
		{
			if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Valid(Vector2.up))
				{
			desti = (Vector2)transform.position + Vector2.up;
				}
			if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Valid(Vector2.down))
				{
			desti = (Vector2)transform.position + Vector2.down;
				}
			if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Valid(Vector2.right))
				{
			desti = (Vector2)transform.position + Vector2.right;
				}
			if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Valid(Vector2.left))
				{
			desti = (Vector2)transform.position + Vector2.left;
				}
				Vector2 dir = desti - (Vector2)transform.position;
				GetComponent<Animator>().SetFloat("X", dir.x);
				GetComponent<Animator>().SetFloat("Y", dir.y);
		}
    }
	
	private bool Valid(Vector2 dir)
	{
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}
}
