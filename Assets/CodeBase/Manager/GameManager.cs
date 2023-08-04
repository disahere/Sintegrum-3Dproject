using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}