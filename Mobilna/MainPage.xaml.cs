namespace Mobilna
{

    public partial class MainPage : ContentPage
    {
        private int _wynikGry = 0;

        private static readonly Random random = new Random();

        private Image[] _kostkiZdjecia;

        public MainPage()
        {
            InitializeComponent();

            _kostkiZdjecia = new[] { kostka1, kostka2, kostka3, kostka4, kostka5, kostka6 };

            ResetujWyniki();
        }

        private int LiczPunkty(int[] wynikiRzutow)
        {
            Dictionary<int, int> wystapienia = new Dictionary<int, int>();
            int sumaPunktow = 0;

            foreach (int oczko in wynikiRzutow)
            {
                if (wystapienia.ContainsKey(oczko))
                {
                    wystapienia[oczko]++;
                }
                else
                {
                    wystapienia.Add(oczko, 1);
                }
            }

            foreach (var para in wystapienia)
            {
                int oczko = para.Key;
                int ilosc = para.Value;

                if (ilosc >= 2)
                {
                    sumaPunktow += oczko * ilosc;
                }
            }
            return sumaPunktow;
        }
        private void RollButton_Clicked(object sender, EventArgs e)
        {
            const int LICZBA_KOSTEK = 5;
            int[] wynikiRzutow = new int[LICZBA_KOSTEK];

            for (int i = 0; i < LICZBA_KOSTEK; i++)
            {
                int wynik = random.Next(1, 7);
                wynikiRzutow[i] = wynik;

                _kostkiZdjecia[i].Source = $"kostka{wynik}.png";
            }

            int punktyLosowania = LiczPunkty(wynikiRzutow);
            Losowanie.Text = $"Wynik tego losowania: {punktyLosowania}";

            _wynikGry += punktyLosowania;
            WynikGry.Text = $"Wynik gry: {_wynikGry}";
        }
        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            ResetujWyniki();
        }

        private void ResetujWyniki()
        {
            foreach (var image in _kostkiZdjecia)
            {
                image.Source = "question.jpg";
            }

            _wynikGry = 0;

            Losowanie.Text = "Wynik tego losowania: 0";
            WynikGry.Text = "Wynik gry: 0";
        }
    }
}