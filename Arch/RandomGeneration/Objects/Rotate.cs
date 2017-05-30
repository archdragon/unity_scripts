using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arch {
  namespace RandomGeneration {
    namespace Objects {
      public class Rotate : MonoBehaviour {

      	// Use this for initialization
      	void Start () {
          RotateObject();
      	}
      	
      	// Update is called once per frame
      	void Update () {
      		
      	}

        private void RotateObject() {
          float rotationY = 90.0f * (float)Random.Range (0, 4);
          transform.Rotate (0, rotationY, 0);
        }
      }
    }
  }
}
