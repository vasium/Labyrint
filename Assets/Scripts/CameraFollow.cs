using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform cameraPosition;
        public float cameraSpeed = 4f;

        Vector3 cameraOffset;


        void Start()
        {
            cameraOffset = transform.position - cameraPosition.position;
        }


        void FixedUpdate()
        {
            Vector3 targetCamPos = cameraPosition.position + cameraOffset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, cameraSpeed * Time.deltaTime);
        }
    }
}