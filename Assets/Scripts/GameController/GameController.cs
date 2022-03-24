using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

        [Header("Score")]
        public int score;
        public Text textScore;

        public static GameController instance;

        //-4.5, 4.5

        void Start()
        {
            instance = this;
            InvokeRepeating("SpawnObstacle", 1f, 2f);
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
        }

        public void SetPoint(int value)
        {
            this.score += value;
            UpdateScoreUI();
        }

        public void UpdateScoreUI()
        {
            this.textScore.text = "Score: " + this.score.ToString();
        }

    }
}