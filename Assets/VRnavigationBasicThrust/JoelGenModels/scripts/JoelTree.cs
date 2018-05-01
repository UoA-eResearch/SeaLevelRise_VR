using UnityEngine;
using System.Collections;
using System;

public class JoelTree : MonoBehaviour {

    public GameObject TrunkPrefab;
    public GameObject[] LeafPrefabs;

    public Vector2 SizeRange = new Vector2(.8f, 1.2f);
    public Vector2 TrunkHeightRange = new Vector2(4f, 8f);
    public Vector2 LeafCountRange = new Vector2(5f, 10f);
    public Vector2 LeafSizeRange = new Vector2(2f, 3f);
    public Vector2 LeafPosRadiusRange = new Vector2(-1f, 1f);

    // Use this for initialization
    void Start () {
        generateTree();
        GetComponent<MeshRenderer>().enabled = false;
	}

    void generateTree() {
        float gs = JoelHelperMethods.RandomRange(SizeRange.x, SizeRange.y);
        GameObject trunk = (GameObject)Instantiate(TrunkPrefab, Vector3.zero, Quaternion.identity);
        trunk.transform.SetParent(this.transform,false);

        float trunkWidth = gs * JoelHelperMethods.RandomRange(.5f, .8f);
        trunk.transform.localScale = new Vector3(trunkWidth,
                                    gs * JoelHelperMethods.RandomRange(TrunkHeightRange.x, TrunkHeightRange.y),
                                    trunkWidth);
        trunk.transform.localPosition = new Vector3(0, trunk.transform.localScale.y / 2, 0);
        int leafCount = (int)JoelHelperMethods.RandomRange(LeafCountRange.x, LeafCountRange.y);
        for (int i = 0; i < leafCount; i++) {
            GameObject leafPrefab = LeafPrefabs[(int)JoelHelperMethods.RandomRange(0, LeafPrefabs.Length)];
            GameObject leaf = (GameObject)Instantiate(leafPrefab, Vector3.zero, Quaternion.identity);
            leaf.transform.SetParent(this.transform, false);
            leaf.transform.localScale = new Vector3(gs * JoelHelperMethods.RandomRange(LeafSizeRange.x, LeafSizeRange.y),
                                                    gs * JoelHelperMethods.RandomRange(LeafSizeRange.x, LeafSizeRange.y),
                                                    gs * JoelHelperMethods.RandomRange(LeafSizeRange.x, LeafSizeRange.y));
            leaf.transform.localPosition = UnityEngine.Random.insideUnitSphere * JoelHelperMethods.RandomRange(LeafPosRadiusRange.x, LeafPosRadiusRange.y);
            leaf.transform.localPosition = new Vector3(leaf.transform.localPosition.x,
                                                        leaf.transform.localPosition.y + trunk.transform.localScale.y,
                                                        leaf.transform.localPosition.z);
            //leaf.transform.Rotate(new Vector3(0, randomRange(0, 180), 0));
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
