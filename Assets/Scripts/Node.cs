using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Node root;
	public Node parent;
	public Node left;
	public Node right;
	public int value;
	public int index;

	// Representation
	public GameObject cube;
	public GameObject label;

	public void Start () {
	}

	public void UpdateText () {
		var text = label.GetComponent<TextMesh> ();
		text.text = value.ToString ();
	}

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

	public void SpillPaint (Color color) {
		cube.renderer.material.color = color;
		
		if (left) {
			left.SpillPaint (color);
		}

		if (right) {
			right.SpillPaint (color);
		}
	}

	public void OnMouseDown () {
		root.SpillPaint (Color.white);

		cube.renderer.material.color = Color.blue;
		
		var sibling = NextSiblingOfSameDepth ();
		if (sibling) {
			sibling.cube.renderer.material.color = Color.blue;

			ColorPathToNodeOfSameDepth (sibling);
		}
	}

	public void ColorPathToNodeOfSameDepth (Node end) {
		var start = this;

		while (start != end) {
			start = start.parent;
			end = end.parent;

			start.cube.renderer.material.color = Color.green;
			end.cube.renderer.material.color = Color.green;
		}
	}

	public Node NextSiblingOfSameDepth () {
		var targetDepth = GetDepth ();
		var currentDepth = targetDepth;

		if (!parent) {
			return null;
		}

		if (parent.left == this && parent.right) {
			return parent.right;
		}

		var node = this;
		Node potentialNode;
		while (node.parent) {
			node = node.parent;
			currentDepth--;

			if (node.parent.left == node && node.parent.right) {
				potentialNode = node.parent.right.GetChildOfDepth (targetDepth);
				if (potentialNode) {
					return potentialNode;
				}
			}
		}

		return null;
	}

	// Idea: Could we pass in the currentDepth?
	public Node GetChildOfDepth (int targetDepth) {
		var currentDepth = GetDepth ();
		Node node;

		if (left) {
			if (currentDepth == targetDepth -1) {
				return left;
			} else {
				left.cube.renderer.material.color = Color.red;
			}
			node = left.GetChildOfDepth (targetDepth);
			if (node) {
				return node;
			}
		}

		if (right) {
			if (currentDepth == targetDepth -1) {
				return right;
			} else {
				right.cube.renderer.material.color = Color.red;
			}
			node = right.GetChildOfDepth (targetDepth);
			if (node) {
				return node;
			}
		}

		return null;
	}

	public Node NextSiblingInOrder () {
		Node node;

		if (right) {
			node = right;
			while (node.left) {
				node = node.left;
			}
			return node;
		}

		node = this;
		while (node.parent) {
			if (node.parent.left == node) {
				return node.parent;
			}

			node = node.parent;
		}

		return null;
	}

}
