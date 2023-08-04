using CodeBase.Interfaces;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Handlers
{
    public class CollisionHandlerTag : MonoBehaviour, ICollisionHandler
    {
        public string sphereTag = "Sphere";
        public int collisionCount = 0;
        public UIManager uiManager;

        private void Start()
        {
            if (uiManager != null)
            {
                uiManager.UpdateCollisionCount(collisionCount);
            }
        }

        private void Update()
        {
            CheckSphereCollision();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void CheckSphereCollision()
        {
            GameObject[] spheres = GameObject.FindGameObjectsWithTag(sphereTag);
            foreach (GameObject sphere in spheres)
            {
                if (IsCollidingWithSphere(sphere))
                {
                    collisionCount++;
                    GetComponent<Renderer>().material.color = Random.ColorHSV();
                    Destroy(sphere);
                    UpdateUI();

                    ICubeAnimation cubeAnimation = GetComponent<ICubeAnimation>();
                    if (cubeAnimation != null)
                    {
                        cubeAnimation.PlayShrinkAnimation();
                    }

                    break;
                }
            }
        }

        private bool IsCollidingWithSphere(GameObject sphere)
        {
            Vector3 cubePos = transform.position;
            Vector3 spherePos = sphere.transform.position;
            float collisionDistance = 1.5f;
            float distance = Vector3.Distance(cubePos, spherePos);
            return distance < collisionDistance;
        }

        private void UpdateUI()
        {
            if (uiManager != null)
            {
                uiManager.UpdateCollisionCount(collisionCount);
            }
        }

        public void HandleCollisionWithSphere()
        {
        
        }
    }
}