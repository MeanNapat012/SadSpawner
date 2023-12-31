using UnityEngine;
using TMPro;

namespace SuperGame.FlappyBird
{
    public class Gameloop : MonoBehaviour
    {
        public GameObject Player;
        public bool GameIsRunning = false;

        Rigidbody2D rigidbody2D;
        
        void Start()
        {
            rigidbody2D = Player.GetComponent<Rigidbody2D>();
            PauseGame();
            endMenu.SetActive(false);
        }
        
        void PauseGame()
        {
            GameManager.Instance.Pause();
            SetIsUseGravity(false);
        }

        public void ResumeGame()
        {
            GameManager.Instance.Resume();
            SetIsUseGravity(true);
        }

        void SetIsUseGravity(bool isUse)
        {
            rigidbody2D.gravityScale = isUse ? 1 : 0;
            GameIsRunning = isUse;
        }

        //---------------------------------------------------UI ZONE
        public GameObject startButton;
        public GameObject endMenu;
        public TextMeshProUGUI hp_text;
        public Health life_point;

        public void StartGame()
        {
            ResumeGame();
            startButton.SetActive(false);
        }

        public void EndGame()
        {
            PauseGame();
            endMenu.SetActive(true);
        }

        public void RestartGame()
        {
            GameManager.Instance.Lose();
        }

        
    }
}