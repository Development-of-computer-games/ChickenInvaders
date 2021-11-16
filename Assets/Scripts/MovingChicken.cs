using UnityEngine;

/**
 *  This component moves its object back and forth between two points in space, using a rigid body.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class MovingChicken : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    public Vector3  start, end;
    public bool isMoving = false;

    [SerializeField] float speed = 1f;

    private bool moveFromStartToEnd = true;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {

            rb.MovePosition(Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime));
        }
        else
        {  // move from end to start

            rb.MovePosition(Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime));
        }

        if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(start.x))
        {

            moveFromStartToEnd = true;
        }
        else if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(end.x))
        {
            moveFromStartToEnd = false;
        }

    }
}
