using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator m_animator;
        [SerializeField]
        private GameController m_gameController;
        [SerializeField]
        private GameSettings m_settings;
        

        private bool m_isDown;
        private void Start()
        {
            m_animator.SetFloat("MoveSpeed", 0);
        }
        void Update()
        {
            if (m_isDown)
            {
                MoveToolForward();
            }
            else MoveToolBackward();

           
        }

        private void MoveToolForward()
        {
            m_animator.SetFloat("MoveSpeed", Mathf.Lerp(m_animator.GetFloat("MoveSpeed"), 1, m_settings.speed * Time.deltaTime));
        }
        private void MoveToolBackward()
        {
            
                m_animator.SetFloat("MoveSpeed", Mathf.Lerp(m_animator.GetFloat("MoveSpeed"), 0, m_settings.speed * Time.deltaTime));
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
