using UnityEngine;

namespace AI.Aggression
{
    public static class EnemyUtilities
    {
        public static void FollowPlayer(Transform enemyTransform, Transform target, float moveSpeed)
        {
            if (enemyTransform == null || target == null)
            {
                Debug.LogError("Enemy or target transform is null.");
                return;
            }

            enemyTransform.LookAt(target);
            enemyTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}