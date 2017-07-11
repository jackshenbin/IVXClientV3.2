// Define this to use simple synchronisation rather than events.
// They are about the same in terms of speed.
#define SimpleSynch

using System;
using System.IO;
using System.Threading;
using System.Linq;


namespace IVX.DataModel
{
    /// <summary>
    /// A fixed size buffer of bytes.  Both reading and writing are supported.
    /// Reading from an empty buffer will wait until data is written.  Writing to a full buffer
    /// will wait until data is read.
    /// </summary>
    public class ReadWriteQueueBuffer
    {
        #region Constructors
        /// <summary>
        /// Create a new RingBuffer with a specified size.
        /// </summary>
        /// <param name="size">The size of the ring buffer to create.</param>
        public ReadWriteQueueBuffer(int size = 0)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }
            m_queue = size >= 0 ? new System.Collections.Generic.Queue<byte>(size) : new System.Collections.Generic.Queue<byte>();
            lockObject_ = new object();

#if SimpleSynch
            waitSpan_ = TimeSpan.FromMilliseconds(1);
#else
            notEmptyEvent_ = new ManualResetEvent(false);
            notFullEvent_ = new ManualResetEvent(true);
#endif
        }
        #endregion

        /// <summary>
        /// Clear the buffer contents.
        /// </summary>
        public void Clear()
        {
            lock (lockObject_)
            {

                m_queue.Clear();
            }
#if !SimpleSynch
            notFullEvent_.Set();
            notEmptyEvent_.Reset();
#endif
        }

        /// <summary>
        /// Close the buffer for writing.
        /// </summary>
        /// <remarks>A Read when the buffer is closed and there is no data will return -1.</remarks>
        public void Close()
        {
            isClosed_ = true;
#if !SimpleSynch
            notEmptyEvent_.Set();
#endif
        }

        /// <summary>
        /// Write adds a byte to the head of the RingBuffer.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void WriteByte(byte value)
        {
            if (isClosed_)
            {
                throw new ApplicationException("Buffer is closed");
            }


            lock (lockObject_)
            {
                m_queue.Enqueue(value);
            }

        }

        /// <summary>
        /// Write adds  bytes to the head of the RingBuffer.
        /// </summary>
        /// <param name="buffer">The value to add.</param>
        /// <param name="index">index of the buffer</param>
        /// <param name="count">write count</param>
        public void Write(byte[] buffer, int index, int count)
        {
            if (isClosed_)
            {
                throw new ApplicationException("Buffer is closed");
            }

            for (int i = index; i < index+count; i++)
            {
                lock (lockObject_)
                {
                    m_queue.Enqueue(buffer[i]);
                }
            }
        }

        /// <summary>
        /// Read a byte from the buffer.
        /// </summary>
        /// <returns></returns>
        public int ReadByte()
        {
            int result = -1;
            if (isClosed_)
            {
                throw new ApplicationException("Buffer is closed");
            }
            lock (lockObject_)
            {

                result = m_queue.Dequeue();
            }
            return result;
        }

        public int Read(byte[] buffer, int index, int count)
        {
            int result = 0;
            if (isClosed_)
            {
                throw new ApplicationException("Buffer is closed");
            }
            count =  Math.Min(m_queue.Count, count);
            result = count;
            while (count > 0)
            {
                lock (lockObject_)
                {

                    buffer[index] = m_queue.Dequeue();
                }
                index++;
                count--;

            }
            return result;
        }

        #region Properties

        /// <summary>
        /// Gets a value indicating wether the buffer is empty or not.
        /// </summary>
        public bool IsEmpty
        {
            get { return m_queue.Count == 0; }
        }


        public bool IsClosed
        {
            get { return isClosed_; }
        }

        /// <summary>
        /// Gets the number of elements in the buffer.
        /// </summary>
        public int Count
        {
            get
            {
                return m_queue.Count;
            }
        }



        /// <summary>
        /// Indexer - Get an element from the tail of the RingBuffer.
        /// </summary>
        public byte this[int index]
        {
            get
            {

                if ((index < 0) || (index >= m_queue.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                byte val=0;
                lock(lockObject_)
                {
                val = m_queue.ElementAt(index);
                }
                return val;
            }
        }

        public object Tag { get; set; }

        #endregion

        #region Instance Variables
        /// <summary>
        /// Flag indicating the buffer is closed.
        /// </summary>
        bool isClosed_;


        object lockObject_;

        TimeSpan waitSpan_;

        System.Collections.Generic.Queue<byte> m_queue ;

#if !SimpleSynch
        ManualResetEvent notEmptyEvent_;
        ManualResetEvent notFullEvent_;
#endif
        #endregion
    }
}