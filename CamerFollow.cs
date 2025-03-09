using UnityEngine;

public class CamerFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(!player )
            return;
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;
        else if (tempPos.x > maxX)
            tempPos.x = maxX;
        transform.position = tempPos;

    }
}
