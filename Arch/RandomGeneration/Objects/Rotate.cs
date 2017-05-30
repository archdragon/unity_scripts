using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arch {
  namespace RandomGeneration {
    namespace Objects {
      public class Rotate : MonoBehaviour {
        public float tiltMin = -5f;
        public float tiltMax = 5f;

      	// Use this for initialization
      	void Start () {
          RotateObject();
      	}
      	
      	// Update is called once per frame
      	void Update () {
      		
      	}

        private void RotateObject() {
          float rotationY = 90.0f * (float)Random.Range (0, 4);
          float tiltX = Random.Range (tiltMin, tiltMax);
          float tiltY = Random.Range (tiltMin, tiltMax);

          transform.Rotate (tiltX, rotationY, tiltY);
        }
      }
    }
  }
}
