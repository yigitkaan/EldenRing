using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace SG {

    public class PlayerUIManager : MonoBehaviour {

        public static PlayerUIManager instance;

        [Header("NETWORK JOIN")]
        [SerializeField] bool startGameAsClient;

        private void Awake() {
            
            if (instance == null) {

                instance = this;

            } else {

                Destroy(gameObject);

            }

        }

        private void Update() {
            
            if (startGameAsClient) {

                startGameAsClient = false;
                //We must first shut down, because we have started as a host during the title screen.
                NetworkManager.Singleton.Shutdown();
                //We then restart, as a client
                NetworkManager.Singleton.StartClient();

            }

        }

    }

}
