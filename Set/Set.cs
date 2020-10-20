using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Set
{
    /// <summary>
    /// Множество.
    /// </summary>
    /// <typeparam name="T"> Тип данных, хранимых во множестве. </typeparam>
    class Set<T> : IEnumerable
    {
        /// <summary>
        /// Коллекция хранимых данных.
        /// </summary>
        private List<T> items = new List<T>();

        /// <summary>
        /// Количество элементов.
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Set() {  }

        /// <summary>
        /// Конструктор с добавлением одного элемента в множество
        /// </summary>
        /// <param name="item"> Добавляемый элемент </param>
        public Set(T item)
        {
            items.Add(item);
        }

        ///// <summary>
        ///// Конструктор с добавлением массива элементов в множество
        ///// </summary>
        ///// <param name="items"> Массив элементов</param>
        //public Set(T[] items)
        //{
        //    // Перебираем все элементы массива и заносим в множество
        //    foreach (T item in items)
        //    {
        //        this.items.Add(item);
        //    }
        //}

        /// <summary>
        /// Конструктор с добавлением элементов в множество с помощью перебора коллекции
        /// </summary>
        /// <param name="items"> Коллекция элементов </param>
        public Set(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        /// <summary>
        /// Операция добавления элемента в множество
        /// </summary>
        /// <param name="item"> Добавляемый элемент </param>
        public void Add(T item)
        {
            //// Проверяем есть ли такой элемент в нашем множестве
            //foreach (var i in items)
            //{
            //    // Если есть, прерываем
            //    if (i.Equals(item))
            //    {
            //        return;
            //    }
            //}
            if (Count >= 2000)
            {
                throw new Exception("Слишком много элементов добавлено в множество, по заданию 2000 - максимум (хотя можно было и больше :) )");
            }
            // Проверяем есть ли такой элемент в нашем множестве
            if (items.Contains(item))
            {
                // Если есть, прерываем
                return;
            }
            // Если нет, добавляем
            items.Add(item);
        }

        /// <summary>
        /// Операция удаления элемента из множества
        /// </summary>
        /// <param name="item"> Удаляемый элемент </param>
        public void Remove(T item)
        {
            items.Remove(item);
        }

        /// <summary>
        /// Операция объединения двух множеств
        /// </summary>
        /// <param name="set"> Второе множество </param>
        /// <returns> Результат </returns>
        public Set<T> Union (Set<T> set)
        {
            // Результирующее множество
            Set<T> result = new Set<T>();

            // Добавляем все элементы из первого множества в результирующее
            foreach (T item in items)
            {
                result.Add(item);
            }
            // Добавляем все элементы из второго множества в результирующее
            foreach (T item in set.items)
            {
                result.Add(item);
            }
            // Возвращаем результирующее множество
            return result;
        }

        /// <summary>
        /// Операция пересечения множеств
        /// </summary>
        /// <param name="set"> Второе множество </param>
        /// <returns> Результат </returns>
        public Set<T> Intersection (Set<T> set)
        {
            // Результирующее множество
            Set<T> result = new Set<T>();
            // Большее множество
            Set<T> big = new Set<T>();
            // Меньшее множество
            Set<T> small = new Set<T>();

            // Узнаем какое множество больше
            if (Count > set.Count)
            {
                big = this;
                small = set;
            }
            else
            {
                big = set;
                small = this;
            }
            // Берем элемент из большего множества
            foreach (T item1 in small.items)
            {
                // Берем элементы из меньшего множества
                foreach (T item2 in big.items)
                {
                    // Сравниваем все элементы меньшего с элементом большего
                    if (item1.Equals(item2))
                    {
                        // Если совпали, добавляем в результирующее множество
                        result.Add(item1);
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Операция разности двух множеств
        /// </summary>
        /// <param name="set"> Второе множество </param>
        /// <returns> Результат </returns>
        public Set<T> Difference(Set<T> set)
        {
            // Результирующее множество
            Set<T> result = new Set<T>(items);
            //Set<T> result = new Set<T>();
            //// Создаем копию первого множества
            //foreach (T item in items)
            //{
            //    result.Add(item);   
            //}

            //Берем все элементы из второго множества
            foreach (T item in set.items)
            {
                // Удаляем эти элементы из первого множества
                result.Remove(item);
            }

            return result;
        }

        /// <summary>
        /// Операция проверки на подмножество
        /// </summary>
        /// <param name="set"> Подмножество </param>
        /// <returns> Является? </returns>
        public bool SubSet(Set<T> set)
        {
            // Берем элемент множества
            foreach (T item1 in set.items)
            {
                bool equals = false;
                // Берем все элементы множества
                foreach (T item2 in items)
                {
                    // Если эл-т подмножества совпал хотя бы с одним эл-том множества
                    if (item1.Equals(item2))
                    {
                        // Закончить проверку
                        equals = true;
                        break;
                    }

                }
                // Если эл-т подмножества не совпал ни с одним эл-том множества
                if (!equals)
                {
                    // Вернуть false
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Операция симетричной разности двух множеств
        /// </summary>
        /// <param name="set"> Второе множество </param>
        /// <returns> Результируещее множество </returns>
        public Set<T> SymmetricDifference(Set<T> set)
        {
            return this.Difference(set).Union(set.Difference(this));
        }

        // Реализация GetEnumerator из интерфейса IEnumerator
        // Для возможности вызова foreach
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
