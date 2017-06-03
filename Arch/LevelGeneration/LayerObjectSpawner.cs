using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arch {
  namespace LevelGeneration {
    public class LayerObjectSpawner : MonoBehaviour {

    	// Use this for initialization
      public static void Spawn (LayerObjectData layerObject, LevelData levelData) {
        string prefabName = PrefabName (layerObject.gid);
        GameObject instance = Instantiate(Resources.Load("Prefabs/LayerObjects/" + prefabName, typeof(GameObject))) as GameObject;
        instance.transform.position = ObjectPosition(layerObject, levelData);
    	}
    	
    	// Update is called once per frame
      private static string PrefabName (int globalId) {
        string name;

        switch (globalId) {
        default:
          name = "Stone";
          break;
        }

        return name;
    	}

      private static Vector3 ObjectPosition(LayerObjectData layerObject, LevelData levelData) {
        float resolution = 32f;
        float x = (float)layerObject.x/resolution;
        float y = (float)levelData.height - (float)layerObject.y/resolution;

        return new Vector3 (x, 0f, y);
      }
    }
  }
}
