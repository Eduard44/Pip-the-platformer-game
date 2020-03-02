using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class MeleeAttack: MonoBehaviour
    {
        public int damage = 40;

        public float attackRange = 0.5f;

        public Transform attackPoint;

        public LayerMask enemyLayers;

        //public Animator animator;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Mouse0 Pressed");
                Attack();
            }
        }

        void Attack()
        {
            //animator.SetTrigger("Attack");

            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            if(enemiesHit.Length > 0)
            {
                foreach (var enemy in enemiesHit)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            
        }

    }

   
}
