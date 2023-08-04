using CodeBase.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private static UIManager Instance { get; set; }

        public Text collisionCountText;

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

        public void UpdateCollisionCount(int count)
        {
            collisionCountText.text = "Collisions: " + count;
        }
    }
}