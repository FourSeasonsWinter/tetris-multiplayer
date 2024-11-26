using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class BlockQueue
{
    private readonly List<Type> blocks = new List<Type>
    {
        typeof(IBlock), typeof(JBlock), typeof(LBlock), typeof(TBlock),
        typeof(ZBlock), typeof(OBlock), typeof(SBlock),
    };

    private readonly Queue<Block> queue = new();
    private readonly System.Random random = new();

    public BlockQueue()
    {
        for (int i = 0; i < 5; ++i)
        {
            Block block = (Block)Activator.CreateInstance(blocks[random.Next(blocks.Count)]);
            queue.Enqueue(block);
        }
    }

    public Block GetBlock()
    {
        int index = random.Next(blocks.Count);
        Type selectedType = blocks[index];
        queue.Enqueue((Block)Activator.CreateInstance(selectedType));
        return queue.Dequeue();
    }
}
