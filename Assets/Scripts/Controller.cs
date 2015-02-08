using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Camera camera;
	public GameObject prefabForNode;

	Node CreateNode () {
		var node = Instantiate (prefabForNode) as GameObject;
		return node.GetComponent<Node> ();
	}

	Node CreateNodeFromArray (int[] numbers, int start, int end, Node parent, Node root) {
		// Base case
		if (start > end) {
			return null;
		}

		var middleIndex = start + (end - start) / 2;
		var middleValue = numbers [middleIndex];

		var node = CreateNode ();
		node.index = middleIndex;
		node.parent = parent;
		node.value = middleValue;
		node.UpdateText ();

		if (!root) {
			root = node;
		}

		node.root = root;

		// Position the Node;
		node.UpdatePosition ();

		// Split numbers array
		node.left = CreateNodeFromArray (numbers, start, middleIndex - 1, node, root);
		node.right = CreateNodeFromArray (numbers, middleIndex + 1, end, node, root);

		return node;
	}

	// Use this for initialization
	void Start () {
		int[] numbers = new int[] {
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
//			3, 4, 5, 6
//			1, 2, 3, 4, 5, 6, 7
		};

		camera.transform.position = new Vector3 (numbers.Length / 2, 5, -15);

		var root = CreateNodeFromArray (numbers, 0, numbers.Length - 1, null, null);
	}
	
}
