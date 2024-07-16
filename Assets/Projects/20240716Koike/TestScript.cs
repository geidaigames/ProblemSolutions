using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Formats.Alembic.Importer
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField] AlembicStreamPlayer alembicStreamPlayer;

        public float gotParam;
        public float sendParam;

        // Start is called before the first frame update
        void Start()
        {
            gotParam = alembicStreamPlayer.EndTime;
        }

        // Update is called once per frame
        void Update()
        {
            sendParam = alembicStreamPlayer.CurrentTime;
        }
    }
}