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
            var potionUp = Instantiate(data.explosion, new Vector2(position.x, position.y+1), Quaternion.identity);
            potionUp.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5) * 1000, ForceMode2D.Force);
            
            var potionLeft1 = Instantiate(data.explosion, new Vector2(position.x  + 1, position.y), Quaternion.identity);
            var potionLeft2 = Instantiate(data.explosion, new Vector2(position.x  + 1, position.y+1), Quaternion.identity);
            potionLeft1.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0) * 1000, ForceMode2D.Force);
            potionLeft2.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 5) * 1000, ForceMode2D.Force);
            var potionRight1 = Instantiate(data.explosion, new Vector2(position.x - 1, position.y), Quaternion.identity);
            var potionRight2 = Instantiate(data.explosion, new Vector2(position.x - 1, position.y+1), Quaternion.identity);
            potionRight1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0) * 1000, ForceMode2D.Force);
            potionRight2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 5) * 1000, ForceMode2D.Force);
            Destroy(gameObject);
            RaiseOnPotionDestroy(gameObject);
            IsDestroyed = true;
            
        }
    }
}
