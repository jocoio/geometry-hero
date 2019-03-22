using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{

  public GameObject obstacle;
  public GameObject floor;
	public AudioSource song;

  private string gameDataFileName = "test.json";
  private Song test_song;
  private Vector2 originPosition;
  private Note[] obstacles;

  private double duration;


  void Awake()
  {
    LoadGameData();
		originPosition = transform.position;
  }

	void Start()
	{
		song.Play();
	} 

  private void LoadGameData()
  {
    // Path.Combine combines strings into a file path
    // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
    string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

    if (File.Exists(filePath))
    {
      // Read the json from the file into a string
      string dataAsJson = File.ReadAllText(filePath);
      // Pass the json to JsonUtility, and tell it to create a GameData object from it
      test_song = Song.CreateFromJSON(dataAsJson);
      
      obstacles = test_song.tracks[0].notes;

      SpawnLevel();
    }
    else
    {
      Debug.LogError("Cannot load game data!");
    }
  }

  private void SpawnLevel()
  {
		// Ground object
		Vector2 groundPosition = new Vector2(originPosition.x + (test_song.duration * 2.5f), originPosition.y - 1);
    GameObject ground = Instantiate(floor, groundPosition, Quaternion.identity) as GameObject;  // instatiate the object
    ground.transform.localScale = new Vector3(test_song.duration * 5, 1, 1); // change its local scale in x y z format

		// Obstacle objects
    for (int i = 0; i < obstacles.Length; i++)
    {
      Vector2 obstaclePosition = new Vector2(obstacles[i].time * 5f, originPosition.y);
      Instantiate(obstacle, obstaclePosition, Quaternion.identity);
    }
  }
}
