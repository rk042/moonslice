using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSlice.Core
{    
    
    public class Bullet : MonoBehaviour
    {    
        [SerializeField] float moveSpeed;

        IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(3f);
            Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector3(0,Time.deltaTime*moveSpeed,0));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            Debug.Log(other.tag);

            if (other.CompareTag("circle") || other.CompareTag("white"))
            {
                FindObjectOfType<CircleManager>().GetComponent<IGenerateCircle>().GenerateCircle();                       
            }

            if (other.CompareTag("black"))
            {                
                FindObjectOfType<CircleManager>().GetComponent<IGenerateCircle>().InverseGenerateCircle();                       
            }

            Destroy(gameObject);
        }
    }
}
