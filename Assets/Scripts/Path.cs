using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] points;
	public float speed = 0.2f;
	private int index = 0;
	
	private void FixedUpdate()
	{
		if(transform.position != points[index].position)
		{
			Vector2 tem = Vector2.MoveTowards(transform.position, points[index].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(tem);
		}
		else
		{
			index = (index+1) % points.Length;
		}
		Vector2 dir = points[index].position - transform.position;
		GetComponent<Animator>().SetFloat("X", dir.x);
		GetComponent<Animator>().SetFloat("Y", dir.y);
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "PacStudent")
		{
			Destroy(collision.gameObject);
		}
	}	
}
