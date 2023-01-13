using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : BaseUnit
{
    public void ShootBulletAtMouse(BaseCard card)
    {
        Debug.Log("shot triggered");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mousePos - transform.position;
        direction.Normalize();

        GameObject projectile = Instantiate(card.shotPrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * card.speed * 100);
        Destroy(projectile, 10f);
        Destroy(card);
        Destroy(CardManager.Instance.SelectedCard.gameObject);
        Debug.Log(CardManager.Instance.SelectedCard);
        CardManager.Instance.canShoot = false;
    }
}
