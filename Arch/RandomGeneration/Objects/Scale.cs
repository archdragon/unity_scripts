using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arch {
  namespace RandomGeneration {
    namespace Objects {
      public class Scale : MonoBehaviour {
        public float minScale = 0.75f;
        public float maxScale = 1.0f;

        void Start () {
          ScaleObject();
        }

        private void ScaleObject() {
          float scaleFactor = Random.Range (minScale, maxScale);
          transform.localScale = Vector3.one * scaleFactor;
        }
      }
    }
  }
}
