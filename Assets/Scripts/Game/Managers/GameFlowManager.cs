using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.FPS.Game
{
    public class GameFlowManager : MonoBehaviour
    {
        [Header("Win")]
        public string WinSceneName = "WinScene";

        [Header("Lose")]
        public string LoseSceneName = "LoseScene";

        public bool GameIsEnding { get; private set; }

        void Awake()
        {
            EventManager.AddListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            EventManager.AddListener<PlayerDeathEvent>(OnPlayerDeath);
        }

        void OnAllObjectivesCompleted(AllObjectivesCompletedEvent evt)
        {
            EndGame(true);
        }

        void OnPlayerDeath(PlayerDeathEvent evt)
        {
            EndGame(false);
        }

        void EndGame(bool win)
        {
            if (GameIsEnding)
                return;

            GameIsEnding = true;

            // Unlock the cursor so the player can use the end screen
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Load the appropriate scene immediately
            if (win)
            {
                SceneManager.LoadScene(WinSceneName);
            }
            else
            {
                SceneManager.LoadScene(LoseSceneName);
            }
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            EventManager.RemoveListener<PlayerDeathEvent>(OnPlayerDeath);
        }
    }
}
