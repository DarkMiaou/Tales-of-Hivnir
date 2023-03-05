using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir
{
    
    public class ProgrammingBlockInterpreter : MonoBehaviour
    {
        public List<ProgrammingBlock> blockList; // list des block de prog

        public void InterpretBlock()
        {
            foreach (ProgrammingBlock block in blockList)
            {
                block.Execute();
            }
        }


    }
}
