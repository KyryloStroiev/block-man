using TMPro;
using UnityEngine;

namespace Code.Gameplay.UI.Behaviours
{
    public class PointsGameOver: MonoBehaviour
    {
        public TextMeshProUGUI TimeGameOverText;
        
        public void CounterGameOverPoints( float timer)
        {
            TimeGameOverText.text = $"You Time: {timer.ToString("00")} second !!";
        }
    }
}