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

    private List<RectTransform> blocks;
    private RectTransform lastBlock;
    private ProgrammingBlockInterpreter interpreter;

    private void Start()
    {
        Debug.Log("BlockAligmentManager Start() called.");
        // List de position
        blocks = new List<RectTransform>();
        
        if (startBlock == null)
        {
            Debug.LogError("startBlock is null.");
            return;
        }
        blocks.Add(startBlock);
        interpreter = FindObjectOfType<ProgrammingBlockInterpreter>();

    }
    
    /*private void Awake()
    {
        blocks = new List<RectTransform>();
        if (startBlock != null)
        {
            blocks.Add(startBlock);
        }
        else
        {
            Debug.LogError("startBlock is null.");
        }

        interpreter = FindObjectOfType<ProgrammingBlockInterpreter>();
    }*/
    
    public void AddBlock(GameObject newBlockGameObject)
    {
        
        if (newBlockGameObject == null)
        {
            Debug.LogError("newBlockGameObject is null.");
            return;
        }

        if (blocks == null || blocks.Count == 0)
        {
            Debug.LogError("blocks list is null or empty.");
            return;
        }
        
        var newGameObect = newBlockGameObject;
            
        RectTransform newBlock = newGameObect.GetComponent<RectTransform>();

        lastBlock = blocks.Last();

        // Calculate the new block's position based on the last block's position and height
        Vector2 newPosition = new Vector2(
            lastBlock.anchoredPosition.x,
            lastBlock.anchoredPosition.y - lastBlock.sizeDelta.y - yOffset
        );
        
        Debug.Log(blocks.Count);

        
        // Align the new block to the calculated position
        newBlock.anchoredPosition = newPosition;

        // Add the new block to the list of blocks
        blocks.Add(newBlock);
        
        
        // ajoutes les blocs à l'intrepreteur pour les lancer 
        ProgrammingBlock newBlockComponent = newGameObect.GetComponent<ProgrammingBlock>();
        if (newBlockComponent != null && interpreter != null)
        {
            interpreter.AddBlock(newBlockComponent);
        }
    }

}