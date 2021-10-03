using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Node _leftNode;
    [SerializeField] private Node _rightNode;
    [SerializeField] private NodeConnector _connector;

    public void UpdateNode(bool left, RaycastHit hit)
    {
        //don't attach both nodes to same platform
        Node otherNode = left ? _rightNode : _leftNode;

        if (hit.transform.gameObject.tag != "Platform" || 
            (hit.transform.gameObject.tag == "Platform" && 
             hit.transform.gameObject != otherNode.AttachedObj?.gameObject))
        {
            Node activeNode = left ? _leftNode : _rightNode;
            activeNode.gameObject.SetActive(true);
            activeNode.Spawn(hit);

            if (_leftNode.gameObject.activeSelf && _rightNode.gameObject.activeSelf)
            {
                _connector.Connect(_leftNode.transform.position, _rightNode.transform.position);
                Debug.Log(Vector3.Distance(_leftNode.transform.position, _rightNode.transform.position));
            }

            if (_leftNode.IsAttached && _rightNode.IsAttached)
            {
                activeNode.PreMove(otherNode);
                otherNode.PreMove(activeNode);
            }
        }

    }

    public void Reset()
    {
        _leftNode.Reset();
        _rightNode.Reset();

        _connector.gameObject.SetActive(false);
    }


}
