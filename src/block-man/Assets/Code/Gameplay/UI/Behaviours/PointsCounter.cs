using System;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.UI.Behaviours
{
    public class PointsCounter : MonoBehaviour
    {
        public TextMeshProUGUI PointsHeightText;
        public TextMeshProUGUI TimeText;
        
        
        private float _pointsHeight;
        private int _pointsDestructCube;
        private float _time;

        public void SetTime(float time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
           
            TimeText.text = $"Time: {string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds)}";
        }
        
        public void SetPointsHeight(float points)
        {
            _pointsHeight = points;
            PointsHeightText.text =$"UP: {_pointsHeight.ToString("0.00")}";
        }
        
        
        
     
    }
}