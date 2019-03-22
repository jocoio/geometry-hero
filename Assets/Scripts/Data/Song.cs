using UnityEngine;

[System.Serializable]
public class Song
{
    public float duration;
    public Tempo tempo;
    public Track[] tracks;

    public static Song CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Song>(jsonString);
    }
}