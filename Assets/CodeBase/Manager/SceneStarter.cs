using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    public class SceneStarter : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}