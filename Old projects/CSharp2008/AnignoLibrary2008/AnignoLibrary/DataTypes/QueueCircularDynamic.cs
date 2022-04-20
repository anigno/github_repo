using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AnignoLibrary.DataTypes
{

    /// <summary>
    /// Queue implementation, using circular pattern over an array. Dynamically resized when needed
    /// </summary>
    public class QueueCircularDynamic<T> 
    {

		#region Fields (4) 


        private T[] mItemsArray;

        private int mHead = 0;
        private int mTail=0;
        private int mAvaliable = 0;

		#endregion Fields 

		#region Constructors (1) 

        public QueueCircularDynamic(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new InvalidOperationException(string.Format("QueueCircularDynamic for type: {0}, Initial size must be greater then zero!", typeof(T)));
            }
            mItemsArray = new T[initialSize];
        }

		#endregion Constructors 

		#region Read only Properties (1) 

        public int Avaliable
        {
            get { return mAvaliable; }
        }

		#endregion Read only Properties 

		#region Events (1) 

        public event OnQueueCircularDynamicSizeChangedDelegate OnQueueCircularDynamicSizeChanged;

		#endregion Events 

		#region Delegates (1) 

        public delegate void OnQueueCircularDynamicSizeChangedDelegate(int newSize);

		#endregion Delegates 

		#region Public Methods (4) 

        public T Dequeue()
        {
            if (mAvaliable == 0)
            {
                throw new InvalidOperationException(string.Format("QueueCircularDynamic for type: {0} is empty!", typeof(T)));
            }
            T retItem = mItemsArray[mTail++];
            if (mTail > mItemsArray.Length-1) mTail = 0;
            mAvaliable--;
            return retItem;
        }

        public T[] Dequeue(int numberOfItems)
        {
            T[] retBuffer=new T[numberOfItems];
            for (int a = 0; a < numberOfItems; a++)
            {
                retBuffer[a] = Dequeue();
            }
            return retBuffer;
        }

        public void Enqueue(T item)
        {
            if (mAvaliable + 1 > mItemsArray.Length)
            {
                //Enlarge array
                T[] tArray = mItemsArray;
                QueueCircularDynamic<T> newQueue = new QueueCircularDynamic<T>(mItemsArray.Length * 2);
                while(mAvaliable>0)
                {
                    T t = Dequeue();
                    newQueue.Enqueue(t);
                }
                mItemsArray = newQueue.mItemsArray;
                mHead = newQueue.mHead;
                mTail = newQueue.mTail;
                mAvaliable = newQueue.mAvaliable;
                //Clear old array's data
                for (int a = 0; a < tArray.Length; a++)
                {
                    tArray[a] = default(T);
                }
                if (OnQueueCircularDynamicSizeChanged != null) OnQueueCircularDynamicSizeChanged(mItemsArray.Length);
            }
            mItemsArray[mHead++]=item;
            if(mHead>mItemsArray.Length-1)mHead=0;
            mAvaliable++;
        }

        public void Enqueue(T[] items,int offset,int count)
        {
            for (int a = offset; a < offset + count; a++)
            {
                Enqueue(items[a]);
            }
        }

		#endregion Public Methods 

    }
}
