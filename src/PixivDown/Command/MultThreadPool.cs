using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Command
{
    /// <summary>
    /// 不能控制线程池的线程
    /// </summary>
    public class MultThreadPool
    {
        private int GetThreadMaxCount;

        private int DownThreadMaxCount;

        /// <summary>
        /// 是否正在解压文件
        /// </summary>
        private bool UnZiping;

        /// <summary>
        /// 解压文件的线程
        /// </summary>
        private Thread UnZipThread;

        public int GetThreadCount { get; set; }

        public int DownThreadCount { get; set; }

        public bool IsContinue { get; set; }

        public static object ObjLockExistFile = new object();

        public static object ObjLockGetThread = new object();

        public static object ObjLockDownThread = new object();

        public static object ObjLockUnZip = new object();

        public MultThreadPool(int getThreadMaxCount, int downThreadMaxCount)
        {
            if (getThreadMaxCount <= 0)
                throw new Exception("获取的线程数不能小于等于0！");
            if (downThreadMaxCount <= 0)
                throw new Exception("下载的线程数不能小于等于0！");

            GetThreadMaxCount = getThreadMaxCount;
            DownThreadMaxCount = downThreadMaxCount;
            GetThreadCount = 0;
            DownThreadCount = 0;
            UnZiping = false;
            IsContinue = true;
        }

        public bool DoGetAction(object obj, WaitCallback action)
        {
            lock (ObjLockGetThread)
            {
                if (GetThreadCount >= GetThreadMaxCount)
                {
                    return false;
                }

                ++GetThreadCount;
            }

            ThreadPool.QueueUserWorkItem(p=> 
            {
                action(p);

                RemoveGThread();
            }, obj);

            return true;
        }

        public bool DoDownAction(object obj, WaitCallback action)
        {
            lock (ObjLockDownThread)
            {
                if (DownThreadCount >= DownThreadMaxCount)
                {
                    return false;
                }

                ++DownThreadCount;
            }

            ThreadPool.QueueUserWorkItem(p =>
            {
                action(p);

                RemoveDThread();
            }, obj);

            return true;
        }

        public bool UnZipFile(object obj, WaitCallback action)
        {
            lock (ObjLockUnZip)
            {
                if (UnZiping)
                {
                    return false;
                }

                UnZiping = true;
            }

            UnZipThread = new Thread(new ParameterizedThreadStart(action));
            UnZipThread.IsBackground = true;
            UnZipThread.Start(obj);

            return true;
        }

        public void RemoveGThread()
        {
            lock (ObjLockGetThread)
            {
                --GetThreadCount;
            }
        }

        public void RemoveDThread()
        {
            lock (ObjLockDownThread)
            {
                --DownThreadCount;
            }
        }

        public void DisposeUnZipThread()
        {
            lock (ObjLockUnZip)
            {
                UnZiping = false;
            }

            UnZipThread.Abort();
        }
    }
}