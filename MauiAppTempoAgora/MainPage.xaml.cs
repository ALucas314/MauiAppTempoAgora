using System;
using System.Threading.Tasks;
using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        lbl_main.Text = $"☁️ {t.description}";
                        lbl_temp_max.Text = $"🌡️ Máx: {t.temp_max}°C";
                        lbl_temp_min.Text = $"🌡️ Mín: {t.temp_min}°C";
                        lbl_wind.Text = $"💨 Vento: {t.speed} m/s";
                        lbl_visibility.Text = $"👀 Visibilidade: {t.visibility} m";
                        lbl_sunrise.Text = $"🌅 Nascer: {t.sunrise}";
                        lbl_sunset.Text = $"🌇 Pôr: {t.sunset}";
                        lbl_coords.Text = $"📍 Lat: {t.lat} | Lon: {t.lon}";

                        res_frame.IsVisible = true;
                        chart_frame.IsVisible = true; // quando você adicionar gráficos
                    }
                    else
                    {
                        await DisplayAlert("Aviso", "Dados não encontrados.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Aviso", "Digite uma cidade.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}


