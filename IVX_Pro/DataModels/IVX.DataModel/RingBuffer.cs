// Define this to use simple synchronisation rather than events.
// They are about the same in terms of speed.
#define SimpleSynch

using System;
using System.IO;
using System.Threading;


namespace IVX.DataModel
{
    /// <summary>
    /// A fixed size buffer of bytes.  Both reading and writing are supported.
    /// Reading from an empty buffer will wait until data is written.  Writing to a full buffer
    /// will wait until data is read.
    /// </summary>
    public class ReadWriteRingBuffer
    {
        #region Constructors
        /// <summary>
        /// Create a new RingBuffer with a specified size.
        /// </summary>
        /// <param name="size">The size of the ring buffer to create.</param>
        public ReadWriteRingBuffer(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            array_ = new byte[size];
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
            tail_ = 0;
            head_ = 0;
            count_ = 0;

            Array.Clear(array_, 0, array_.Length);

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

#if SimpleSynch
            while (IsFull)
            {
                Thread.Sleep(waitSpan_);
            }
#else            
            notFullEvent_.WaitOne();
#endif

            lock (lockObject_)
            {
                array_[head_] = value;
                head_ = (head_ + 1) % array_.Length;

#if !SimpleSynch
                bool setEmpty = (count_ == 0);
#endif

                count_ += 1;

#if !SimpleSynch
                if (IsFull)
                {
                    notFullEvent_.Reset();
                }

                if (setEmpty)
                {
                    notEmptyEvent_.Set();
                }
#endif
            }

            bytesWritten_++;
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

            while (count > 0)
            {
#if SimpleSynch
                while (IsFull)
                {
                    Thread.Sleep(waitSpan_);
                }
#else            
                notFullEvent_.WaitOne();
#endif

                // Gauranteed to not be full at this point, however readers may sill read
                // from the buffer first.
                lock (lockObject_)
                {
                    int bytesToWrite = Length - Count;

                    if (count < bytesToWrite)
                    {
                        bytesToWrite = count;
                    }
#if !SimpleSynch
                    bool setEmpty = (count_ == 0);
#endif

                    while (bytesToWrite > 0)
                    {
                        array_[head_] = buffer[index];
                        index++;

                        head_ = (head_ + 1) % array_.Length;

                        bytesToWrite--;
                        bytesWritten_++;
                        count--;
                        count_++;
                    }

#if !SimpleSynch
                    if (IsFull)
                    {
                        notFullEvent_.Reset();
                    }

                    if (setEmpty)
                    {
                        notEmptyEvent_.Set();
                    }
#endif
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

#if SimpleSynch
            while (!isClosed_ && IsEmpty)
            {
                Thread.Sleep(waitSpan_);
            }
#else
            notEmptyEvent_.WaitOne();
#endif

            if (!IsEmpty)
            {
                lock (lockObject_)
                {
                    result = array_[tail_];
                    tail_ = (tail_ + 1) % array_.Length;
#if !SimpleSynch
                    bool setFull = IsFull;
#endif
                    count_ -= 1;
#if !SimpleSynch
                    if (!isClosed_ && (count_ == 0))
                    {
                        notEmptyEvent_.Reset();
                    }

                    if (setFull)
                    {
                        notFullEvent_.Set();
                    }
#endif
                }
            }

            bytesRead_++;

            return result;
        }

        public int Read(byte[] buffer, int index, int count)
        {
            int result = 0;

            while (count > 0)
            {
#if SimpleSynch
                while (!isClosed_ && IsEmpty)
                {
                    Thread.Sleep(waitSpan_);
                }
#else
                notEmptyEvent_.WaitOne();
#endif

                if (IsEmpty)
                {
                    count = 0;
                }
                else
                {
                    lock (lockObject_)
                    {
                        int toRead = Count;

                        if (toRead > count)
                        {
                            toRead = count;
                        }

                        result += toRead;

#if !SimpleSynch
                        bool setFull = IsFull;
#endif

                        while (toRead > 0)
                        {
                            buffer[index] = array_[tail_];
                            index++;

                            tail_ = (tail_ + 1) % array_.Length;
                            count--;
                            count_--;
                            toRead--;
                            bytesRead_++;
                        }
#if !SimpleSynch
                        if (!isClosed_ && (count_ == 0))
                        {
                            notEmptyEvent_.Reset();
                        }

                        if (setFull)
                        {
                            notFullEvent_.Set();
                        }
#endif
                    }
                }
            }

            return result;
        }

        #region Properties

        /// <summary>
        /// Gets a value indicating wether the buffer is empty or not.
        /// </summary>
        public bool IsEmpty
        {
            get { return count_ == 0; }
        }

        public bool IsFull
        {
            get
            {
                return (count_ == array_.Length);
            }
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
                return count_;
            }
        }


        public int Length
        {
            get { return array_.Length; }
        }

        public long BytesWritten
        {
            get { return bytesWritten_; }
        }

        public long BytesRead
        {
            get { return bytesRead_; }
        }

        /// <summary>
        /// Indexer - Get an element from the tail of the RingBuffer.
        /// </summary>
        public byte this[int index]
        {
            get
            {
                if ((index < 0) || (index >= array_.Length))
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return array_[(tail_ + index) % array_.Length];
            }
        }

        public object Tag { get; set; }

        #endregion

        #region Instance Variables
        /// <summary>
        /// Flag indicating the buffer is closed.
        /// </summary>
        bool isClosed_;

        /// <summary>
        /// Index for the head of the buffer.
        /// </summary>
        /// <remarks>Its the index of the next byte to be <see cref="Write">written</see>.</remarks>
        int head_;

        /// <summary>
        /// Index for the tail of the buffer.
        /// </summary>
        /// <remarks>Its the index of the next byte to be <see cref="Read">written</see>.</remarks>
        int tail_;

        /// <summary>
        /// The total number of elements added to the buffer.
        /// </summary>
        int count_;

        /// <summary>
        /// Storage for the ring buffer contents.
        /// </summary>
        byte[] array_;

        long bytesWritten_;
        long bytesRead_;

        object lockObject_;

        TimeSpan waitSpan_;

#if !SimpleSynch
        ManualResetEvent notEmptyEvent_;
        ManualResetEvent notFullEvent_;
#endif
        #endregion
    }
}