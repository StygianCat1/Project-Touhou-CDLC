using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private PlayerInputs _playerInputs;
    
    [SerializeField] public float movementSpeedMultiplier = 10f;
    [SerializeField] public float slowSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    void Mouvement()
    {
        transform.Translate(new Vector3(_playerInputs.moveInput.x * movementSpeedMultiplier * slowSpeed , transform.position.y, _playerInputs.moveInput.y * movementSpeedMultiplier * slowSpeed) * Time.deltaTime);
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
