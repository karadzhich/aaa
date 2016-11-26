using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabWork1
{
    class Alphabet
    {
        public List<char> letters;

        public Alphabet()
        {
            this.letters = new List<char>();
        }

        /// <summary>
        /// Возвращает текущее содержание алфавита в качестве массива символов Юникода.
        /// </summary>
        public char[] Content()
        {
            return this.letters.ToArray<char>();
        }

        /// <summary>
        /// Принимает на вход символ p и возвращает статус его добавления в алфавит.
        /// </summary>
        public bool Add(char p)
        {
            if (Find(p) != true)
            {
                this.letters.Add(p);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход массив символов p и возвращает статус добавления его символов в алфавит.
        /// </summary>
        public bool Add(char[] p)
        {
            bool res = true;

            foreach (char t in p)
                if (Find(t) != true)
                {
                    this.letters.Add(t);
                }
                else
                    res = false;

            return res;
        }

        /// <summary>
        /// Принимает на вход строку p и возвращает статус добавления её символов в алфавит.
        /// </summary>
        public bool Add(string p)
        {
            bool res = true;

            foreach (char t in p)
                if (Find(t) != true)
                {
                    this.letters.Add(t);
                }
                else
                    res = false;

            return res;
        }

        /// <summary>
        /// Принимает на вход символ p и возвращает статус его удаления из алфавита.
        /// </summary>
        public bool Del(char p)
        {
            if (this.letters.Remove(p))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Очищает алфавит.
        /// </summary>
        public void Clear()
        {
            this.letters = new List<char>();
        }

        /// <summary>
        /// Принимает на вход символ p и возвращает статус его присутствия в алфавите.
        /// </summary>
        public bool Find(char p)
        {
            if (this.letters.Find(x => x == p) != default(char))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход символ p и возвращает его индекс в алфавите, если он принадлежит последнему. В противном случае, возвращает -1.
        /// </summary>
        public int Index(char p)
        {
            return this.letters.IndexOf(p);
        }
    }

    class Dictionary
    {
        public Alphabet alpha;
        public List<string> words; // as weapons :)
        public Grammar gram;

        public Dictionary()
        {
            this.alpha = new Alphabet();
            this.words = new List<string>();
            this.gram = new Grammar();
        }

        /// <summary>
        /// Возвращает текущее содержание словаря в качестве массива строк.
        /// </summary>
        public string[] Content()
        {
            return this.words.ToArray<string>();
        }

        /// <summary>
        /// Принимает на вход строку (слово) p и возвращает статус его добавления в словарь.
        /// </summary>
        public bool Add(string p)
        {
            bool f = true, h = true;

            foreach (char t in p)
                if (!this.alpha.Find(t))
                    f = false;

            h = !Find(p);

            if (f && h)
            {
                this.words.Add(p);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход массив строк (слов) p и возвращает статус их добавления в словарь.
        /// </summary>
        public bool Add(string[] p)
        {
            bool f = true, h = true, res = true;

            foreach (string s in p)
            {
                foreach (char c in s)
                    if (!this.alpha.Find(c))
                        f = false;

                h = !Find(s);

                if (f && h)
                    this.words.Add(s);
                else
                    res = false;

                f = true;
                h = true;
            }

            return res;
        }

        /// <summary>
        /// Принимает на вход строку (слово) p и возвращает статус его удаления из словаря.
        /// </summary>
        public bool Del(string p)
        {
            if (this.words.Remove(p))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Очищает словарь.
        /// </summary>
        public void Clear()
        {
            this.words = new List<string>();
        }

        /// <summary>
        /// Производит сортировку слов в словаре по алфавиту.
        /// </summary>
        public void Sort()
        {
            int m = this.words.Count;
            int[] chsm = new int[m], srts = new int[m];

            int maxorder, order = 1;

            for (int a = 1; a < this.words.Max<string>().Length; a++)
                order *= 10;

            maxorder = order;

            for (int i = 0; i < m; i++)
            {
                foreach (char c in words[i])
                {
                    chsm[i] += (this.alpha.Index(c) + 1) * order;
                    srts[i] += (this.alpha.Index(c) + 1) * order;
                    order /= 10;
                }

                order = maxorder;
            }

            Array.Sort(srts);

            List<string> newd = new List<string>();

            for (int i = 0; i < srts.Length; i++)
            {
                newd.Add(this.words[Array.IndexOf(chsm, srts[i])]);
            }

            this.words = newd;

            Console.WriteLine("Сортировка завершена.");
        }

        /// <summary>
        /// Принимает на вход строки (слова) a и b и возвращает статус их конкатенации над алфавитом и добавления в словарь.
        /// </summary>
        public bool Join(string a, string b)
        {
            bool err = true;

            foreach (char t in a)
                if (!this.alpha.Find(t))
                    err = false;

            foreach (char t in b)
                if (!this.alpha.Find(t))
                    err = false;

            if (err)
            {
                this.words.Add(a + b);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход строку (слово) p и возвращает статус присутствия в словаре.
        /// </summary>
        public bool Find(string p)
        {
            if (this.words.Find(x => x == p) != default(string))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход строку (слово) p и возвращает его индекс в словаре, если он принадлежит последнему. В противном случае, возвращает -1.
        /// </summary>
        public int Index(string p)
        {
            return this.words.IndexOf(p);
        }
    }

    class Grammar
    {
        private class Rule
        {
            public string Name; // название правила
            public string Val; // значение
            public string Cond; // условия

            public Rule(string n, string v)
            {
                this.Name = n;
                this.Val = v;
            }

            public Rule(string n, string v, string c)
            {
                this.Name = n;
                this.Val = v;
                this.Cond = c;
            }
        }

        private List<Rule> rules;
        private List<char> nms;
        private List<char> vls;

        public Grammar()
        {
            this.rules = new List<Rule>();
            this.nms = new List<char>();
            this.vls = new List<char>();
        }

        /// <summary>
        /// Принимает на вход название правила и его содержание и возвращает статус добавления правила в грамматику.
        /// </summary>
        public bool AddRule(string n, string v)
        {
            if (!FindRuleName(n) && !FindRuleVal(v) && n.Length == 1)
            {
                this.rules.Add(new Rule(n, v));
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход название правила, его содержание и условия применения и возвращает статус добавления правила в грамматику.
        /// </summary>
        public bool AddRule(string n, string v, string c)
        {
            if (!FindRuleName(n) && !FindRuleVal(v) && n.Length == 1)
            {
                this.rules.Add(new Rule(n, v, c));
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Устанавливает существование правила по его имени, передаваемому параметром p.
        /// </summary>
        public bool FindRuleName(string p)
        {
            if (this.rules.Find(x => x.Name == p) != default(Rule))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Устанавливает существование правила по его значению, передаваемому параметром p.
        /// </summary>
        public bool FindRuleVal(string p)
        {
            if (this.rules.Find(x => x.Val == p) != default(Rule))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Принимает на вход строку, содержащую общую инструкцию преобразования посредством правил и возвращает итоговое слово, если приобразование прошло успешно, и, в противном случае, и пустую строку.
        /// </summary>
        public string ConstructWord(string inp)
        {
            string res = "";
            string hh = "";

            for (int i = 0; i < inp.Length; i += 0)
            {
                try
                {
                    int inx = this.rules.FindIndex(x => x.Name == inp[i] + "");
                    hh = inx >= 0 ? this.rules[inx].Val : "";

                    if (inx < 0)
                    {
                        i++;
                        continue;
                    }

                    res += hh;
                }
                catch
                {
                    res = "";
                    break;
                }
            }

            return res;
        }
    }

    class Program
    {
        static Dictionary dict = new Dictionary();
        static string state;

        static void Main(string[] args)
        {
            state = "";

            Help();

            string cmd;

            while (true)
            {
                cmd = Console.ReadLine();

                if (cmd == "exst")
                {
                    state = "";
                    continue;
                }
                if (cmd == "crst")
                {
                    Console.WriteLine(state == "" ? "none" : state);
                    continue;
                }
                if (cmd == "exit")
                    break;
                if (cmd == "help")
                    Help();

                Controller(cmd.Split(' '));
            }
        }

        static void Help()
        {
            Console.WriteLine(
                "Синтаксис:\n\t[цель]/[действие] *[аргумент] *[аргумент], * - опциональные параметры\n\n" +
                "\tal - алфавит, dy - словарь\n\nКоманды без аргумента:\n\tal/shw - вывод всех символов алфавита;\n\tdy/shw - вывод всех слов словаря;\n\tdy/srt - сортировка слов в словаре по чек-суммам;\n\n" +
                "Команды с одним аргументом:\n\tal/add - добавление символа(-ов) в алфавит;\n\tal/del - удаление символа из алфавита;\n\tal/src - поиск символа в алфавите;\n\tal/inx - индекс символа в алфавите;\n\n" +
                "\tdy/add - добавление слова в словарь;\n\tdy/del - удаление слова из словаря;\n\tdy/src - поиск слова в словаре;\n\tdy/inx - индекс слова в словаре;\n\n" +
                "Команды с двумя аргументами:\n\tdy/jin - склеивание двух слов над алфавитом;\n\n\nhelp - вызов справки;\nexit - выход из программы;\n"
                );
        }

        static void Controller(string[] args)
        {
            bool fn = false;

            foreach (string t in new string[] { "al", "dy", "gr" })
                if (args[0] == t && state == "")
                {
                    state = args[0];
                    fn = true;
                    break;
                }

            if (!fn)
            {
                try
                {
                    switch (state + (state != "" ? "/" : "") + args[0])
                    {
                        case "al/add":
                            AddLetter(args[1]);
                            break;
                        case "al/del":
                            DelLetter(args[1]);
                            break;
                        case "al/clr":
                            ClearAlph();
                            break;
                        case "al/shw":
                            ShowLetters();
                            break;
                        case "al/src":
                            SearchLetter(args[1]);
                            break;
                        case "al/inx":
                            IndexOfLetter(args[1]);
                            break;

                        case "dy/add":
                            AddWord(args);
                            break;
                        case "dy/del":
                            DelWord(args[1]);
                            break;
                        case "dy/clr":
                            ClearDict();
                            break;
                        case "dy/shw":
                            ShowWords();
                            break;
                        case "dy/src":
                            SearchWord(args[1]);
                            break;
                        case "dy/inx":
                            IndexOfWord(args[1]);
                            break;
                        case "dy/srt":
                            SortWords();
                            break;
                        case "dy/jin":
                            JoinWords(args[1], args[2]);
                            break;

                        case "gr/add":
                            AddRl(args);
                            break;
                        case "gr/cns":
                            ConstrWord(args[1]);
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Произошла ошибка. Возможно, выбранной команде было передано неверное количество аргументов.");
                }
            }
        }

        static void AddLetter(string cmd)
        {
            if (cmd.Length == 1)
            {
                Console.WriteLine(dict.alpha.Add(cmd[0]) ? "Символ '{0}' успешно добавлен в алфавит." : "Символ '{0}' не добавлен в алфавит.", cmd);
            }
            else
            {
                Console.WriteLine(dict.alpha.Add(cmd) ? "Все символы успешно добавлены в алфавит." : "Один или несколько символов не были добавлен(-ы) в алфавит.");
            }
        }

        static void DelLetter(string cmd)
        {
            Console.WriteLine("Символ '{0}' {1}удален.", cmd, dict.alpha.Del(cmd[0]) ? "" : "не может быть ");
        }

        static void ClearAlph()
        {
            dict.alpha.Clear();

            Console.WriteLine("Алфавит очищен.");
        }

        static void ShowLetters()
        {
            foreach (char t in dict.alpha.Content())
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }

        static void SearchLetter(string cmd)
        {
            Console.WriteLine("Символ '{0}' {1}присутствует в алфавите.", cmd, dict.alpha.Find(cmd[0]) ? "" : "не ");
        }

        static void IndexOfLetter(string cmd)
        {
            int i = dict.alpha.Index(cmd[0]);

            Console.WriteLine(i == -1 ? "Символ остутствует, невозможно установить индекс." : "Индекс символа '" + cmd + "' - " + i + ".");
        }

        static void AddWord(string[] arg)
        {
            if (arg.Length == 2)
            {
                Console.WriteLine(dict.alpha.Add(arg[1]) ? "Слово '{0}' успешно добавлено в словарь." : "Слово '{0}' не добавлено в словарь.", arg[1]);
            }
            else
            {
                string[] n = new string[arg.Length - 1];

                for (int i = 1; i < arg.Length; i++)
                    n[i - 1] = arg[i];

                Console.WriteLine(dict.Add(n) ? "Все слова успешно добавлены в словарь." : "Одио или несколько слов не были добавлен(-ы) в словарь.");
            }
        }

        static void DelWord(string cmd)
        {
            Console.WriteLine("Слово '{0}' {1}удалено.", cmd, dict.Del(cmd) ? "" : "не может быть ");
        }

        static void ClearDict()
        {
            dict.Clear();

            Console.WriteLine("Словарь очищен.");
        }

        static void ShowWords()
        {
            foreach (string t in dict.Content())
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }

        static void SearchWord(string cmd)
        {
            Console.WriteLine("Слово '{0}' {1}присутствует в словаре.", cmd, dict.Find(cmd) ? "" : "не ");
        }

        static void IndexOfWord(string cmd)
        {
            int i = dict.Index(cmd);

            Console.WriteLine(i == -1 ? "Слово остутствует, невозможно установить индекс." : "Индекс слова '" + cmd + "' - " + i + ".");
        }

        static void SortWords()
        {
            dict.Sort();
            Console.WriteLine("Сортировка завершена.");
        }

        static void JoinWords(string one, string two)
        {
            Console.WriteLine(dict.Join(one, two) ? "Слова склеены. Результат: " + one + two + "." : "Слова не могут быть склеены.");
        }

        static void AddRl(string[] args)
        {
            string one = args[1];
            string two = args[2];
            string three = "";
            try
            {
                three = args[3];
            }
            catch
            {

            }

            if (three != "")
            {
                if (dict.gram.AddRule(one, two, three))
                {
                    Console.WriteLine("Правило успешно добавлено.");
                }
                else
                {
                    Console.WriteLine("Правило не было добавлено.");
                }
            }
            else
            {
                if (dict.gram.AddRule(one, two))
                {
                    Console.WriteLine("Правило успешно добавлено.");
                }
                else
                {
                    Console.WriteLine("Правило не было добавлено.");
                }
            }
        }

        static void ConstrWord(string arg)
        {
            string rs = dict.gram.ConstructWord(arg);
            if (rs != "")
            {
                dict.Add(rs);
                Console.WriteLine("Построение слова прошло успешно. Результат: '{0}' => '{1}'", arg, rs);
            }
            else
            {
                Console.WriteLine("Построение слова не удалось завершить успешно.");
            }
        }
    }
}