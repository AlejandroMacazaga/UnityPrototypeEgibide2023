using Entities.Potions.BasePotion.Scripts;
using UnityEngine;

namespace Entities.Potions.BouncePotion.Scripts
{
    public class BouncePotionBehavior : PotionBehavior
    {
        protected override void Explode()
        {
            if (IsDestroyed) return;
            var position = transform.position;
            var potionLeft = Instantiate(data.explosion, new Vector2(position.x  + 1, position.y), Quaternion.identity);
            potionLeft.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0) * 1000, ForceMode2D.Force);
            var potionRight = Instantiate(data.explosion, new Vector2(position.x - 1, position.y), Quaternion.identity);
            potionRight.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0) * 1000, ForceMode2D.Force);
            Destroy(gameObject);
            RaiseOnPotionDestroy(gameObject);
            IsDestroyed = true;
            
        }
    }
}
