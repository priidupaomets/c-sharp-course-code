namespace Calculator
{
    public class Calculator
    {
        #region Üle laetud funktsioonid

        public int Add(int n1, int n2) { return n1 + n2; }
        public int Add(int n1, int n2, int n3) { return n1 + n2 + n3; }
        public int Add(int n1, int n2, int n3, int n4) { return n1 + n2 + n3 + n4; }

        public float Add(float n1, float n2) { return n1 + n2; }

        /// <summary>
        /// Funktsioon, mis võtab sisse suvalise arvu täisarve - seda läbi täisarvude massiivi
        /// </summary>
        /// <param name="numbrid">Täisarvude massiiv</param>
        /// <returns>Sisse tulevate numbrite summa</returns>
        public int Add(params int[] numbrid)
        {
            int summa = 0;

            foreach(var num in numbrid)
            {
                summa += num;
            }

            return summa;
        }

        #endregion

        #region Väärtus vs Referents parameetrid

        public void Add(ref int akumulaator, int n)
        {
            akumulaator += n;
        }

        public void Add(int n1, int n2, out int result)
        {
            result = n1 + n2;
        }

        #endregion

        #region Mitme tulemuse tagastamise võimalused

        /// <summary>
        /// Mitme tulemuse tagastamine väljundparameetrite kaudu
        /// </summary>
        /// <param name="numbers">Täisarvude massiiv</param>
        /// <param name="min">Miinimum väärtus või MaxInt, kui miinimumi ei leitud</param>
        /// <param name="max">Maksimum väärtus või MinInt, kui maksimumi ei leitud</param>
        /// <param name="avg">Arvude kekmine või -1, kui keskmist ei leitud</param>
        public void CalculateMinMaxAvg(int[] numbers, out int min, out int max, out int avg)
        {
            // Algväärtustame muutujad. Miinimumi jaoks võtame maksimaalse võimaliku väärtuse, maximaalse jaoks minimaalse
            min = int.MaxValue;
            max = int.MinValue;
            avg = -1;
            int sum = 0; // Lisamuutuja, summa jaoks, et me saaks arvutada keskmise

            foreach (int num in numbers)
            {
                if (num < min)
                    min = num;
                if (num > max)
                    max = num;
                sum += num;
            }

            // Arvutame keskmise
            avg = sum / numbers.Length;
        }

        /// <summary>
        /// Mitme tulemuse tagastamine objekti kaudu
        /// </summary>
        /// <param name="numbers">Täisarvude massiiv</param>
        /// <returns>Tulemuste objekt, mis sisaldab kolme väärtust</returns>
        public Arvud CalculateMinMaxAvgAsClass(params int[] numbers)
        {
            var arvud = new Arvud();

            // Algväärtustame muutujad. Miinimumi jaoks võtame maksimaalse võimaliku väärtuse, maximaalse jaoks minimaalse
            arvud.Min = int.MaxValue;
            arvud.Max = int.MinValue;
            arvud.Avg = -1;
            int sum = 0; // Lisamuutuja, summa jaoks, et me saaks arvutada keskmise

            foreach (int num in numbers)
            {
                if (num < arvud.Min)
                    arvud.Min = num;
                if (num > arvud.Max)
                    arvud.Max = num;
                sum += num;
            }

            // Arvutame keskmise
            arvud.Avg = sum / numbers.Length;

            return arvud;
        }

        /// <summary>
        /// Mitme tulemuse tagastamine Tuple kaudu
        /// </summary>
        /// <param name="numbers">Täisarvude massiiv</param>
        /// <returns></returns>
        public (int min, int max, int avg) CalculateMinMaxAvgAsTuple(params int[] numbers)
        {
            // Algväärtustame muutujad. Miinimumi jaoks võtame maksimaalse võimaliku väärtuse, maximaalse jaoks minimaalse
            int min = int.MaxValue;
            int max = int.MinValue;
            int avg = -1;
            int sum = 0; // Lisamuutuja, summa jaoks, et me saaks arvutada keskmise

            foreach (int num in numbers)
            {
                if (num < min)
                    min = num;
                if (num > max)
                    max = num;
                sum += num;
            }

            // Arvutame keskmise
            avg = sum / numbers.Length;

            // Tagastame väärtused tuple kujul
            return (min, max, avg);
        }

        #endregion
    }

    public class Arvud
    {
        public int Min;
        public int Max;
        public int Avg;
    }
}
