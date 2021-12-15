using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.DI
{
    /// <summary>
    /// Обобщенный статический ленивый строитель-хранитель, с возможностью задать простую фабрику для создания.
    /// Лениво создает и хранит заданный класс с заданным интерфейсом. Создание производится посредством заданной обобщенной фабрики.
    /// </summary>
    /// <typeparam name="I">нужный нам интерфейс</typeparam>
    /// <typeparam name="T">класс который создается внутри</typeparam>
    /// <typeparam name="SF">простая обобщенная фабрика, создающая внутри класс и "возвращающая интерфейс"</typeparam>
    public static class LazyBuilderAndHolder<I, T, SF>
        where T : class, I, new()
        where SF : ISimpleFactory<I>, new()
    {
        private static SF _simpleFactory = new SF();
        private static Lazy<I> _myObject = new Lazy<I>(() => _simpleFactory.Create() );
        public static I getInstance()
        {
            return _myObject.Value; 
        }
    }
}
