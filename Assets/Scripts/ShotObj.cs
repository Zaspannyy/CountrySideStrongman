using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ShotObj : MonoBehaviour
    {
        [SerializeField]
        private Stick m_stick;
        [SerializeField]
        private TMPro.TextMeshProUGUI ShootText;
        [SerializeField]
        private TMPro.TextMeshProUGUI[] Text;

        void Update()
        {
            if (m_stick.hasTouched)
            {
                GetName();
            }
        }
        public void GetName()
        {
            ShootText.text = Text[Random.Range(0, Text.Length)].text;
        }
    }
}