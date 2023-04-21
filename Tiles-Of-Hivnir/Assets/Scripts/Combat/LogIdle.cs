using System.Collections;
using UnityEngine;

namespace TalesofHivnir
{


    public class LogIdle : ProgrammingBlockInterpreter
    {
        private Animator anim;


        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
        }
    }

}