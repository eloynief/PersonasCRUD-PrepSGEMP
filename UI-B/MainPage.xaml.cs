﻿namespace UI_B
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"No me tokes {count}";
            else
                CounterBtn.Text = $"NO ME TOKES {count}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
