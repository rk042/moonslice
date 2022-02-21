using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSlice.Core
{    
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        [SerializeField] private GameObject bullet;
        
        
        [SerializeField] float padding = 1f;

        [SerializeField] Transform bulletShootTransform;
                
        private Camera mainCamera;
        float xMin;
        float xMax;
        float yMin;
        float yMax;

        private void Awake()
        {
            mainCamera=Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
            xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
            yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
            yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

            transform.position=new Vector3(0,yMin,0);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet,bulletShootTransform.position,Quaternion.identity);
            }
        }

        private void movement()
        {
            var deltax = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            var deltay = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

            var newXPos = Mathf.Clamp(transform.position.x + deltax, xMin, xMax);
            var newYPos = Mathf.Clamp(transform.position.y + deltay, yMin, yMax);

            transform.position = new Vector2(newXPos, newYPos);
        }

    }
}
