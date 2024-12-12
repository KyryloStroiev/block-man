using TMPro;
using UnityEngine;

namespace Code.Gameplay.UI.Behaviours
{
    public class PointsCounter : MonoBehaviour
    {
        public TextMeshProUGUI PointsHeightText;
        public TextMeshProUGUI PointsDestructCubeText;
        private float _pointsHeight;
        private int _pointsDestructCube;

        public void SetPointsHeight(float points)
        {
            _pointsHeight = points;
            PointsHeightText.text = _pointsHeight.ToString("0.00");
        }
        
        public void SetPointsDestructCube(int points)
        {
            _pointsDestructCube = points;
            PointsDestructCubeText.text = _pointsDestructCube.ToString();
        }
    }
}