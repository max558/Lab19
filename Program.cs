using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_19
{
    /*
     * Модель  компьютера  характеризуется  
     *           кодом,  
     *           названием марки компьютера,  
     *           типом  процессора,  
     *           частотой  работы  процессора,  
     *           объемом оперативной памяти, 
     *           объемом жесткого диска, 
     *           объемом памяти видеокарты, 
     *           стоимостью компьютера в условных единицах и 
     *           количеством экземпляров, имеющихся в наличии. 
     *           
     * Создать список, содержащий 6-10 записей с различным набором значений характеристик. 
     * 
     * Определить:
     *     - все компьютеры с указанным процессором. Название процессора запросить у пользователя; 
     *     - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя; 
     *     - вывести весь список, отсортированный по увеличению стоимости; 
     *     - вывести весь список, сгруппированный по типу процессора; 
     *     - найти самый дорогой и самый бюджетный компьютер; 
     *     - есть ли хотя бы один компьютер в количестве не менее 30 штук?
     */
    class Program
    {
        class Computer
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public string CPU { get; set; }
            public int FrequencyCPU { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public double MemoryVideoCard { get; set; }
            public double Price { get; set; }
            public int NumberStoc { get; set; }
        }
        public static class InPutData
        {
            static public string EnterDataStr(string str)
            {
                string res = "";
                Console.Write(str);
                res = Console.ReadLine();
                return res;
            }
            static public int EnterDataInt(string str)
            {
                int res = 0;
                Console.Write(str);
                try
                {
                    res = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}", ex.Message);
                    res = EnterDataInt("Попробуйте ввсти еще раз: ");
                }
                return res;
            }
            static public double EnterDataDouble(string str)
            {
                double res = 0;
                Console.Write(str);
                try
                {
                    res = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}", ex.Message);
                    res = EnterDataDouble("Попробуйте ввсти еще раз: ");
                }
                return res;
            }
        }
        static void Main(string[] args)
        {
            List<Computer> listComp = new List<Computer>
            {
                new Computer(){Code=1, Name="ПК DEXP Aquilon O234",CPU="Intel Celeron J4005",FrequencyCPU=2000,RAM=4,HDD=120,MemoryVideoCard=0,Price=13000,NumberStoc=50},
                new Computer(){Code=2, Name="ПК DEXP Atlas H258",CPU="Intel Core i5-9400F",FrequencyCPU=2900,RAM=8,HDD=240,MemoryVideoCard=2,Price=35000,NumberStoc=15},
                new Computer(){Code=3, Name="ПК ASUS D500SA-5105000280",CPU="Intel Core i5-10500",FrequencyCPU=3100,RAM=8,HDD=256,MemoryVideoCard=2,Price=4700,NumberStoc=10},
                new Computer(){Code=4, Name="ПК ZET Gaming WARD H118",CPU="Intel Core i5-10400F",FrequencyCPU=2900,RAM=16,HDD=512,MemoryVideoCard=6,Price=107300,NumberStoc=2},
                new Computer(){Code=5, Name="ПК DEXP Atlas H294",CPU="Intel Core i3-10300",FrequencyCPU=3700,RAM=8,HDD=240,MemoryVideoCard=0,Price=28999,NumberStoc=30},
                new Computer(){Code=6, Name="ПК ASUS S300MA-310100009D",CPU="Intel Core i5",FrequencyCPU=3600,RAM=8,HDD=256,MemoryVideoCard=0,Price=34999,NumberStoc=35},
                new Computer(){Code=7, Name="ПК Dell Vostro",CPU="Intel Core i5",FrequencyCPU=2900,RAM=8,HDD=256,MemoryVideoCard=4,Price=42000,NumberStoc=25},
                new Computer(){Code=8, Name="Мини ПК MSI Cubi 5 10M-246XRU",CPU="Intel Pentium Gold",FrequencyCPU=2400,RAM=8,HDD=128,MemoryVideoCard=0,Price=27999,NumberStoc=5},
                new Computer(){Code=9, Name="ПК ASUS ExpertCenter D3 D300TA",CPU="Intel Pentium Gold",FrequencyCPU=4000,RAM=8,HDD=256,MemoryVideoCard=0,Price=35999,NumberStoc=20},
                new Computer(){Code=10, Name="ПК ZET Gaming WARD H116",CPU="Intel Core i9-11900K",FrequencyCPU=3500,RAM=32,HDD=1000,MemoryVideoCard=10,Price=349000,NumberStoc=1},
                new Computer(){Code=11, Name="ПК Lenovo IdeaCentre 3 07IMB05",CPU="Intel Core i7-10700",FrequencyCPU=2900,RAM=16,HDD=512,MemoryVideoCard=0,Price=79999,NumberStoc=10},
                new Computer(){Code=12, Name="ПК Acer Aspire XC-830",CPU="Intel Pentium Silver J5040",FrequencyCPU=2000,RAM=8,HDD=256,MemoryVideoCard=2,Price=20999,NumberStoc=35},
            };

            string nameCPU = InPutData.EnterDataStr("Введите название процессора: ");
            int ram = InPutData.EnterDataInt("Введите объем ОЗУ: ");
            int numCol = 30;
            Console.WriteLine();
            Console.WriteLine();

            /*
            #region SQL подобный список

            // все компьютеры с указанным процессором
            // В данном решении вывожу список не четкому названию процессора, а по его части (если смотреть SQL, то это подобие команды like)
            List<Computer> lsComp6 = (from lC1 in listComp
                                      where lC1.CPU.ToString().Contains(nameCPU)
                                      orderby lC1.CPU ascending
                                      select lC1)
                                    .ToList();

            // все компьютеры с объемом ОЗУ не ниже
            List<Computer> lsComp5 = (from lC1 in listComp
                                      where lC1.RAM >= ram
                                      orderby lC1.RAM ascending
                                      select lC1)
                                                .ToList();

            // Сортировка по стоимости
            List<Computer> lsComp1 = (from lC1 in listComp
                                      orderby lC1.Price ascending
                                      select lC1)
                                    .ToList();

            // Группировка
            var lsComp2 = from lC2 in listComp
                          group lC2 by lC2.CPU into newGroupList
                          orderby newGroupList.Key
                          select newGroupList;

            //Поиск дорогого и дешевого ПК

            List<Computer> lsComp3 = (from lC1 in listComp
                                      where (lC1.Price == ((from lC3 in listComp
                                                            select lC3.Price)
                                                            .Max())
                           || lC1.Price == ((from lC3 in listComp
                                             select lC3.Price)
                                                            .Min()))
                                      select lC1)
                                   .ToList();

            //Есть ли хотя бы один компьютер в количестве 
            //Если правильно понял, то вывожу список позиций, а не их кл-во
            //На поставленный вопрос есть или нет см. в выводах
            List<Computer> lsComp7 = (from lC1 in listComp
                                      where lC1.NumberStoc >= numCol
                                      orderby lC1.CPU ascending
                                      select lC1)
                        .ToList();

            #endregion
            */


            #region на основе методов расширения

            // все компьютеры с указанным процессором
            // В данном решении вывожу список не четкому названию процессора, а по его части (если смотреть SQL, то это подобие команды like)
            List<Computer> lsComp6 = listComp
                .Where(lC1 => lC1.CPU.ToString().Contains(nameCPU))
                .OrderBy(lC1 => lC1.CPU)
                .ToList();

            // все компьютеры с объемом ОЗУ не ниже            
            List<Computer> lsComp5 = listComp
                .Where(lC1 => lC1.RAM >= ram)
                 .OrderBy(lC1 => lC1.RAM)
                .ToList();

            // Сортировка по стоимости
            List<Computer> lsComp1 = listComp
                .OrderBy(lC1 => lC1.Price)
                .ToList();

            // Группировка 
            var lsComp2 = listComp
                .GroupBy(lC2 => lC2.CPU)
                .ToList();

            //Поиск дорогого и дешевого ПК
            double maxEl = listComp
                .Max(lC => lC.Price);
            double minEl = listComp
                .Min(lC => lC.Price);

            List<Computer> lsComp3 = listComp
                .Where(lC => lC.Price == listComp.Max(lC1 => lC1.Price)
                || lC.Price == listComp.Min(lC2 => lC2.Price))
                .ToList();

            //Есть ли хотя бы один компьютер в количестве 
            //Если правильно понял, то вывожу список позиций, а не их кл-во
            //На поставленный вопрос есть или нет см. в выводах
            List<Computer> lsComp7 = listComp
                .Where(lC1 => lC1.NumberStoc >= numCol)
                .OrderBy(lC1 => lC1.NumberStoc)
                .ToList();

            #endregion



            //Выводы

            // все компьютеры с указанным процессором
            Console.WriteLine("все компьютеры с процессором {0}: ", nameCPU);
            foreach (var item in lsComp6)
            {
                Console.WriteLine($"{item.Code,3} {item.Name,30} {item.CPU,25} {item.FrequencyCPU,5} {item.Price,8}");
            }
            Console.WriteLine();

            // все компьютеры с объемом ОЗУ не ниже
            Console.WriteLine("все компьютеры с объемом ОЗУ не ниже {0}:", ram);
            foreach (var item in lsComp5)
            {
                Console.WriteLine($"{item.Code,3} {item.Name,30} {item.CPU,25} {item.RAM,3} {item.Price,8}");
            }
            Console.WriteLine();

            // Сортировка по стоимости
            Console.WriteLine("Сортировка:");
            foreach (var item in lsComp1)
            {
                Console.WriteLine($"{item.Code,3} {item.Name,30} {item.Price,8} {item.NumberStoc,3}");
            }
            Console.WriteLine();

            // Группировка
            Console.WriteLine("Группировка:");
            foreach (var listItm in lsComp2)
            {
                Console.WriteLine(listItm.Key);
                foreach (var item in listItm)
                {
                    Console.WriteLine($"{item.Code,3} {item.Name,30} {item.CPU,25} {item.Price,8}");
                }
            }
            Console.WriteLine();

            //Поиск дорогого и дешевого ПК
            Console.WriteLine("Максимальное и минимальное значение:");
            foreach (var item in lsComp3)
            {
                Console.WriteLine($"{item.Code,3} {item.Name,30} {item.Price,8} {item.NumberStoc,3}");
            }
            Console.WriteLine();

            bool listCompBool = lsComp7.Any();
            Console.WriteLine("{1} компьютер(ы) в кол-ве не менее {0} шт.:", numCol, ((listCompBool) ? ("Да, есть") : ("Нет, отсутствуют")));

            foreach (var item in lsComp7)
            {
                Console.WriteLine($"{item.Code,3} {item.Name,30} {item.Price,8} {item.NumberStoc,3}");
            }

            Console.ReadKey();

        }
    }
}
