using UnityEngine;

public class MovePerson : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * - 1, 0, 0);
        }
    }
}
