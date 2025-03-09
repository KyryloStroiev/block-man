using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "PlayerProgress";
        private readonly GameContext _gameContext;
        private readonly IProgressProvider _progressProvider;

        public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);
       
        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData());
        }

        public SaveLoadService(GameContext gameContext, IProgressProvider progressProvider)
        {
            _gameContext = gameContext;
            _progressProvider = progressProvider;
        }

        public void SaveProgress()
        {
            PreserveGameEntities();
            PlayerPrefs.SetString(ProgressKey, _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            _progressProvider.SetProgressData(PlayerPrefs.GetString(ProgressKey).FromJson<ProgressData>());
            HydrateGameEntities();
        }
        
        

        private void HydrateGameEntities()
        {
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.MetaEntitySnapshots;
            foreach (EntitySnapshot snapshot in snapshots)
            {
                _gameContext
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveGameEntities()
        {
            _progressProvider.ProgressData.EntityData.MetaEntitySnapshots = _gameContext
                .GetEntities()
                .Where(e => RequiresSave(e))
                .Select( e => e.AsSavedEntity())
                .ToList();
        }

        private static bool RequiresSave(GameEntity e)
        {
            return e.GetComponents().Any(c => c is ISavedComponent);
        }
    }
}