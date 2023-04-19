using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir
{
    
    public class ProgrammingBlockInterpreter : MonoBehaviour
    {
        public List<ProgrammingBlock> blockList; // list des block de prog

        /*public void InterpretBlock()
        {
            Debug.Log("zzz");
            foreach (ProgrammingBlock block in blockList)
            {
                block.Execute();
            }
        }*/
        
        public float blockExecutionDelay = 0.5f;

        public void InterpretBlock()
        {
            StartCoroutine(ExecuteBlockSequence());
        }

        private IEnumerator ExecuteBlockSequence()
        {
            foreach (ProgrammingBlock block in blockList)
            {
                block.Execute();
                yield return new WaitForSeconds(blockExecutionDelay);
            }
        }
        
        public void AddBlock(ProgrammingBlock block)
        {
            if (!blockList.Contains(block))
            {
                blockList.Add(block);
            }
        }


    }
    
    
}
