using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "PacStudent")
		{
			Destroy(gameObject);
		}
	}
}
