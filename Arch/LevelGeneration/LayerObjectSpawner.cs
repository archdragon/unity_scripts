using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arch {
  namespace LevelGeneration {
    public class LayerObjectSpawner : MonoBehaviour {
      public static void SpawnTile(int[] tilesData, int tileNum, LevelData levelData) {
        string prefabName = PrefabName (tilesData[tileNum], "TILE");
        GameObject instance = Instantiate(Resources.Load("Prefabs/LayerObjects/" + prefabName, typeof(GameObject))) as GameObject;
        instance.transform.position = TilePosition(tileNum, levelData);
      }

    	// Use this for initialization
      public static void Spawn (LayerObjectData layerObject, LevelData levelData) {
        string prefabName = PrefabName (layerObject.gid, "OBJECT");
        GameObject instance = Instantiate(Resources.Load("Prefabs/LayerObjects/" + prefabName, typeof(GameObject))) as GameObject;
        instance.transform.position = ObjectPosition(layerObject, levelData);
    	}
    	
    	// Update is called once per frame
      private static string PrefabName (int globalId, string type) {
        string name = "";

        if (type == "TILE") {
          name = "Tiles/Grass";
        } else if(type == "OBJECT") {
          switch (globalId) {
          default:
            name = "Stone";
            break;
          }
        }

        return name;
    	}

        
      private static Vector3 ObjectPosition(LayerObjectData layerObject, LevelData levelData) {
        float resolution = 32f;
        float x = (float)layerObject.x/resolution;
        float y = (float)levelData.height - (float)layerObject.y/resolution;

        return new Vector3 (x, 0f, y);
      }

      private static Vector3 TilePosition(int tileNum, LevelData levelData) {
        float resolution = 32f;

        float y = Mathf.Floor((float)tileNum / (float)levelData.width);
        float x = (float)(tileNum % levelData.width);

        return new Vector3 (x, 0f, y);
      }
    }
  }
}
