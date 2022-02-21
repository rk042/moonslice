using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSlice.Core
{    
    public class Circle : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.forward*Time.deltaTime*10*rotateSpeed);
        }
    }
}
