using System.Linq;
using Code.Gameplay.Features.Armaments.Behaviours;
using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.UI.Behaviours;
using Code.Gameplay.UI.Config;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(UIElementsConfig))]
    public class DeathSpawnerEditor: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            UIElementsConfig levelData = (UIElementsConfig)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.DeathColliderSpawners = FindObjectsOfType<DeathColliderSpawner>()
                    .Select(x =>
                        new DeathColliderSpawnerData(
                            x.transform.position))
                    .ToList();
                
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}