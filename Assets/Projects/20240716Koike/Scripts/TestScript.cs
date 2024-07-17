using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Formats.Alembic.Importer
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField] AlembicStreamPlayer alembicStreamPlayer;

        private float animationDuration;
        public float currentTime;
        public float timeMoveSpeed;
        private float lastMousePositionX;

        // Start is called before the first frame update
        void Start()
        {
            animationDuration = alembicStreamPlayer.EndTime;
            currentTime = 0;
            alembicStreamPlayer.CurrentTime = currentTime;
            lastMousePositionX = Input.mousePosition.x;
        }

        // Update is called once per frame
        void Update()
        {
            if(lastMousePositionX < Input.mousePosition.x && Input.GetMouseButton(0))
            {
                var diff = Input.mousePosition.x - lastMousePositionX;
                currentTime += diff * timeMoveSpeed;
                if(currentTime >= animationDuration) {
                    currentTime = animationDuration;
                }
            }
            alembicStreamPlayer.CurrentTime = currentTime;

            lastMousePositionX = Input.mousePosition.x;
        }
    }
}