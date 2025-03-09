using System.Linq;
using Code.Gameplay.Features.Armaments.Behaviours;
using Code.Gameplay.Features.Armaments.Configs;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ArmamentsConfig))]
    public class EnemySpawnerEditor: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ArmamentsConfig levelData = (ArmamentsConfig)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.GunSpawners = FindObjectsOfType<SpawnArmamentMarket>()
                    .Select(x =>
                        new ArmamentsSpawnerData(
                            x.TypeId,
                            x.transform.position,
                            x.isLookRight))
                    .ToList();
                
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}