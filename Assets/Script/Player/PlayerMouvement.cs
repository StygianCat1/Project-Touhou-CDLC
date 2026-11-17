using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private Boundaries _boundaries;
    
    [SerializeField] public float movementSpeedMultiplier = 10f;
    [SerializeField] public float slowSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInputs = GetComponent<PlayerInputs>();
        _boundaries = GetComponent<Boundaries>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    void Mouvement()
    {
        Vector3 NewPos = new Vector3(_playerInputs.moveInput.x * movementSpeedMultiplier * slowSpeed , transform.position.y, _playerInputs.moveInput.y * movementSpeedMultiplier * slowSpeed) * Time.deltaTime;
        print(_boundaries.CheckBoundaries(transform.position + NewPos));
        if (_boundaries.CheckBoundaries(transform.position + NewPos))
        {
            transform.Translate(NewPos);
        }
    }

    public void ChangeForSlowMovement(bool slow)
    {
        if (slow)
        {
            slowSpeed = 0.6f;
        }
        else
        {
            slowSpeed = 1f;
        }
    }
}
