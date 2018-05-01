using UnityEngine;
using System.Collections;

public class ObjectGrid : MonoBehaviour
{
    public GameObject prefab;
    public int CountWidth = 10, CountLength = 10;
    public float gridUnitSize = 10f;
    public Vector3 randomizePosition = new Vector3(6f, 0, 6f);

    // Use this for initialization
    void Start() {
        for (int i = 0; i < CountWidth; i++) {
            for (int j = 0; j < CountLength; j++) {
                Vector3 pos = new Vector3(i * gridUnitSize + JoelHelperMethods.RandomRange(0, randomizePosition.x),
                                         JoelHelperMethods.RandomRange(0, randomizePosition.y), 
                                         j * gridUnitSize + JoelHelperMethods.RandomRange(0, randomizePosition.z));
                GameObject go = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
                go.transform.SetParent(this.transform,false);
            }
        }
        GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update() {

    }
}
