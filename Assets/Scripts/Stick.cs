using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{

	public class Stick : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent<Collision> onCollisionStone;

		private Vector3 m_lastPosition;
		private Vector3 m_direction;
		public Vector3 dir => m_direction.normalized;
		public bool hasTouched;
		private void OnCollisionEnter(Collision other)
		{
			hasTouched = true;
			onCollisionStone.Invoke(other);

		}

		private void Update()
		{
			hasTouched = false;
			m_direction = transform.position - m_lastPosition;
			m_lastPosition = transform.position;
		}
	}
}