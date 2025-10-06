using UnityEngine;
using UnityEngine.Profiling;

public class SpinCube : MonoBehaviour
{
        public float speedRotation;
        public float speedScale;
        public float maxHeight;
        public float minHeight;

        private bool loop;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y <= minHeight)
            {
                loop = true;
            }
            if (transform.position.y >= maxHeight)
            {
                loop = false;
            }

            if (loop)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, maxHeight+1, Time.deltaTime * speedScale), transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, minHeight-1, Time.deltaTime * speedScale), transform.position.z);
            }
            
            transform.Rotate(Vector3.forward, speedRotation*Time.deltaTime);
        }
}
