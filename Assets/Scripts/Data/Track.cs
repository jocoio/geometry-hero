using UnityEngine;

[System.Serializable]
public class Track
{
	public int startTime;
	public int duration;
	public int length;
    public Note[] notes;
	public int id;
	public string name;
	public int instrumentNumber;
	public string instrument;
	public string instrumentFamily;
	public int channelNumber;
	public bool isPercussion;
}