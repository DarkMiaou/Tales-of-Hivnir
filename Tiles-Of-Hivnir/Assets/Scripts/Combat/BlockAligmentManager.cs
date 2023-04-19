using System.Collections.Generic;
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
        blocks = new List<RectTransform>();
        lastBlock = startBlock;
        interpreter = FindObjectOfType<ProgrammingBlockInterpreter>();

    }
    
    public void AddBlock(GameObject newBlockGameObject)
    {
        RectTransform newBlock = newBlockGameObject.GetComponent<RectTransform>();

        RectTransform closestBlockAbove = FindClosestBlockAbove(newBlock);

        // Calculate the new block's position based on the last block's position and height
        Vector2 newPosition = new Vector2(
            lastBlock.anchoredPosition.x,
            lastBlock.anchoredPosition.y - lastBlock.sizeDelta.y - yOffset
        );

        // Align the new block to the calculated position
        newBlock.anchoredPosition = newPosition;

        // Update last block's position and height
        lastBlock = newBlock;

        // Add the new block to the list of blocks
        blocks.Add(newBlock);

        if (closestBlockAbove != null)
        {
            float distance = CalculateDistance(closestBlockAbove, newBlock);

            if (distance <= distanceThresHold)
            {
                lastBlock = closestBlockAbove;
            }
        }
        
        // Add the new block to the interpreter's block list
        ProgrammingBlock newBlockComponent = newBlockGameObject.GetComponent<ProgrammingBlock>();
        if (newBlockComponent != null && interpreter != null)
        {
            interpreter.AddBlock(newBlockComponent);
        }
    }
    
    private float CalculateDistance(RectTransform lastBlock, RectTransform newBlock)
    {
        Vector3 lastBlockBottomEdge = lastBlock.position + new Vector3(0, -lastBlock.sizeDelta.y / 2, 0);
        Vector3 newBlockTopEdge = newBlock.position + new Vector3(0, newBlock.sizeDelta.y / 2, 0);

        return Vector3.Distance(lastBlockBottomEdge, newBlockTopEdge);
    }
    
    private RectTransform FindClosestBlockAbove(RectTransform newBlock)
    {
        RectTransform closestBlock = null;
        float minDistance = Mathf.Infinity;

        foreach (RectTransform block in blocks)
        {
            float distance = newBlock.anchoredPosition.y - block.anchoredPosition.y;
            if (distance > 0 && distance < minDistance)
            {
                float horizontalDistance = Mathf.Abs(newBlock.anchoredPosition.x - block.anchoredPosition.x);
                if (horizontalDistance <= distanceThresHold)
                {
                    minDistance = distance;
                    closestBlock = block;
                }
            }
        }

        return closestBlock;
    }

    /*public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragAndDrop dragAndDrop = eventData.pointerDrag.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                RectTransform droppedBlock = eventData.pointerDrag.GetComponent<RectTransform>();
                if (droppedBlock != null)
                {
                    AddBlock(droppedBlock);
                }
            }
        }
    }*/
    
}