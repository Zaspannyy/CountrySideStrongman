using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Player : MonoBehaviour
	{
		[SerializeField]
		private Transform m_tool;
		[SerializeField]
		private GameSettings m_settings;
		
		
		private bool m_isDown;

		private void Update()
		{
			ToolSwing();
		}

		private void ToolSwing()
		{
			var angels = m_tool.localEulerAngles;
			var target = m_settings.range * (m_isDown ? -1f : 1f);
			var x = Mathf.MoveTowardsAngle(angels.x, target, m_settings.speed * Time.deltaTime);
			angels.x = x;
			m_tool.localEulerAngles = angels;
		}
		public void OnDown()
		{
			m_isDown = true;
		}

		public void OnUp()
		{
			m_isDown = false;
		}
	}
}