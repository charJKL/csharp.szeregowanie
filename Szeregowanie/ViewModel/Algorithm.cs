using System;
using System.Collections.Generic;
using System.Linq;
using Szeregowanie.Model;
using Szeregowanie.Utility;

namespace Szeregowanie.ViewModel
{
    class Algorithm
    {
        private List<Result> Nodes;
        private Task[] TasksList;

        public Algorithm(List<TaskWrapper> tasksList)
        {
            Nodes = new List<Result>();
            TasksList = new Task[tasksList.Count];
            for (var j = 0; j < tasksList.Count; ++j)
            {
                TasksList[j] = new Task()
                {
                    id = tasksList[j].Number,
                    first = tasksList[j].Time[0],
                    second = tasksList[j].Time[1]
                };
            }   
        }

        public int[] FindSolution()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Enqueue("", 0);
            int taskCount = TasksList.Count();

            string rawResult;
            string[] stringResult;
            int[] thisResult = new int[0];
            int[] remainingTasks;
            while (!queue.IsEmpty())
            {
                stringResult = new string[0];
                rawResult = queue.Dequeue().ToString();
                if (rawResult != "")
                    stringResult = rawResult.Split('.');

                #region thisResult - Already order task. Convert from string "1" to int 1

                thisResult = new int[stringResult.Count()];
                for (var j = 0; j < stringResult.Count(); ++j)
                    thisResult[j] = int.Parse(stringResult[j]);

                #endregion

                #region remainingTasks - Find which tasks remaining to procced - as index of task
                remainingTasks = new int[taskCount - thisResult.Count()];
                var x = 0;
                for (var j = 0; j < TasksList.Count(); ++j)
                {
                    bool isRemaining = true;
                    for (var k = 0; k < thisResult.Count(); ++k)
                        if (TasksList[j].id == thisResult[k])
                        {
                            isRemaining = false;
                            break;
                        }
                    if (isRemaining)
                        remainingTasks[x++] = j;
                }
                #endregion

                if (remainingTasks.Count() == 0)
                    break;

                string subResult = "";
                int[] subRemainingTasks = new int[remainingTasks.Count() - 1];
                int lbc = int.MaxValue;
                int lbc_1 = 0;
                int lbc_2 = 0;
                int lbc_1_min = int.MaxValue;
                for (var j = 0; j < remainingTasks.Count(); ++j)
                {
                    if (rawResult != "")
                        subResult = rawResult + "." + TasksList[remainingTasks[j]].id.ToString();
                    else
                        subResult = TasksList[remainingTasks[j]].id.ToString();

                    #region subRemainingTasks - RemainingTasks after pass one to machines
                    var y = 0;
                    for (var k = 0; k < remainingTasks.Count(); ++k)
                    {
                        if (remainingTasks[k] != remainingTasks[j])
                        {
                            subRemainingTasks[y++] = remainingTasks[k];
                        }
                    }
                    #endregion

                    #region lbc - count lbc value
                    lbc = int.MaxValue;

                    #region lbc_1 - first part
                    lbc_1 = 0;

                    //what is on machine
                    for (var k = 0; k < thisResult.Count(); ++k)
                    {
                        for (var l = 0; l < TasksList.Count(); ++l)
                        {
                            if (TasksList[l].id == thisResult[k])
                            {
                                lbc_1 += TasksList[l].first;
                                break;
                            }
                        }
                    }
                    lbc_1 += TasksList[remainingTasks[j]].first;

                    //remaining taks
                    for (var k = 0; k < subRemainingTasks.Count(); ++k)
                    {
                        lbc_1 += TasksList[subRemainingTasks[k]].first;
                    }

                    //minimal value from remaining second
                    lbc_1_min = int.MaxValue;
                    for (var k = 0; k < subRemainingTasks.Count(); ++k)
                    {
                        if (TasksList[subRemainingTasks[k]].second < lbc_1_min)
                            lbc_1_min = TasksList[subRemainingTasks[k]].second;
                    }
                    lbc_1 += lbc_1_min;
                    #endregion

                    #region lbc_2 - second part
                    lbc_2 = 0;

                    //take offset from first machine
                    int machine_1 = 0;
                    int machine_2 = 0;
                    for (var k = 0; k < thisResult.Count(); ++k)
                    {
                        for (var l = 0; l < TasksList.Count(); ++l)
                        {
                            if (TasksList[l].id == thisResult[k])
                            {
                                machine_1 += TasksList[l].first;
                                if (machine_1 > machine_2)//czekam
                                    machine_2 += machine_1 - machine_2;
                                machine_2 += TasksList[l].second;
                                break;
                            }
                        }
                    }

                    machine_1 += TasksList[remainingTasks[j]].first;
                    var start = Math.Max(machine_1, machine_2);

                    lbc_2 = start + TasksList[remainingTasks[j]].second;

                    //remaining taks
                    for (var k = 0; k < subRemainingTasks.Count(); ++k)
                    {
                        lbc_2 += TasksList[subRemainingTasks[k]].second;
                    }

                    #endregion


                    lbc = Math.Max(lbc_1, lbc_2);
                    #endregion

                    queue.Enqueue(subResult, lbc);
                    Nodes.Add(new Result() { result = subResult, lbc = lbc });
                }
            }//end queue
            return thisResult;
        }//end run

        public List<Result> GetNodes()
        {
            return Nodes;
        }

    }
}

