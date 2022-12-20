using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ScoreUP : MonoBehaviour
    {
        [SerializeField]
        private GameController m_gameController;
        

        private void OnTriggerEnter(Collider other)
        {
            m_gameController.m_score += 3;
            m_gameController.RefreshScore(m_gameController.m_score);
        }
    }
}