using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG {
    public class WorldSaveGameManager : MonoBehaviour {

        public static WorldSaveGameManager instance; //This is going to be a singleton if we want we can call it a Singleton.

        [SerializeField] int worldSceneIndex = 1;

        //Bu script teki instance sadece bir kez çağrılır eğer daha önceden çağrılmışsa yok edilir. 
        private void Awake() {
            
            if (instance == null) {

                instance = this;

            } else {

                Destroy(gameObject);

            }
        }


        private void Start() {

            DontDestroyOnLoad(gameObject);

        }

        public IEnumerator LoadNewGame() {

            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
            yield return null;

        }
    }
}
