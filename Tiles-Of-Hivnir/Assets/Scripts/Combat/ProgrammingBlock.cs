using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir
{
    public class ProgrammingBlock : PlayerController
    {

        public string blockName; // le nom du block
        public int blockType; // le type de block
        public float blockValue; // la valeur du block genre vitesse durée etc 

        public void Execute()
        {
            switch (blockType)
            {
                case 0:
                    MoveUp();
                    // Le bloc qu'il devra call 
                    break; 
                case 1:
                    MoveDown();
                    // Le bloc qu'il devra call 
                    break;
                case 2:
                    MoveLeft();
                    // Le bloc qu'il devra call 
                    break;
                case 3:
                    MoveRigth();
                    // Le bloc qu'il devra call 
                    break;
            }
        }

        void MoveUp()
        {
            //transform.Translate(Vector2.up);
            transform.position = Vector3.up;

        }
        
        void MoveDown()
        {
            //transform.Translate(Vector2.down);
            transform.position = Vector3.down;
        }
        
        void MoveLeft()
        {
            //transform.Translate(Vector2.left);
            transform.position = Vector3.left;
        }
        
        void MoveRigth()
        {
            //transform.Translate(Vector2.right);
            transform.position = Vector3.right;
        }
    }
    
}
