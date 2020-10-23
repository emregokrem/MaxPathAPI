using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using MaxPath.Domain.Entity;
using MaxPath.Domain.Request;
using MaxPath.Infrastructure.Extensions;

namespace MatxPath.Operation.Service
{
    public class TriangleService : ITriangleService
    {
        private readonly ILoggerManager _loggerManager;
        public TriangleService(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
        public Triangle CalculateTriangle(TriangleRequest request)
        {
            _loggerManager.LogInfo("MaxPathService/CalculateTriangle is called.");

            if (request.Triangle == null)
            {
                _loggerManager.LogError("Triangle is null!");
                throw new Exception("Triangle is null!");
            }
            var triangle = new Triangle()
            {
                Tree = request.Triangle
            };

            try
            {
                _loggerManager.LogInfo("MaxPathService/CalculateTriangle/GenerateBinaryTree is called.");

                GenerateBinaryTree(triangle);
            }
            catch
            {
                _loggerManager.LogError("Error occured While Generating Binary Tree!");
                throw;
            }

            try
            {
                _loggerManager.LogInfo("MaxPathService/CalculateTriangle/DeepestPathLevel is called.");

                Node tmpNode = triangle.Head.NodeClone();
                var result = FindMaxSum(tmpNode);
                triangle.MaxPath = result.MaxPath;
                triangle.MaxSum = result.MaxSum;
                triangle.DeepestPathLevel = result.LevelOfResult;
            }
            catch
            {
                _loggerManager.LogError("Error occured While Calculating Max Path!");
                throw;
            }

            if(!triangle.IsValidPath)
                throw new Exception("Finder didn't reach to the bottom of the pyramid. The Deepest Path : " + triangle.MaxPath);

            triangle.Head = null; // to make shorter api response
            return triangle;
        }

        private static void GenerateBinaryTree(Triangle triangle)
        {
            Queue<Node> nodeQueue = new Queue<Node>();
            int currentLevel = 1;

            var splitedTriagle = triangle.Tree.Split("\n");

            foreach (var level in splitedTriagle)
            {
                var splitedLevel = level.Split(" ");

                foreach (var value in splitedLevel)
                {
                    var newNode = new Node(Convert.ToInt32(value), currentLevel);

                    if (nodeQueue.Count == 0)
                        triangle.Head = newNode;
                    else
                    {
                        var tempNode = nodeQueue.Peek();

                        if(tempNode.Level == currentLevel)
                            throw new Exception("Tree is no valid! One of Levels is long.");

                        if (tempNode.Left == null)
                            tempNode.Left = newNode;
                        else if (tempNode.Right == null)
                        {
                            tempNode.Right = newNode;
                            nodeQueue.Dequeue();
                            if (nodeQueue.Count != 0 && nodeQueue.Peek().Level == (currentLevel - 1))
                            {
                                nodeQueue.Peek().Left = newNode;
                            }
                        }
                    }

                    nodeQueue.Enqueue(newNode);
                }

                if (nodeQueue.Peek().Level == (currentLevel - 1))
                    throw new Exception("Tree is no valid! One of Levels is short.");

                triangle.Level = currentLevel++;
            }
        }

        private static FindMaxResult FindMaxSum(Node head)
        {
            if (head.Left == null)
            {
                return new FindMaxResult()
                {
                    MaxSum = head.Value,
                    MaxPath = $@"{head.Value}",
                    LevelOfResult = 1
                };
            }

            FindMaxResult left = new FindMaxResult()
            {
                MaxSum = Int32.MinValue
            };
            FindMaxResult right = new FindMaxResult()
            {
                MaxSum = Int32.MinValue
            };

            if (head.NodeType != head.Left.NodeType)
                left = FindMaxSum(head.Left);
            if (head.NodeType != head.Right.NodeType)
                right = FindMaxSum(head.Right);

            FindMaxResult maxResult = null;
            if (left.MaxSum > right.MaxSum)
                maxResult = left;
            else
                maxResult = right;

            return new FindMaxResult()
            {
                MaxSum = maxResult.MaxSum + head.Value,
                MaxPath =$@"{head.Value} -> {maxResult.MaxPath}",
                LevelOfResult = maxResult.LevelOfResult + 1
            };
        }
    }
}
