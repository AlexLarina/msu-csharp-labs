using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackList<T>
    {
        private Node<T> _first, _last;

        public void Push(T data)
        {
            Node<T> temp = new Node<T>(data);
            if (_last == null)
            {
                _last = temp;
                _first = temp;
            }
            else
            {
                _last.Next = temp;
                _last = _last.Next;
            }
        }


        public T Top()
        {
            if (_first == null) return default(T);
            else
            {

            }
        }

        public T Pop()
        {
            if (_first == null) return default(T);
            else
            {
                Node<T> previous = _first;
                Node<T> current = _first.Next;
                //движение по стеку
                while (current != null)
                {
                    previous = current;
                    current = current.Next;
                }
                _last = previous;
                current = previous.Next;
               // return ;
                /*if (_last == null)
                {
                    _last = previous;                    
                }*/

            }
        }


        public int Count
        {
            get
            {
                int result = 0;
                Node<T> node = _first;
                while (node != null)
                {
                    node = node.Next;
                    ++result;
                }

                return result;
            }
        }

        public void Print()
        {
            Node<T> temp = _first;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        private class Node<TElement>
        {
            public Node(TElement data, Node<TElement> next = null)
            {
                Data = data;
                Next = next;
            }
            public TElement Data { get; set; }
            public Node<TElement> Next { get; set; }
        }

    }
}
