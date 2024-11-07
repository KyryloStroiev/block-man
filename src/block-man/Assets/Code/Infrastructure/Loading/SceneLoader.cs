using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Loading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string name, Action onLoader = null) => 
            _coroutineRunner.StartCoroutine(Load(name, onLoader));


        private IEnumerator Load(string nextScene, Action onLoader)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoader?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;
            
            onLoader?.Invoke();
        }
    }
}