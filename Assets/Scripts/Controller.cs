using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public GameObject prefabForNode;

	Node CreateNode () {
		var node = Instantiate (prefabForNode) as GameObject;
		return node.GetComponent<Node> ();
	}

	Node CreateNodeFromArray (int[] numbers, int start, int end, Node parent) {
		// Base case
		if (start > end) {
			return null;
		}

		var middleIndex = (start + end) / 2;
		var middleValue = numbers [middleIndex];

		print ("Middle Index: " + middleIndex);

		var node = CreateNode ();
		node.value = middleValue;
		node.parent = parent;

		// Position the Node;
		node.UpdatePosition ();

		// Split numbers array
		node.left = CreateNodeFromArray (numbers, start, middleIndex - 1, node);
		node.right = CreateNodeFromArray (numbers, middleIndex + 1, end, node);

		return node;
	}

	// Use this for initialization
	void Start () {
		int[] numbers = new int[] {
			3, 4, 5
			//1, 2, 3, 4, 5, 6, 7
		};

		var root = CreateNodeFromArray (numbers, 0, numbers.Length - 1, null);
	}
	
}
