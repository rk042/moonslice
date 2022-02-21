using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSlice.Core
{
    public class CircleManager : MonoBehaviour,IGenerateCircle
    {
        [SerializeField] private Transform circleParent;
        [SerializeField] private List<GameObject> circleList=new List<GameObject>();
        [SerializeField] private int circleNumber=0;

        private void Start()
        {
            Instantiate(circleList[circleNumber], circleParent);                        
            circleNumber++;
        }
    
        public void GenerateCircle()
        {                                    
            foreach (Transform item in circleParent)
            {
                Destroy(item.gameObject);
            }                

            Instantiate(circleList[circleNumber], circleParent);   
            
            circleNumber++;           
            
            if (circleNumber==circleList.Count)
            {
                circleNumber=0;    
            }
            
        }

        public void InverseGenerateCircle()
        {
            foreach (Transform item in circleParent)
            {
                Destroy(item.gameObject);
            }
            
            circleNumber-=2;
            
            if (circleNumber == circleList.Count || circleNumber<=0)
            {
                circleNumber = 0;
            }
                        
            Instantiate(circleList[circleNumber], circleParent);                          
        }
    }    
}
