namespace DesignPattern.Creational
{
    /// <summary>
    /// 简单工厂（Simple Factory）
    /// 在创建一个对象时不向客户暴露内部细节，并提供一个创建对象的通用接口。
    /// </summary>
    public class SimpleFactory
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
        /// 产品类型
        /// </summary>
        public enum ProductType
        {
            DefaultProduct,
            SpecialProduct
        }

        /// <summary>
        /// 由工厂决定具体创建哪个对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IProduct CreteProduct(ProductType type)
        {
            //这样客户端只需知道产品类型而不在需要了解具体子类的细节，从而将具体产品与客户端解耦
            switch (type)
            {
                case ProductType.SpecialProduct:
                    return new SpecialProduct();
                case ProductType.DefaultProduct:
                default:
                    return new DefaultProduct();
            }
        }
    }
}
