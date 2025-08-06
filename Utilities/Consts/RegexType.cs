namespace DefaultDotnetBackend.Constants
{
    public static class RegexType
    {
        /*
            TODO
            - Fungsi @ pada string untuk mengabaikan escape sequence di dalam string
            - Contoh : 
              # Path Windows: @"C:\User\Documents"
              # Regex pattern: @"\d{3}"
        */

        /*
            Makna: Satu karakter apa saja kecuali newline
            Contoh: "abc", "a7c"
            Rincian: '.' di tengah berarti karakter apa pun antara 'a' dan 'c'
        */ 
        public const string AnyOneChar = @".";

        /*
            Makna: Digit (angka 0-9)
            Contoh: "1", "9", "0"
            Rincian: Sama dengan [0-9]
        */
        public const string Digit = @"\d";

        /*
            Makna: Bukan digit
            Contoh: "a", "Z", "#"
            Rincian: Semua karakter selain angka
        */
        public const string NonDigit = @"\D";

        /*
            Makna: Word character (a-z, A-Z, 0-9, _)
            Contoh: "a", "Z", "0", "_"
            Rincian: Sama dengan [a-zA-Z0-9_]
        */
        public const string WordChar = @"\w";

        /*
            Makna: Non-word character
            Contoh: "!", " ", "#"
            Rincian: Semua karakter selain [a-zA-Z0-9_]
        */
        public const string NonWordChar = @"\W";

        /*
            Makna: Whitespace (spasi, tab, newline)
            Contoh: " ", "\t", "\n"
            Rincian: Digunakan untuk mendeteksi spasi kosong
        */
        public const string Whitespace = @"\s";

        /*
            Makna: Non-whitespace
            Contoh: "a", "1", "!"
            Rincian: Semua karakter selain whitespace
        */
        public const string NonWhitespace = @"\S";

        /*
            Makna: Awal string
            Contoh: "^abc" cocok dengan "abcde"
            Rincian: Digunakan untuk memastikan pola di awal string
        */
        public const string FirstChar = @"^";

        /*
            Makna: Akhir string
            Contoh: "abc$" cocok dengan "123abc"
            Rincian: Digunakan untuk memastikan pola di akhir string
        */
        public const string LastChar = @"$";

        /*
            Makna: Character set (salah satu karakter di dalam [])
            Contoh: [abc] cocok dengan 'a', 'b', atau 'c'
            Rincian: Sama dengan 'a' OR 'b' OR 'c'
        */
        public static string CharSet(string chars) => @$"[{chars}]";
        /*
            Makna: Negated set (karakter yang tidak di dalam [])
            Contoh: [^0-9] cocok dengan semua karakter selain angka
            Rincian: Digunakan untuk exclude karakter tertentu
        */
        public static string NegatedSet(string chars) => @$"[^({chars})]";

        /*
            Makna: Grouping
            Contoh: (abc)+ cocok dengan "abcabc"
            Rincian: Mengelompokkan subpattern
        */
        public static string Grouping(string chars) => @$"({chars})";

        /*
            Makna: OR
            Contoh: a`b cocok dengan 'a' atau 'b'
            Rincian: Digunakan untuk pilihan pola
        */
        public const string Or = @"|";

        /*
            Makna: 0 atau lebih dari karakter/pattern sebelumnya
            Contoh: ab* cocok dengan "a", "ab", "abb"
            Rincian: '*' artinya boleh tidak ada, atau banyak
        */
        public const string ZeroOrMore = @"*";

        /*
            Makna: 1 atau lebih dari karakter/pattern sebelumnya
            Contoh: ab+ cocok dengan "ab", "abb"
            Rincian: '+' artinya minimal 1 kali
        */
        public const string OneOrMore = @"+";

        /*
            Makna: 0 atau 1 dari karakter/pattern sebelumnya
            Contoh: ab? cocok dengan "a" atau "ab"
            Rincian: '?' artinya opsional
        */
        public const string ZeroOrOne = @"?";

        /*
            Makna: Tepat n kali
            Contoh: a{3} cocok dengan "aaa"
            Rincian: '{n}' artinya diulang tepat n kali
        */
        public static string ExactTimes(int manyChar) => @"{" + manyChar + @"}";

        /*
            Makna: n atau lebih kali
            Contoh: a{2,} cocok dengan "aa", "aaa", "aaaa"
            Rincian: '{n,}' artinya minimal n kali tanpa batas atas
        */
        public static string MinTimes(int manyChar) => @"{" + manyChar + @",}";

        /*
            Makna: Antara n dan m kali
            Contoh: a{2,4} cocok dengan "aa", "aaa", "aaaa"
            Rincian: '{n,m}' artinya minimal n, maksimal m kali
        */
        public static string MinMaxTimes(int manyChar, int times) => @"{" + $"{manyChar},{times}" + @"}";
    }
}
