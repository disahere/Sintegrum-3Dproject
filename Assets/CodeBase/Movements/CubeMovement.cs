using UnityEngine;

namespace CodeBase.Handlers
{
    public class CubeMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private void Update()
        {
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = transform.forward * verticalInput;
            transform.Translate(moveDirection * (moveSpeed * Time.deltaTime));
        }
    }
}