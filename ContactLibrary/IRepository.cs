using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получение всех объектов
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetList();

        /// <summary>
        /// Получить конкретный объект по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int? id);

        /// <summary>
        /// Добавить объект
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Изменить объект
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Save();
    }
}
