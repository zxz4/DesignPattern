namespace DesignPattern.Creational
{
    /// <summary>
    /// 工厂方法（Factory Method）
    /// 定义了一个创建对象的接口，由子类决定具体创建哪个对象。
    /// </summary>
    public abstract class FactoryMethod
    {
        public interface IProduct
        {
            void Behavior();
        }


        /// <summary>
        /// 这里使用protected来完全隐藏细节
        /// </summary>
        protected class DefaultProduct : IProduct
        {
            public void Behavior()
            {

            }
        }

        /// <summary>
        /// 实现2
        /// </summary>
        protected class SpecialProduct : IProduct
        {
            public void Behavior()
            {
            }
        }

        /// <summary>
        /// 与简单工厂不同的是，工厂方法创建对象是由具体的工厂子类实现
        /// </summary>
        /// <returns></returns>
        public abstract IProduct CreateProduct();
    }



    public class DefaultProductFactory : FactoryMethod
    {
        public override IProduct CreateProduct()
        {
            return new DefaultProduct();
        }
    }


    public class SpecialProductFactory : FactoryMethod
    {
        public override IProduct CreateProduct()
        {
            return new SpecialProduct();
        }
    }
}
