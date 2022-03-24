using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameController
{
    public class GameController : MonoBehaviour
    {
        [Header("Pause game")]
        public bool runningStatus = true;

        [Header("Spawn Obstacles")]
        public GameObject obstacle;
        public Transform spawnLocation;
        public float y = 4.5f;
        public float firstSpawnAfter;
        public float spawnTime;

        [Header("Score")]
        public int score;
        public Text textScore;
        public bool startWithZero = false;

        [Header("Game Over")]
        public GameObject gameOverUI;

        public static GameController instance;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            if(PlayerPrefs.GetInt("score") > 0 && !this.startWithZero)
            {
                this.score = PlayerPrefs.GetInt("score");
            } else if(this.startWithZero)
            {
                this.score = 0;
            }
            this.UpdateScoreUI();

            InvokeRepeating("SpawnObstacle", firstSpawnAfter, spawnTime);
            Time.timeScale = 1;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                PauseGame();
            }
        }

        private void SpawnObstacle()
        {
            Vector3 spawnPosition = new Vector3(spawnLocation.position.x, Random.Range(-y, y));
            Instantiate(obstacle, spawnPosition, spawnLocation.rotation);
        }

        public void PauseGame()
        {

            if (runningStatus)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            runningStatus = !runningStatus;
        }

        public void GameOver()
        {
            Debug.Log("Game over já era");
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }

        public void SetScore(int value)
        {
            this.score += value;
            UpdateScoreUI();
            PlayerPrefs.SetInt("score", this.score);
        }

        public void UpdateScoreUI()
        {
            this.textScore.text = "Score: " + this.score.ToString();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(0);
        }

    }
}