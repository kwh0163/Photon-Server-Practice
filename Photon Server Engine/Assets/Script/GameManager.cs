using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public Vector3 RandomPosition(float value)
    {
        float radius = value;
        float x = Random.Range(-radius, radius);
        float z = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x, 2));

        if(Random.Range(0,2) == 0)
        {
            z = -z;
        }
        return new Vector3(x, 1, z);
    }

    IEnumerator Spawn(string name,float radius)
    {
        while (true)
        {
            PhotonNetwork.Instantiate(name, RandomPosition(radius), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

    private void Awake()
    {
        PhotonNetwork.Instantiate("Character", RandomPosition(10), Quaternion.identity);
    }
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Spawn("Bee", 100));
        }
    }

    public void ExidGame()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Photon Room");
    }
}
