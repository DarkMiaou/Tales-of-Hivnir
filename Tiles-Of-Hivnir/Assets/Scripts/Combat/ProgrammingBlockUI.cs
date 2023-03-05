using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TalesofHivnir
{
    
    public class ProgrammingBlockUI : ProgrammingBlockInterpreter
    {
        public GameObject blockButtonPrefab;
        public RectTransform blockListPanel;

        public void CreateBlockButtons()
        {
            foreach (ProgrammingBlock block in blockList)
            {
                GameObject blockButton = Instantiate(blockButtonPrefab, blockListPanel);

                blockButton.GetComponent<Button>().onClick.AddListener(delegate { AddBlockToList(block);});
            }
                
        }

        void AddBlockToList(ProgrammingBlock block)
        {
            blockList.Add(block);
        }
    }
}
