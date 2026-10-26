using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_karpenko
{

    /// <summary>
    /// Класс для расчёта скидок в системе заказов компании «Спорт-Лайн».
    /// Компания занимается продажей спортивных товаров.
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Процент скидки для товаров, по которым не было заказов в прошлом месяце.
        /// </summary>
        public const decimal DiscountPercent = 25m;

        /// <summary>
        /// Рассчитывает цену со скидкой 25%, если по товару
        /// не было заказов в прошлом месяце.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы по товару в прошлом месяце.</param>
        /// <returns>Цена со скидкой или базовая цена, если скидка не применяется.</returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1m - DiscountPercent / 100m);
        }

        /// <summary>
        /// Возвращает текстовое описание применённой скидки для отображения в консоли.
        /// </summary>
        /// <param name="hasOrdersLastMonth">Были ли заказы по товару в прошлом месяце.</param>
        /// <returns>Строка с описанием скидки.</returns>
        public string GetDiscountDescription(bool hasOrdersLastMonth)
        {
            return hasOrdersLastMonth
                ? "Скидка не применяется (были заказы в прошлом месяце)."
                : $"Применена скидка {DiscountPercent}% (нет заказов в прошлом месяце).";
        }
    }

    /// <summary>
    /// Точка входа в консольное приложение лабораторной работы № 7.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Запускает демонстрационный расчёт цены со скидкой для компании «Спорт-Лайн».
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            var calculator = new DiscountCalculator();

            decimal price = 1000m;
            bool hasOrdersLastMonth = false;

            decimal discounted = calculator.GetDiscountedPrice(price, hasOrdersLastMonth);

            Console.WriteLine("=== Спорт-Лайн: система заказов спортивных товаров ===");
            Console.WriteLine($"Базовая цена: {price}");
            Console.WriteLine($"Цена с скидкой: {discounted}");
            Console.WriteLine(calculator.GetDiscountDescription(hasOrdersLastMonth));

            Console.WriteLine();
            Console.WriteLine("Автор: Карпенко Н.С., группа И-42");   

            Console.ReadKey();
        }
    }
}
