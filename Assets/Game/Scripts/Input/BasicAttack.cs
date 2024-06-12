using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float strenght = 7f;
    public float radius = 7f;
    public GameObject BoomPrefab;

    private float lastAttackTime = -1000000f;
    private Explosion explosion;

    private void Awake()
    {
        explosion = new Explosion();
    }

    private void Update()
    {
        if (GameManager.singleton.gameState == GameManager.GameState.gameplay)
        {
            if (1 / attackSpeed <= Time.time - lastAttackTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePosition = PlayerInput.singleton.FindMousePosition();
                    explosion.Boom(mousePosition, strenght, radius);
                    GameObject boomInstance = Instantiate(BoomPrefab, mousePosition, new Quaternion(0, 0, 0, 0));
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
