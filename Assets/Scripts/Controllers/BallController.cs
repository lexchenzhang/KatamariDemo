using UnityEngine;
using com.lex.katamari.util.ui;

public class BallController : MonoBehaviour
{
    [SerializeField] private float rollSpeed;
    private Rigidbody _rigidbody;
    private bool _shake;

    void Start()
    {
        _shake = false;
        _rigidbody = GetComponent<Rigidbody>();
        EventMgr.current.OnItemPickedUpTriggerEnter += OnItemPickedUp;
    }

    void FixedUpdate()
    {
        UserInput();
    }

    private void UserInput()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _rigidbody.AddForce(input * rollSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(20 * new Vector3(0, 1, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_shake)
        {
            CameraShake.Shake(.2f, .1f);
            _shake = true;
        }
    }

    // use Trigger instead of Collider for better UX
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            // fire up the on-pick event so that every subscriber who subscribed this event
            // will get notified and trigger corresponding function
            EventMgr.current.ItemPickedUpTriggerEnter(other.gameObject.GetComponent<ICollectable>());
        }
    }

    private void OnItemPickedUp(ICollectable item)
    {
        item.StickToTheBall(gameObject);
    }
}
