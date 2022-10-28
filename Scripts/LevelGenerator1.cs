using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator1 : MonoBehaviour
{
    public Room1 startRoom;
    public GameObject[] rooms;
    public GameObject player;
    public List<Room1> lastRooms = new List<Room1>();
    public float distance;
    public float cellSize;
    // Start is called before the first frame update
    void Start()
    {
        lastRooms.Add(startRoom);
    }

    // Update is called once per frame
    void Update()
    {
        List<Room1> rr = new List<Room1>();
        List<Room1> rrr = new List<Room1>();
        foreach (Room1 room in lastRooms)
        {
            if (Vector3.Distance(room.transform.position, player.transform.position) <= distance)
            {
                if (room.points.Count > 0)
                {
                    foreach (Transform t in room.points)
                    {
                        if (t != null)
                        {
                            GameObject g = Instantiate(rooms[Random.Range(0, rooms.Length)], t.transform.position + (t.transform.right * (cellSize / 2)), t.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                            rr.Add(g.GetComponent<Room1>());
                        }
                    }
                }
                rrr.Add(room);
                room.points.Clear();
            }
        }
        foreach (Room1 rt in rr)
        {
            lastRooms.Add(rt);
        }
        rr.Clear();
        foreach (Room1 r in rrr)
        {
            r.points.Clear();
            lastRooms.Remove(r);
        }
        rrr.Clear();
    }
}
