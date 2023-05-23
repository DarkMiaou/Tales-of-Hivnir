using System.Collections.Generic;
using System.Linq;
using TalesofHivnir;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockAligmentManager : MonoBehaviour//, IDropHandler
{
    [SerializeField] private RectTransform startBlock;
    [SerializeField] private float yOffset = 0.1f;
    [SerializeField] private float distanceThresHold = 50f;
    
    private RectTransform lastBlock;
    private ProgrammingBlockInterpreter interpreter;

    private void Start()
    {
        Debug.Log("BlockAligmentManager Start() called.");

        if (startBlock == null)
        {
            Debug.LogError("startBlock is null.");
            return;
        }
        
        interpreter = FindObjectOfType<ProgrammingBlockInterpreter>();

    }

    public void AddBlock(GameObject newBlockGameObject)
    {
        
        if (newBlockGameObject == null)
        {
            Debug.LogError("newBlockGameObject is null.");
            return;
        }

        if (ProgrammingBlockInterpreter.Blocks == null || ProgrammingBlockInterpreter.Blocks.Count == 0)
        {
            Debug.LogError("blocks list is null or empty.");
            return;
        }
        
        var newGameObect = newBlockGameObject;
            
        RectTransform newBlock = newGameObect.GetComponent<RectTransform>();

        lastBlock = ProgrammingBlockInterpreter.Blocks.Last();

        // Calculate the new block's position based on the last block's position and height
        Vector2 newPosition = new Vector2(
            lastBlock.anchoredPosition.x,
            lastBlock.anchoredPosition.y - lastBlock.sizeDelta.y - yOffset
        );
        
        Debug.Log(ProgrammingBlockInterpreter.Blocks.Count);

        
        // Align the new block to the calculated position
        newBlock.anchoredPosition = newPosition;

        // Add the new block to the list of blocks
        ProgrammingBlockInterpreter.Blocks.Add(newBlock);
        
        
        // ajoutes les blocs à l'intrepreteur pour les lancer 
        ProgrammingBlock newBlockComponent = newGameObect.GetComponent<ProgrammingBlock>();
        if (newBlockComponent != null && interpreter != null)
        {
            interpreter.AddBlock(newBlockComponent);
        }
    }

}