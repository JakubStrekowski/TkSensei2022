using System;
using TMPro;
using UnityEngine;

namespace Points
{
    public class PointsText : MonoBehaviour
    {
        private TMP_Text _textComponent;
        private PointCounter _pointCounter;

        public string BaseText = "Points: {0}";

        private void Awake()
        {
            _textComponent = GetComponent<TMP_Text>();
            _pointCounter = FindObjectOfType<PointCounter>();
        }

        private void Update()
        {
            _textComponent.text = String.Format(BaseText, _pointCounter.CurrentScore);
        }
    }
}