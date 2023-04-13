using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockAligmentManager : MonoBehaviour//, IDropHandler
{
    [SerializeField] private RectTransform startBlock;
    [SerializeField] private float yOffset = 0.1f;
    [SerializeField] private float distanceThresHold = 50f;

    private List<RectTransform> blocks;
    private RectTransform lastBlock;

    private void Start()
    {
        blocks = new List<RectTransform>();
        lastBlock = startBlock;
    }

    /*public void AddBlock(GameObject newBlockGameObject)
    {
        RectTransform newBlock = newBlockGameObject.GetComponent<RectTransform>();
        // Calculate the new block's position based on the last block's position and height

        RectTransform closetBlockAbove = FindClosetBlockAbove(newBlock);

        //if (closetBlockAbove != null)
        //{
            float distance = CalculateDistance(lastBlock, newBlock);

            if (distance <= distanceThresHold)
            {
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
            }
        //}
    }*/
    
    public void AddBlock(GameObject newBlockGameObject) 
    {
    RectTransform newBlock = newBlockGameObject.GetComponent<RectTransform>();

    RectTransform closestBlockAbove = FindClosestBlockAbove(newBlock);

    if (closestBlockAbove != null)
    {
        float verticalDistance = CalculateDistance(closestBlockAbove, newBlock);

        if (verticalDistance <= distanceThresHold)
        {
            // Calculate the new block's position based on the closest block above's position and height
            Vector2 newPosition = new Vector2(
                closestBlockAbove.anchoredPosition.x,
                closestBlockAbove.anchoredPosition.y - closestBlockAbove.sizeDelta.y - yOffset
            );

            // Align the new block to the calculated position
            newBlock.anchoredPosition = newPosition;

            // Insert the new block in the list of blocks right below the closest block above
            int insertIndex = blocks.IndexOf(closestBlockAbove) + 1;
            blocks.Insert(insertIndex, newBlock);

            // Update the positions of all blocks below the inserted block
            for (int i = insertIndex + 1; i < blocks.Count; i++)
            {
                RectTransform currentBlock = blocks[i];
                RectTransform blockAbove = blocks[i - 1];

                Vector2 updatedPosition = new Vector2(
                    blockAbove.anchoredPosition.x,
                    blockAbove.anchoredPosition.y - blockAbove.sizeDelta.y - yOffset
                );

                currentBlock.anchoredPosition = updatedPosition;
            }

            return;
        }
    }

    // If there is no closest block above, or if the distance is larger than the threshold, revert to the previous behavior
    Vector2 lastBlockPosition = new Vector2(
        lastBlock.anchoredPosition.x,
        lastBlock.anchoredPosition.y - lastBlock.sizeDelta.y - yOffset
    );

    newBlock.anchoredPosition = lastBlockPosition;
    lastBlock = newBlock;
    blocks.Add(newBlock); 
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

    /*private RectTransform FindClosetBlockAbove(RectTransform newBlock)
    {
        RectTransform closestBlock = null;
        float minDistance = Mathf.Infinity;

        foreach (RectTransform block in blocks)
        {
            float distance = newBlock.anchoredPosition.y - block.anchoredPosition.y;
            if (distance > 0 && distance < minDistance)
            {
                minDistance = distance;
                closestBlock = block;
            }
        }

        return closestBlock;
    }*/

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
