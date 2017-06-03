using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;    

namespace Arch {
  namespace LevelGeneration {
    [System.Serializable]
    public class LevelData {
      public int height;
      public int width;
      // public int tileHeight;
      // public int tileWidth;
      public LayerData[] layers;
    }

    [System.Serializable]
    public class LayerData {
      public string name;
      public int[] data;
      public LayerObjectData[] objects;
    }

    [System.Serializable]
    public class LayerObjectData {
      public int gid;
      public int height;
      public int width;
      public int x;
      public int y;
      public LayerObjectProperties properties;
    }

    [System.Serializable]
    public class LayerObjectProperties {
      public float show_chance;
    }

    public class LevelDataLoader : MonoBehaviour {
      public string levelDataFileName = "levels.json";

    	void Start() {
    		LoadLevelData ();
    	}

    	private void LoadLevelData()
    	{
        
     
    		// Path.Combine combines strings into a file path
    		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
    		string filePath = Path.Combine(Application.streamingAssetsPath, levelDataFileName);

    		if(File.Exists(filePath))
    		{
    			// Read the json from the file into a string
    			string dataAsJson = File.ReadAllText(filePath); 
       
    			// Pass the json to JsonUtility, and tell it to create a levelData object from it
    			LevelData levelData = JsonUtility.FromJson<LevelData>(dataAsJson);

          for (int layerNum = 0; layerNum < levelData.layers.Length; layerNum++) {
            LayerData layerData = levelData.layers [layerNum];
            LayerObjectData[] layerObjects = layerData.objects;

            // TODO: Extract to methods
            for (int objectNum = 0; objectNum < layerObjects.Length; objectNum++) {
              LayerObjectData layerObject = layerObjects [objectNum];

              SpawnObject (layerObject, levelData);
            }

            if (layerData.data != null) {

              for (int tileNum = 0; tileNum < layerData.data.Length; tileNum++) {
                SpawnTile (layerData.data, tileNum, levelData);
              }
            }

          }
    		}
    		else
    		{
    			Debug.LogError("Cannot load game data!");
    		}
    	}

      private void SpawnObject(LayerObjectData layerObject, LevelData levelData) {
        LayerObjectSpawner.Spawn (layerObject, levelData);
      }

      private void SpawnTile(int[] tilesData, int tileNum, LevelData levelData) {
        LayerObjectSpawner.SpawnTile (tilesData, tileNum, levelData);
      }
    }
  }
}
