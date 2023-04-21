using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TalesofHivnir;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    public GameObject blockPrefab;
    
    private Vector3 initialPosition;
    private Transform parentTransform;
    
    [SerializeField] private RectTransform startBlock;



    public delegate void BlockDroppedHandler(GameObject block);

    public event BlockDroppedHandler OnBlockDropped;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = transform.position;
        parentTransform = transform.parent;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        //canvasGroup.alpha = .1f;
        canvasGroup.blocksRaycasts = true;
        
        OnBlockDropped?.Invoke(gameObject);
        
        GameObject newBlock = Instantiate(blockPrefab, initialPosition, Quaternion.identity, parentTransform);

        // Set the new block as draggable and usable
        DragAndDrop newBlockDragAndDrop = newBlock.GetComponent<DragAndDrop>();
        if (newBlockDragAndDrop != null)
        {
            newBlockDragAndDrop.blockPrefab = blockPrefab;
            newBlockDragAndDrop.canvas = canvas;
        }
        
        /*if (blockPrefab != null)
        {
            Instantiate(blockPrefab, transform.parent);
        }
        
        GameObject newBlock = Instantiate(blockPrefab, initialPosition, Quaternion.identity, parentTransform);
        newBlock.GetComponent<DragAndDrop>().blockPrefab = blockPrefab;
        newBlock.GetComponent<DragAndDrop>().parentTransform = parentTransform;
        
        
        /*Debug.Log("OnEndDrag");
        //canvasGroup.alpha = .1f;
        canvasGroup.blocksRaycasts = true;
    
        OnBlockDropped?.Invoke(gameObject);
    
        GameObject newBlock = Instantiate(blockPrefab, initialPosition, Quaternion.identity, parentTransform);

        // Set the new block as draggable and usable
        DragAndDrop newBlockDragAndDrop = newBlock.GetComponent<DragAndDrop>();
        if (newBlockDragAndDrop != null)
        {
            newBlockDragAndDrop.blockPrefab = blockPrefab;
            newBlockDragAndDrop.canvas = canvas;
            newBlockDragAndDrop.startBlock = startBlock;
        }
    
        // Assign objectToMove and StartBlock to the new block's ProgrammingBlock component
        ProgrammingBlock newBlockProgrammingBlock = newBlock.GetComponent<ProgrammingBlock>();
        if (newBlockProgrammingBlock != null)
        {
            newBlockProgrammingBlock.objectToMove = GetComponent<ProgrammingBlock>().objectToMove;
        }

        // Add the new block to the interpreter's block list
        ProgrammingBlockInterpreter interpreterInstance = FindObjectOfType<ProgrammingBlockInterpreter>();
        if (interpreterInstance != null)
        {
            interpreterInstance.AddBlock(newBlockProgrammingBlock);
        }*/

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        //canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    private void OnEnable()
    {
        BlockAligmentManager blockAligmentManager = FindObjectOfType<BlockAligmentManager>();
        if (blockAligmentManager != null)
        {
            OnBlockDropped += blockAligmentManager.AddBlock;
        }
    }

    private void OnDisable()
    {
        BlockAligmentManager blockAligmentManager = FindObjectOfType<BlockAligmentManager>();
        if (blockAligmentManager != null)
        {
            OnBlockDropped -= blockAligmentManager.AddBlock;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

