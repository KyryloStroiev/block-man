using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Windows
{
    [CreateAssetMenu(fileName = "windowConfig", menuName = "Configs/windowConfig")]
    public class WindowsConfig : ScriptableObject
    {
        public List<WindowConfig> WindowConfigs;
    }
}