using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning_Experimentations
{
    internal class TreeClass
    {
        NodeClass root;

        public TreeClass(NodeClass newRoot)
        {
            root = newRoot;
        }

        public NodeClass GetRoot()
        {
            return root;
        }
    }

    internal class NodeClass
    {
        string[,] grid;
        string turn;
        int value;
        List<NodeClass> children = new List<NodeClass>();

        public NodeClass(string[,] newGrid, string newTurn)
        {
            grid = newGrid;
            turn = newTurn;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }

        public void AddChild(NodeClass child)
        {
            children.Add(child);
        }

        public List<NodeClass> GetChildren()
        {
            return children;
        }

        public string[,] GetGrid()
        {
            return grid;
        }
    }
}
