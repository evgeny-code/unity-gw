using UnityEngine;

namespace desert
{
    public class GoButtonListener: LongClickButton
    {
        public float velocity = 10;
        public GameObject player;
        
        protected override void ClickAction()
        {
            Vector3 forward = player.transform.forward;
            Debug.Log(forward);
            player.transform.Translate(forward * (velocity * Time.deltaTime));
        }
    }
}