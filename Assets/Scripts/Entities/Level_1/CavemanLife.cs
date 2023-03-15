using UnityEngine;

public class CavemanLife : MonoBehaviour
{
    [SerializeField] int life;
    public bool isDeath;

    private void Update()
    {
        if (isDeath)
        {
            Destroy(gameObject);
        }
    }

    public void getNaturalDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            isDeath = true;
        }

    }
}

