using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrinFactory : MonoBehaviour {

    public int row = 50;
    public int col = 50;

    // Use this for initialization
    void Start () {

        GameObject go = Resources.Load("Cube") as GameObject;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject goo = Instantiate(go);
                goo.transform.position = new Vector3(i, 0, j);
                goo.transform.localScale *= 0.98f;
                goo.transform.parent = GameObject.Find("GameObject").transform;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
