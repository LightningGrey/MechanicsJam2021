using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Node _leftNode;
    [SerializeField] private Node _rightNode;
    [SerializeField] private NodeConnector _connector;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNode(bool left, Vector3 newPos)
    {
        Node activeNode = left ? _leftNode : _rightNode;
        activeNode.gameObject.SetActive(true);
        activeNode.Spawn(newPos);

        if (_leftNode.gameObject.activeSelf && _rightNode.gameObject.activeSelf)
        {
            _connector.Connect(_leftNode.transform.position, _rightNode.transform.position);
        }

    }

    public void Reset()
    {
        _leftNode.gameObject.SetActive(false);
        _rightNode.gameObject.SetActive(false);
        _connector.gameObject.SetActive(false);
    }


}
