using UnityEngine;

public class PlayerConfiguration : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] float moveSpeed;
    public float moveSPEED => moveSpeed;
}
