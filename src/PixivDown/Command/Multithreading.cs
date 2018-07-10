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
    /// 可以控制所有线程
    /// </summary>
    public class Multithreading
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

        public List<Thread> GetThreadList;

        public List<Thread> DownThreadList;

        public bool IsContinue { get; set; }

        public static object LockObjeck = new object();

        public Multithreading(int getThreadMaxCount, int downThreadMaxCount)
        {
            if (getThreadMaxCount <= 0)
                throw new Exception("获取的线程数不能小于等于0！");
            if (downThreadMaxCount <= 0)
                throw new Exception("下载的线程数不能小于等于0！");

            GetThreadMaxCount = getThreadMaxCount;
            DownThreadMaxCount = downThreadMaxCount;
            GetThreadList = new List<Thread>();
            DownThreadList = new List<Thread>();
            UnZiping = false;
            IsContinue = true;
        }

        public bool DoGetAction(object obj, Action<object> action)
        {
            lock (LockObjeck)
            {
                if (GetThreadList.Count < GetThreadMaxCount)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(action));
                    GetThreadList.Add(t);
                    t.IsBackground = true;
                    t.Name = "GThread_" + Guid.NewGuid().ToString();
                    t.Start(obj);

                    return true;
                }

                return false;
            }
            
        }

        public bool DoDownAction(object obj, Action<object> action)
        {
            lock (LockObjeck)
            {
                if (DownThreadList.Count < DownThreadMaxCount)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(action));
                    DownThreadList.Add(t);
                    t.IsBackground = true;
                    t.Name = "DThread_" + Guid.NewGuid().ToString();
                    t.Start(obj);

                    return true;
                }

                return false;
            }

        }

        public bool UnZipFile(object obj, Action<object> action)
        {
            lock (LockObjeck)
            {
                if (UnZiping)
                {
                    return false;
                }
                else
                {
                    UnZiping = true;

                    UnZipThread = new Thread(new ParameterizedThreadStart(action));
                    UnZipThread.IsBackground = true;
                    UnZipThread.Start(obj);

                    return true;
                }
            }
        }

        public void RemoveGThread()
        {
            lock (LockObjeck)
            {
                var gt = GetThreadList.Where(p => p.Name == Thread.CurrentThread.Name).FirstOrDefault();
                if (gt != null)
                {
                    GetThreadList.Remove(gt);
                }
            }
        }

        public void RemoveDThread()
        {
            lock (LockObjeck)
            {
                var gt = DownThreadList.Where(p => p.Name == Thread.CurrentThread.Name).FirstOrDefault();
                if (gt != null)
                {
                    DownThreadList.Remove(gt);
                }
            }
        }

        public void DisposeUnZipThread()
        {
            lock (LockObjeck)
            {
                UnZiping = false;
                UnZipThread.Abort();
            }
        }
    }
}