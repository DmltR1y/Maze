using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Controller : MonoBehaviour
	{
		public float Speed = 2; // Скорость движения игрока

		private Rigidbody2D componentRigidbody;

		private void Start()
		{
        componentRigidbody = GetComponent<Rigidbody2D>();
		}

		public void MoveUp()
		{
			componentRigidbody.velocity += Vector2.up * Speed;
		}

		public void MoveDown()
		{
			componentRigidbody.velocity += Vector2.down * Speed;
		}

		public void MoveLeft()
		{
			componentRigidbody.velocity += Vector2.left * Speed;
		}

		public void MoveRight()
		{
			componentRigidbody.velocity += Vector2.right * Speed;
		}
	}

