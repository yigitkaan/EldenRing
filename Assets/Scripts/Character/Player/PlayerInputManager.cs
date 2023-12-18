using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG {
    public class PlayerInputManager : MonoBehaviour {

        public static PlayerInputManager instance;

        PlayerControls playerControls;

        [SerializeField] Vector2 movementInput;


        private void Awake() {

            //Singleton
            if (instance == null) {

                instance = this;

            } else {

                Destroy(instance);

            }
            //-----------------------

           

        }

        private void Start() {

            DontDestroyOnLoad(gameObject);

            //When the scene changes, run this logic
            SceneManager.activeSceneChanged += OnSceneChanged;

            instance.enabled = false;

        }

        void OnSceneChanged(Scene oldScene, Scene newScene) {

            //If we are loading into our world scene, enable our players controls
            if(newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex()) {

                instance.enabled = true;

            //Otherwise we must be at the main menu, disable our players controls
            //This is so our player cant move around if we enter things like a character creation menu ect
            } else {

                instance.enabled = false;

            }

        }
        private void OnEnable() {
            
            if (playerControls == null) {

                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput =  i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void OnDestroy() {

            //If we destroy this object, unsubscribe from tihs event
            SceneManager.activeSceneChanged -= OnSceneChanged;

        }
    }
}
