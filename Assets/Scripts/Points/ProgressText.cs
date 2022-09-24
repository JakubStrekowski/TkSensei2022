using System;
using TMPro;
using UnityEngine;

namespace Points
{
    public class ProgressText : MonoBehaviour
    {
        private TMP_Text _textComponent;
        private PointCounter _pointCounter;

        public string BaseText = "Progress: {0:0.00}%";

        private void Awake()
        {
            _textComponent = GetComponent<TMP_Text>();
            _pointCounter = FindObjectOfType<PointCounter>();
        }

        private void Update()
        {
            _textComponent.text = String.Format(BaseText, _pointCounter.RatioScore * 100f);
        }
    }
}