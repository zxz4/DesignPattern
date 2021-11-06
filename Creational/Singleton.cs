namespace DesignPattern.Creational
{
    /// <summary>
    /// 单例（Singleton）
    /// 确保一个类只有一个实例，并提供该实例的全局访问点
    /// 使用一个私有构造函数、一个私有静态变量以及一个公有静态函数来实现。
    /// </summary>
    public abstract class Singleton
    {
    }


    /// <summary>
    /// Ⅰ 懒汉式-线程不安全
    /// 优点:当没有使用到该类时instance被延迟实例化从而节省资源
    /// 缺点：多线程模式下不安全，当多个线程同时进入if (instance == null)时会导致多次实例化instance
    /// </summary>
    public class LazySingleton : Singleton
    {
        private static LazySingleton instance;
        private LazySingleton()
        {

        }

        public static LazySingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                }

                return instance;
            }
        }
    }

    /// <summary>
    /// Ⅱ 懒汉式（双重校验锁），线程安全
    /// </summary>
    public class LazySyncSingleton : Singleton
    {
        private static readonly object instanceLock = new();

        private static LazySyncSingleton instance;
        private LazySyncSingleton()
        {

        }

        public static LazySyncSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        //防止多个线程都进入了语句块造成多次实例化
                        if (instance == null)
                        {
                            instance = new();
                        }
                    }

                }

                return instance;
            }
        }
    }

    /// <summary>
    /// Ⅲ 饿汉式，线程安全` 
    /// 缺点：失去了延迟实例化的好处
    /// </summary>
    public class HungrySingleton : Singleton
    {
        private readonly static HungrySingleton instance = new();

        public static HungrySingleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
