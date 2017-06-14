using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class TreeNode
    {
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public int val { get; set; }
    }

    public class BFS
    {
        private Queue _searchQueue;
        private TreeNode _root;
        public BFS(TreeNode rootNode)
        {
            _searchQueue = new Queue();
            _root = rootNode;
        }
        public bool Search(int data)
        {
            TreeNode _current = _root;
            _searchQueue.Enqueue(_root);
            try
            {
                while (_searchQueue.Count != 0)
                {
                    _current = (TreeNode)_searchQueue.Dequeue();
                    Console.Write(_current.val + " ");
                    if (_current.val == data)
                    {
                        Console.Write(" Data Found");
                        return true;
                    }
                    else
                    {
                        _searchQueue.Enqueue(_current.left);
                        _searchQueue.Enqueue(_current.right);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(" Data Not Found");
                return false;

            }
            return false;
        }

       
    }


}
