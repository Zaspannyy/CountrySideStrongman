using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private StoneSpawner m_stoneSpawner;
		
		[SerializeField]
		private UIScorePanel m_scorePanel;
		[SerializeField]
		private GameSettings m_settings;
		[SerializeField]
		private GameObject[] m_uiElements;
		


		private List<GameObject> m_stones = new();
		public int m_score = 0;
		public int m_maxScore = 0;
		private float m_timer = 0f;
		private float m_delay = 0f;
		private float m_maxDelay = 0f;

		private void Start()
		{
			MainMenuState();
			
		}
		
		

		public void MainMenuState()
		{
			
			foreach (GameObject ui in m_uiElements)
				{
				if (ui.tag == "MainMenu")
				{
					ui.SetActive(true);
				}
				else ui.SetActive(false);
				}
			enabled = false;
			RefreshScore(m_maxScore);
		}
		public void LoseState()
        {
			ClearStones();

			foreach (GameObject ui in m_uiElements)
            {
				if (ui.tag == "Lose")
				{
					ui.SetActive(true);
				}
				else ui.SetActive(false);
            }
			enabled = false;
			
        }

		private float CalcNextDelay()
		{
			var delay = Random.Range(m_settings.minDelay, m_maxDelay);
			//Debug.Log($"CalcNextDelay - delay: {delay} - maxDelay: {m_maxDelay}");
			return delay;
		}

		public void GameState()
		{
			m_delay = CalcNextDelay();
			m_maxDelay = m_settings.maxDelay;

			enabled = true;

			foreach (GameObject ui in m_uiElements)
			{
				if (ui.tag == "Game")
				{
					ui.SetActive(true);
				}
				else ui.SetActive(false);
			}
			m_score = 0;
			RefreshScore(m_score);

			StartGame();
		}

		private void StartGame()
		{
			GameEvents.onGameOver += OnGameOver;
			
		}

		private void OnGameOver()
		{
			GameEvents.onGameOver -= OnGameOver;
			

			LoseState();
			
		}

		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				Destroy(stone);
			}
			m_stones.Clear();
		}

		private void Update()
		{
			m_timer += Time.deltaTime;
			if (m_timer >= m_delay)
			{
				var stone = m_stoneSpawner.Spawn();
				m_stones.Add(stone);
				m_timer -= m_delay;

				m_delay = CalcNextDelay();
				m_maxDelay -= m_settings.stepDelay;
				if (m_maxDelay <= 0.75f)
                {
					m_maxDelay = 1f;
                }
			}
		}

		public void RefreshScore(int score)
		{
			m_scorePanel.SetScore(score);
		}

		public void OnCollisionStone(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Stone>(out var stone))
			{
				stone.SetAffect(false);
				var contact = collision.contacts[0];

				var stick = contact.thisCollider.GetComponent<Stick>();
				
				var body = stone.GetComponent<Rigidbody>();
				body.AddForce(stick.dir * m_settings.power, ForceMode.Impulse);

				
				m_score++;
				
				m_maxScore = Mathf.Max(m_score, m_maxScore);
				RefreshScore(m_score);

				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}
		

		private void OnDestroy()
		{
			GameEvents.onGameOver -= OnGameOver;
		}
	}
}