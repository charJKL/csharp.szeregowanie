using System;
using System.Collections;
using System.Collections.Generic;

namespace Szeregowanie.Utility
{
    public class PriorityQueue
    {
        int total_size;
        SortedDictionary<double, Queue> storage;

        public PriorityQueue()
        {
            this.storage = new SortedDictionary<double, Queue>();
            this.total_size = 0;
        }

        public bool IsEmpty()
        {
            return (total_size == 0);
        }

        public object Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty queue.");
            }
            else
                foreach (Queue q in storage.Values)
                {
                    if (q.Count > 0)
                    {
                        total_size--;
                        return q.Dequeue();
                    }
                }
            return null;
        }

        public object Peek()
        {
            if (IsEmpty())
                throw new Exception("Empty queue.");
            else
                foreach (Queue q in storage.Values)
                {
                    if (q.Count > 0)
                        return q.Peek();
                }
            return null;
        }

        public object Dequeue(int prio)
        {
            total_size--;
            return storage[prio].Dequeue();
        }

        public void Enqueue(object item, int prio)
        {
            var store = item as string;
            var subPrio = store.Length * 0.01;

            double priority = prio - subPrio;
            if (!storage.ContainsKey(priority))
            {
                storage.Add(priority, new Queue());
            }
            storage[priority].Enqueue(item);
            total_size++;
        }

    }
}