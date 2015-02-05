using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Node root;
	public Node parent;
	public Node left;
	public Node right;
	public int value;
	public int index;

	public int GetDepth () {
		var depth = 0;
		var node = this;
		while (node.parent) {
			node = node.parent;
			depth++;
		}
		return depth;
	}

	public void UpdatePosition () {
		var depth = GetDepth ();
		transform.position = new Vector3 (index, 5f - 1.1f * depth, 0);
	}

}
