//первая

using System;
using System.Numerics;
using System.IO;

namespace Matrix
{
    /// <summary>
    /// Этот класс является контейнером для всех методов программы
    /// "Калькулятор матриц".
    /// </summary>
    class Program
    {
        private static int MaxSizeOfMatrix = 10;
        private static int MaxValueOfMatrix = 1000;
        private static int MinValueOfMatrix = -1000;
        
        /// <summary>
        /// Метод запускает все необходимые методы для работы программы:
        /// описание программы, обработку выбранной операции и реализует повтор решения.
        /// </summary>
        static void Main()
        {
            Discription();
            ConsoleKeyInfo keyToExit;
            do
            {
                while (true)
                {
                    PrintOperaionsList();
                    int operationType = GetOperationType();
                    Console.WriteLine();
                    if (Process(operationType))
                        continue;
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Для возобновления программы нажмите Enter.");
                Console.WriteLine("Для завершения программы нажмите любую клавишу...");

                keyToExit = Console.ReadKey();
                if (keyToExit.Key == ConsoleKey.Enter)
                {
                    PrintYellow("---------------------------------------------------------------------");
                }
            } while (keyToExit.Key == ConsoleKey.Enter);
        }

        /// <summary>
        /// Метод выводит на экран переданную строку зеленым цветом.
        /// </summary>
        /// <param name="s">Строка, которую нужно вывести на экран.</param>
        public static void PrintGreen(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод выводит на экран переданную строку синим цветом.
        /// </summary>
        /// <param name="s">Строка, которую нужно вывести на экран.</param>
        public static void PrintBlue(string s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод выводит на экран переданную строку красным цветом.
        /// </summary>
        /// <param name="s">Строка, которую нужно вывести на экран.</param>
        public static void PrintRed(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод выводит на экран переданную строку желтым цветом.
        /// </summary>
        /// <param name="s">Строка, которую нужно вывести на экран.</param>
        public static void PrintYellow(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод выводит на экран доступные операции программы.
        /// </summary>
        public static void PrintOperaionsList()
        {
            Console.WriteLine("1. Нахождение следа матрицы");
            Console.WriteLine("2. Транспонирование матрицы");
            Console.WriteLine("3. Сумма двух матриц");
            Console.WriteLine("4. Разность двух матриц");
            Console.WriteLine("5. Произведение двух матриц");
            Console.WriteLine("6. Умножение матрицы на число");
            Console.WriteLine("7. Нахождение определителя матрицы");
            Console.WriteLine("8. Инструкция по работе с программой");
            Console.WriteLine("9. Описание формата для txt файлов");
            Console.WriteLine();
            PrintYellow("Выберите и введите номер операции, которую хотите выполнить:");
        }

        /// <summary>
        /// Метод выводит на экран опиание программы и как с ней нужно работать.
        /// </summary>
        public static void Discription()
        {
            PrintYellow("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine(@"Программа является калькулятором матриц. Операции, которые она может выполнять:
1) Нахождение следа матриц,
2) Транспонирование матриц,
3) Сумма двух матриц,
4) Разность двух матриц,
5) Произведение двух матриц,
6) Умножение матрицы на число,
7) Нахождение определителя матрицы.

В начале программы пользователю предлагается выбрать одну из операций, а после, 
в зависимости от операции, задать одну или две матрицы. Для каждой из матриц 
пользователь задает ее размеры. После ввода размерности матрицы доступно 
3 вида ввода значений матрицы на выбор: с клавиатуры, рандомная генерация значений или 
чтение матрицы с txt файла. Ограничения по каждой размерости матрицы: [1;10], ограничения
на каждый элемент матрицы: [-1000;1000], все числа должны быть целые. Если данные вводятся 
с клавиатуры и они некорректны или не укладываются в ограничения, программа попросит 
ввести их повторно. Если данные читаются из txt файла и они некорректны или не укладываются
в ограничения, программа сообщит об этом. 
");
            PrintYellow("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        /// <summary>
        /// Метод выводит на экран описание того, как работать с программой при считывании данных из файлов.
        /// </summary>
        public static void ReadFileInfo()
        {
            PrintYellow("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine(@"Условия чтения матриц из txt файлов:

Для чтения матрицы из txt файла программа предлагает ввести абсолютный путь к файлу,
откуда необходимо считать матрицу.
Необходимый формат для чтения из txt файла: 
В файле должна быть одна матрица.
Каждое число находится на отдельной строчке без каких-либо лишних символов, кроме 
перевода строки после числа. Первые 2 числа - размеры матрицы (количество строк, 
количество столбцов). Далее идут сами значения матрицы: сначала значения первой строки матрицы 
по порядку, затем второй строки и т.д. Чисел может быть больше, чем
нужно, чтобы считать матрицу, в таком случае считаются только числа, необходимые для
заполнения матрицы указанных размеров, остальное игнорируется. Если чисел меньше, чем нужно, 
данные считаются некорректными.

Если путь некорректен, программа попросит ввести его снова. Если данные в файле не соответствуют формату, 
описанному выше, программа сообщит об этом и возобновится.
Пример корректного ввода абсолютного пути: C:\Users\User1\matrix.txt
");
            PrintYellow("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        
        /// <summary>
        /// Метод обрабатывает номер операции, который был выбран пользователем, вызывая нужный
        /// метод для каждой из операций, чтобы провести выбранную операцию.
        /// </summary>
        /// <param name="operationType">Номер операции, которую выбрал пользователь.</param>
        /// <returns>Возвращает флаг: были ли выбраны пользователем операции с номерами
        /// 8 или 9 (описание программы или описание работы с файлами)</returns>

        public static bool Process(int operationType)
        {
            bool flag = false;
            switch (operationType)
            {
                case 1:
                    CalcTraceMatrix();
                    break;
                case 2:
                    CalcTranspositionMatrix();
                    break;
                case 3:
                    CalcSumMatrix();
                    break;
                case 4:
                    CalcDifferMatrix();
                    break;
                case 5:
                    CalcProductMatrix();
                    break;
                case 6:
                    CalcProductMatrixOnNumber();
                    break;
                case 7:
                    CalcMatrixDeterminant();
                    break;
                case 8:
                    Discription();
                    flag = true;
                    break;
                case 9:
                    ReadFileInfo();
                    flag = true;
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// Метод строит матрицу по массиву чисел, считанных из файла, по
        /// формату, описанному в программе, проверяя корректность
        /// данных: размерности матрицы и ее значений.
        /// </summary>
        /// <param name="matr">Куда сохранить построенную матрицу.</param>
        /// <param name="readMatr">Массив чисел, по которому нужно построить матрицу:
        /// первые 2 числа - размерности матрицы, затем сами значения.</param>
        /// <param name="szLine">Количество строк в получившейся матрице.</param>
        /// <param name="szColumn">Количество столбцов в получившейся матрице.</param>
        public static void CheckAndReadMatrixFromFile(ref int[,] matr, ref string[] readMatr, out int szLine,
            out int szColumn)
        {
            szLine = 0;
            szColumn = 0;
            if (!int.TryParse(readMatr[0], out szLine)
                || !int.TryParse(readMatr[1], out szColumn))
            {
                matr = null;
                return;
            }

            if (szLine <= 0 || szLine > MaxSizeOfMatrix || szColumn <= 0
                || szLine > MaxSizeOfMatrix || readMatr.Length < szLine * szColumn + 2)
            {
                matr = null;
                return;
            }

            matr = new int[szLine, szColumn];
            int curIndex = 2;
            for (int i = 0; i < szLine; ++i)
            {
                for (int j = 0; j < szColumn; ++j)
                {
                    if (!int.TryParse(readMatr[curIndex], out matr[i, j]) || matr[i, j] < -1000 || matr[i, j] > 1000)
                    {
                        PrintRed("Ошибка чтения матрицы из файла. Проверьте правильность расположения файла,");
                        PrintRed("формат записи матрицы, величину элементов и размерности.");
                        matr = null;
                        return;
                    }

                    curIndex++;
                }
            }
        }

        /// <summary>
        /// Метод пытается считать матрицу из файла в массив строк, 
        /// проверяя корректность введенного пути, а также корректность 
        /// размерности и значений матрицы.
        /// </summary>
        /// <param name="matr">Куда сохранить считанную матрицу.</param>
        public static void GetMatrixFromFile(ref int[,] matr)
        {
            PrintYellow("Укажите абсолютный путь к файлу:");
            string path = Path.GetFullPath(Console.ReadLine());
            string[] readMatr;
            Console.WriteLine();
            try
            {
                while (!File.Exists(path))
                {
                    PrintRed("Путь некорректен, повторите попытку.");
                    PrintYellow("Укажите абсолютный путь к файлу:");
                    path = Path.GetFullPath(Console.ReadLine());
                }

                readMatr = File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                PrintRed("Ошибка чтения файла.");
                matr = null;
                return;
            }

            if (readMatr.Length <= 2)
            {
                PrintRed("Ошибка чтения матрицы из файла. Проверьте правильность расположения файла,");
                PrintRed("формат записи матрицы, величину элементов и размерности.");
                matr = null;
                return;
            }

            int szLine = 0;
            int szColumn = 0;

            CheckAndReadMatrixFromFile(ref matr, ref readMatr, out szLine, out szColumn);
            if (!MatrixNonExist(ref matr))
                PrintGreen("Чтение матрицы завершилось успешно.");
        }

        /// <summary>
        /// Метод осуществляет ввод размерностей матрицы от пользователя
        /// проверяет их на корректность и
        /// сохраняет их в переменных "на выход".
        /// </summary>
        /// <param name="szLine">Куда сохранить количество строк матрицы.</param>
        /// <param name="szColumn">Куда сохранить количество столбцов матрицы.</param>
        public static void AskSizesMatrix(out int szLine, out int szColumn)
        {
            PrintYellow("Задайте размеры матрицы.");
            PrintYellow("Введите количество строк матрицы:");
            while (!int.TryParse(Console.ReadLine(), out szLine) || !(szLine > 0 && szLine <= MaxSizeOfMatrix))
            {
                PrintRed("Данные некорректны, повторите попытку.");
                PrintYellow("Введите количество строк матрицы:");
            }

            PrintYellow("Введите количество столбцов матрицы:");
            while (!int.TryParse(Console.ReadLine(), out szColumn) || !(szColumn > 0 && szColumn <= MaxSizeOfMatrix))
            {
                PrintRed("Данные некорректны, повторите попытку.");
                PrintYellow("Введите количество столбцов матрицы:");
            }
        }

        /// <summary>
        /// Метод выводит на экран возможные способы ввода матрицы от пользователя и
        /// вызывает метод для обработки выбранного способа.
        /// </summary>
        /// <returns>Возвращает полученную одним из способов матрицу.</returns>
        public static int[,] MakeMatrix()
        {
            int[,] matr = null;
            Console.WriteLine();
            Console.WriteLine("Если Вы хотите сгенерировать случайную матрицу, нажмите клавишу R.");
            Console.WriteLine("Если Вы хотите ввести матрицу вручную, нажмите клавишу K.");
            Console.WriteLine(
                "Если Вы хотите считать матрицу с txt файла, нажмите клавишу F. (press F to pay respect to my program)");
            Console.WriteLine();

            ManagerInputMatrix(ref matr);

            return matr;
        }
        
        /// <summary>
        /// Метод обрабатывает выбранный пользователем способ ввода матрицы, и
        /// в зависимости от нажатой клавиши вызывает нужный метод для считывания этой матрицы.
        /// </summary>
        /// <param name="matr">Куда нужно сохранить введенную матрицу.</param>

        public static void ManagerInputMatrix(ref int[,] matr)
        {
            int szLine = 0;
            int szColumn = 0;
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.R)
                {
                    AskSizesMatrix(out szLine, out szColumn);
                    matr = GetRandomMatrix(szLine, szColumn);
                    PrintGreen("Матрица сгенерирована.");
                    break;
                }

                if (inputKey.Key == ConsoleKey.K)
                {
                    AskSizesMatrix(out szLine, out szColumn);
                    matr = GetMatrixInConsole(szLine, szColumn);
                    break;
                }

                if (inputKey.Key == ConsoleKey.F)
                {
                    GetMatrixFromFile(ref matr);
                    break;
                }
            }
        }

        
        /// <summary>
        /// Метод проверяет, что матрица существует (не null).
        /// </summary>
        /// <param name="matr">Матрица, которую нужно проверить на существование.</param>
        /// <returns>Нулевой ли указатель на матрицу.</returns>
        public static bool MatrixNonExist(ref int[,] matr)
        {
            return (matr == null);
        }

        /// <summary>
        /// Метод обрабатывает вычисление следа матрицы, вызывает нужные методы
        /// для чтения матрицы, проверки ее на корректность, а также вызывает метод
        /// для вычисления самого следа матрицы, если его возможно вычислить.
        /// </summary>
        public static void CalcTraceMatrix()
        {
            int[,] matr = MakeMatrix();
            if (MatrixNonExist(ref matr))
            {
                return;
            }

            Console.WriteLine($"Полученная матрица размера {matr.GetLength(0)}x{matr.GetLength(1)}:");
            PrintMatrix(ref matr);
            if (matr.GetLength(0) != matr.GetLength(1))
            {
                PrintRed("Невозможно вычислить след матрицы: матрица должна быть квадратной.");
                return;
            }

            PrintGreen($"След этой матрицы = {MatrixTrace(ref matr)}");
        }

        
        /// <summary>
        /// Метод выводит на экран доступные методы получения числа для умножения
        /// на него матрицы, считывает его нужным способом и проверяет на корректность.
        /// </summary>
        /// <returns>Возвращает число, введенное пользователем или случайно сгенерированное.</returns>
        public static int GetNumber()
        {
            int number = 0;
            Console.WriteLine("Необходимо задать число, на которое будет умножение матрицы.");
            Console.WriteLine("Если Вы хотите сгенерировать это число, нажмите клавишу R.");
            Console.WriteLine("Если Вы хотите ввести это число, нажмите клавишу K.");
            Console.WriteLine();
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.R)
                {
                    Random rnd = new Random();
                    number = rnd.Next(MinValueOfMatrix, MaxSizeOfMatrix + 1);
                    PrintGreen($"Число сгенерировано: {number}.");

                    break;
                }

                if (inputKey.Key == ConsoleKey.K)
                {
                    PrintYellow($"Введите число в диапазоне [{MinValueOfMatrix}, {MaxValueOfMatrix}]");
                    while (!int.TryParse(Console.ReadLine(), out number) || number < MinValueOfMatrix ||
                           number > MaxValueOfMatrix)
                    {
                        PrintRed("Введенное число некорректно, повторите попытку.");
                        PrintYellow($"Введите число в диапазоне [{MinValueOfMatrix}, {MaxValueOfMatrix}]");
                    }

                    break;
                }
            }

            return number;
        }

        /// <summary>
        /// Метод вызывает нужные методы для вычисления произведения
        /// матрицы на число: методы для ввода матрицы и числа, проверки их
        /// на корректность, вычисления произведения, а также вывода результата.
        /// </summary>
        public static void CalcProductMatrixOnNumber()
        {
            int[,] matr;
            int number = 0;
            Console.WriteLine("Необходимо задать матрицу.");
            matr = MakeMatrix();

            if (MatrixNonExist(ref matr))
            {
                return;
            }

            Console.WriteLine();
            number = GetNumber();
            Console.WriteLine();
            Console.WriteLine($"Полученная матрица размера {matr.GetLength(0)}x{matr.GetLength(1)}:");
            PrintMatrix(ref matr);
            Console.WriteLine();
            PrintGreen($"Результат умножения матрицы на число {number}:");
            matr = ProductNumberOnMatrix(ref matr, number);
            PrintMatrix(ref matr);
        }

        
        /// <summary>
        /// Метод вызывает нужные методы для вычисления произведения
        /// матрицы на матрицу: методы для ввода матриц, проверки их
        /// на корректность, вычисления произведения, а также вывода результата.
        /// </summary>
        public static void CalcProductMatrix()
        {
            int[,] matr1;
            int[,] matr2;
            Console.WriteLine("Необходимо задать 1-ю матрицу.");
            matr1 = MakeMatrix();

            if (MatrixNonExist(ref matr1))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Необходимо задать 2-ю матрицу.");
            matr2 = MakeMatrix();

            if (MatrixNonExist(ref matr2))
            {
                return;
            }

            Console.WriteLine();

            if (matr1.GetLength(1) != matr2.GetLength(0))
            {
                PrintRed("Перемножение матриц невозможно: неподходящие размерности.");
                return;
            }

            Console.WriteLine($"Полученная 1-ая матрица размера {matr1.GetLength(0)}x{matr1.GetLength(1)}:");
            PrintMatrix(ref matr1);
            Console.WriteLine($"Полученная 2-ая матрица размера {matr2.GetLength(0)}x{matr2.GetLength(1)}:");
            PrintMatrix(ref matr2);
            matr1 = ProductOfMatrix(ref matr1, ref matr2);
            PrintGreen($"Результат перемножения этих матриц: матрица размера {matr1.GetLength(0)}x{matr1.GetLength(1)}:");
            PrintMatrix(ref matr1);
        }

        /// <summary>
        /// Метод вызывает нужные методы для вычисления разницы
        /// двух матриц: методы для ввода матриц, проверки их
        /// на корректность, вычисления разности, а также вывода результата.
        /// </summary>
        public static void CalcDifferMatrix()
        {
            int[,] matr1;
            int[,] matr2;
            Console.WriteLine("Необходимо задать 1-ю матрицу.");
            matr1 = MakeMatrix();

            if (MatrixNonExist(ref matr1))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Необходимо задать 2-ю матрицу.");
            matr2 = MakeMatrix();

            if (MatrixNonExist(ref matr2))
            {
                return;
            }

            if (!(matr1.GetLength(0) == matr2.GetLength(0) &&
                  matr1.GetLength(1) == matr2.GetLength(1)))
            {
                PrintRed("Разность матриц вычислить невозможно, не совпадает размерность.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Полученная 1-я матрица размера {matr1.GetLength(0)}x{matr1.GetLength(1)}:");
            PrintMatrix(ref matr1);
            Console.WriteLine($"Полученная 2-я матрица размера {matr2.GetLength(0)}x{matr2.GetLength(1)}:");
            PrintMatrix(ref matr2);
            PrintGreen($"Результат разности этих двух матриц: матрица размера {matr1.GetLength(0)}x{matr1.GetLength(1)}");
            matr1 = DifferenceOfMatrix(ref matr1, ref matr2);
            PrintMatrix(ref matr1);
        }

        /// <summary>
        /// Метод вызывает нужные методы для вычисления суммы
        /// двух матриц: методы для ввода матриц, проверки их
        /// на корректность, вычисления суммы, а также вывода результата.
        /// </summary>
        public static void CalcSumMatrix()
        {
            int[,] matr1;
            int[,] matr2;
            Console.WriteLine("Необходимо задать 1-ю матрицу.");
            matr1 = MakeMatrix();

            if (MatrixNonExist(ref matr1))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Необходимо задать 2-ю матрицу.");
            matr2 = MakeMatrix();

            if (MatrixNonExist(ref matr2))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Полученная 1-я матрица размера {matr1.GetLength(0)}x{matr1.GetLength(1)}:");
            PrintMatrix(ref matr1);
            Console.WriteLine($"Полученная 2-я матрица размера {matr2.GetLength(0)}x{matr2.GetLength(1)}:");
            PrintMatrix(ref matr2);

            if (!(matr1.GetLength(0) == matr2.GetLength(0) &&
                  matr1.GetLength(1) == matr2.GetLength(1)))
            {
                PrintRed("Сумму матриц вычислить невозможно, не совпадает размерность.");
                return;
            }

            PrintGreen($"Результат суммы этих двух матриц: матрица размера {matr1.GetLength(0)}x{matr1.GetLength(1)}");
            matr1 = SumOfMatrix(ref matr1, ref matr2);
            PrintMatrix(ref matr1);
        }

        /// <summary>
        /// Метод определяет четность перестановки, подсчитывая количество инверсий в ней.
        /// </summary>
        /// <param name="perm">Подстановка, четность которой нужно определить.</param>
        /// <returns>Возвращает 1, если перестановка четная, и -1, если перестановка нечетная.</returns>
        public static int IsPermutationOdd(ref int[] perm)
        {
            int cntInvers = 0;
            int sz = perm.Length;
            for (int i = 0; i < sz; ++i)
            {
                for (int j = i + 1; j < sz; ++j)
                {
                    if (perm[i] > perm[j])
                    {
                        cntInvers++;
                    }
                }
            }

            if (cntInvers % 2 == 0)
            {
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// Метод вычисляет определитель квадратной матрицы. Метод генерирует все перестановки
        /// с помощью рекурсии, вызывает метод для определения четности каждой из перестановок,
        /// чтобы понять, какой знак должен быть у перестановки. Далее он берет элементы
        /// матрицы, соответствующие перестановке, перемножает их и прибавляет к определителю
        /// это произвденеие с нужным знаком.
        /// </summary>
        /// <param name="usedElems">usedElems[i] - было ли использовано число i в
        /// генерируемой перестановке.</param>
        /// <param name="matr">Матрица, определитель которой нужно вычислить.</param>
        /// <param name="perm">Текущая сгенерированная перестановка.</param>
        /// <param name="det">Текущий вычисленный определитель.</param>
        /// <param name="cntElem">Количество уже сгенерированных чисел в текущей перестановке.</param>
        public static void MatrixDeterminant(ref bool[] usedElems, ref int[,] matr, ref int[] perm, ref BigInteger det,
            int cntElem = 0)
        {
            if (cntElem == perm.Length)
            {
                BigInteger mult = 1;
                for (int i = 0; i < cntElem; ++i)
                {
                    mult = mult * matr[i, perm[i]];
                }

                det = det + mult * IsPermutationOdd(ref perm);
                return;
            }

            for (int i = 0; i < matr.GetLength(0); ++i)
            {
                if (!usedElems[i])
                {
                    usedElems[i] = true;
                    perm[cntElem] = i;
                    MatrixDeterminant(ref usedElems, ref matr, ref perm, ref det, cntElem + 1);
                    usedElems[i] = false;
                }
            }
        }
        
        /// <summary>
        /// Метод вызывает нужные методы для вычисления определителя
        /// матрицы: методы для ввода матрицы, проверки ее
        /// на корректность, вычисления определителя, а также вывода результата.
        /// </summary>
        public static void CalcMatrixDeterminant()
        {
            int[,] matr = MakeMatrix();

            if (MatrixNonExist(ref matr))
            {
                return;
            }

            Console.WriteLine($"Полученная матрица размера {matr.GetLength(0)}x{matr.GetLength(1)}:");
            PrintMatrix(ref matr);

            if (matr.GetLength(0) != matr.GetLength(1))
            {
                PrintRed("Невозможно вычислить определитель матрицы: матрица должны быть квадратной.");
                return;
            }

            int sz = matr.GetLength(0);

            int[] perm = new int[sz];
            bool[] usedElems = new bool[sz];
            BigInteger det = 0;

            MatrixDeterminant(ref usedElems, ref matr, ref perm, ref det);

            Console.WriteLine();
            PrintGreen($"Определитель этой матрицы = {det}");
        }

        /// <summary>
        /// Метод вызывает нужные методы для транспонирования
        /// исходной матрицы: методы для ввода матрицы, проверки ее
        /// на корректность, осуществления транспонирования, а также вывода результата.
        /// </summary>
        public static void CalcTranspositionMatrix()
        {
            int[,] matr;
            matr = MakeMatrix();
            if (MatrixNonExist(ref matr))
            {
                return;
            }

            Console.WriteLine($"Полученная матрица размера {matr.GetLength(0)}x{matr.GetLength(1)}:");
            PrintMatrix(ref matr);
            matr = TransposeMatrix(ref matr);
            PrintGreen($"Транспонированная матрица размера {matr.GetLength(0)}x{matr.GetLength(1)}:");
            PrintMatrix(ref matr);
        }

        
        /// <summary>
        /// Метод обрабатывает ввод номера операции, которую нужно выполнить:
        /// осуществляет ввод числа и проверяет его на корректность.
        /// </summary>
        /// <returns>Возвращает корректный номер операции.</returns>
        public static int GetOperationType()
        {
            int operationType = 0;
            while (!int.TryParse(Console.ReadLine(), out operationType) || operationType <= 0 || operationType > 9)
            {
                PrintRed("Данные некорректны, повторите попытку.");
                PrintYellow("Введите номер операции, которую Вы хотите выполнить: ");
            }

            return operationType;
        }

        /// <summary>
        /// Метод осуществляет ввод матрицы заданных размеров пользователем с консоли:
        /// предлагает ввести элементы матрицы, проверяя их на
        /// корректность.
        /// </summary>
        /// <param name="szLine">Количество строк вводимой матрицы.</param>
        /// <param name="szColumn">Количество столбцов вводимой матрицы.</param>
        /// <returns>Возвращает введенную корректную матрицу.</returns>
        public static int[,] GetMatrixInConsole(int szLine, int szColumn)
        {
            int[,] matr = new int[szLine, szColumn];
            for (int i = 0; i < szLine; ++i)
            {
                PrintYellow($"Ввод {i + 1}-ой строки матрицы:");
                for (int j = 0; j < szColumn; ++j)
                {
                    PrintBlue($"{j + 1}-ый элемент: ");
                    while (!int.TryParse(Console.ReadLine(), out matr[i, j])
                           || matr[i, j] < -1000 || matr[i, j] > 1000)
                    {
                        Console.WriteLine("Число некорректно, повторите ввод.");
                        Console.Write($"{j + 1}-ый элемент: ");
                    }
                }

                Console.WriteLine("------------------------------------------------");
            }

            return matr;
        }

        /// <summary>
        /// Метод осуществляет генерацию случайных значений элементов матрицы заданных размеров.
        /// </summary>
        /// <param name="szLine">Количество строк генерируемой матрицы.</param>
        /// <param name="szColmumn">Количество столбцов генерируемой матрицы.</param>
        /// <returns>Возвращает матрицу с рандомными значениями элементов.</returns>
        public static int[,] GetRandomMatrix(int szLine, int szColmumn)
        {
            Random rnd = new Random();
            int[,] randomMatrix = new int[szLine, szColmumn];

            for (int i = 0; i < szLine; ++i)
            {
                for (int j = 0; j < szColmumn; ++j)
                {
                    randomMatrix[i, j] = rnd.Next(MinValueOfMatrix, MaxValueOfMatrix);
                }
            }

            return randomMatrix;
        }
        
        /// <summary>
        /// Метод вычислет след матрицы.
        /// </summary>
        /// <param name="matr">Корректная квадратная матрица.</param>
        /// <returns>След заданной матрицы.</returns>
        public static int MatrixTrace(ref int[,] matr)
        {
            int summ = 0;
            for (int i = 0; i < matr.GetLength(0); ++i)
            {
                summ += matr[i, i];
            }

            return summ;
        }
        
        /// <summary>
        /// Вычисление суммы двух корректных матриц одинаковой размерности.
        /// </summary>
        /// <param name="matr1">Первая матрица для вычислеия суммы.</param>
        /// <param name="matr2">Вторая матрица для вычислеия суммы.</param>
        /// <returns>Возвращает матрицу, являющуюся суммой двух заданных матриц.</returns>
        public static int[,] SumOfMatrix(ref int[,] matr1, ref int[,] matr2)
        {
            for (int i = 0; i < matr1.GetLength(0); ++i)
            {
                for (int j = 0; j < matr1.GetLength(1); j++)
                {
                    matr1[i, j] += matr2[i, j];
                }
            }

            return matr1;
        }

        /// <summary>
        /// Вычисление разности двух корректных матриц одинаковой размерности.
        /// </summary>
        /// <param name="matr1">Первая матрица для вычислеия разности.</param>
        /// <param name="matr2">Вторая матрица для вычислеия разности.</param>
        /// <returns>Возвращает матрицу, являющуюся разностью двух заданных матриц.</returns>
        public static int[,] DifferenceOfMatrix(ref int[,] matr1, ref int[,] matr2)
        {
            for (int i = 0; i < matr1.GetLength(0); ++i)
            {
                for (int j = 0; j < matr1.GetLength(1); j++)
                {
                    matr1[i, j] -= matr2[i, j];
                }
            }

            return matr1;
        }

        /// <summary>
        /// Вычисление произведения двух корректных матриц и нужной размерности.
        /// </summary>
        /// <param name="matr1">Первая матрица для вычисления произведения.</param>
        /// <param name="matr2">Вторая матрица для вычисления произведения.</param>
        /// <returns>Возвращает матрицу, являющуюся произведением двух заданных матриц.</returns>
        public static int[,] ProductOfMatrix(ref int[,] matr1, ref int[,] matr2)
        {
            int szLine = matr1.GetLength(0);
            int szColumn = matr2.GetLength(1);
            int[,] resultMatr = new int[szLine, szColumn];
            for (int i = 0; i < szLine; ++i)
            {
                for (int j = 0; j < szColumn; ++j)
                {
                    for (int k = 0; k < matr1.GetLength(1); ++k)
                    {
                        resultMatr[i, j] += matr1[i, k] * matr2[k, j];
                    }
                }
            }

            return resultMatr;
        }

        /// <summary>
        /// Осуществляет транпонирование заданной матрицы.
        /// </summary>
        /// <param name="matr">Матрица, которую нужно транспонировать.</param>
        /// <returns>Возвращает транспонированную матрицу.</returns>
        public static int[,] TransposeMatrix(ref int[,] matr)
        {
            int szLine = matr.GetLength(1);
            int szColumn = matr.GetLength(0);
            int[,] transMatr = new int[szLine, szColumn];
            for (int i = 0; i < szLine; ++i)
            {
                for (int j = 0; j < szColumn; ++j)
                {
                    transMatr[i, j] = matr[j, i];
                }
            }

            return transMatr;
        }

        /// <summary>
        /// Вычисление произведения корректной матрицы на корректное число.
        /// </summary>
        /// <param name="matr">Матрица, которую нужно умножить на число.</param>
        /// <param name="number">Число, на которое нужно умножить матрицу.</param>
        /// <returns>Возвращает матрицу, являющуюся результатом произведения заданной матрицы на заданное число.</returns>
        public static int[,] ProductNumberOnMatrix(ref int[,] matr, int number)
        {
            for (int i = 0; i < matr.GetLength(0); ++i)
            {
                for (int j = 0; j < matr.GetLength(1); ++j)
                {
                    matr[i, j] *= number;
                }
            }

            return matr;
        }

        /// <summary>
        /// Красиво выводит заданную матрицу на экран.
        /// </summary>
        /// <param name="matr">Матрица, которую нужно вывести на экран.</param>
        public static void PrintMatrix(ref int[,] matr)
        {
            Console.WriteLine();
            int szLine = matr.GetLength(0);
            int szColumn = matr.GetLength(1);
            for (int i = 0; i < szLine; ++i)
            {
                for (int j = 0; j < szColumn; ++j)
                {
                    Console.Write("{0,9}", matr[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}