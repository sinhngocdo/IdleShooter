
using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Object
{
    public class ObjParentFly : SinhMonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 1f;
        [SerializeField] protected Vector3 direction = Vector3.right;

        private void Update()
        {
            transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
        }
    }
}
