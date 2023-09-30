using DiscordRPC.Logging;
using DiscordRPC;
using DiscordRpcDemo;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpotifyAPI.Web.Http;
using static System.Formats.Asn1.AsnWriter;
using System.IO;
using Swan;
using System.Net.Http;
using EmbedIO.Utilities;

namespace DiscordRPCAttempt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Toki = "";
        string Authy = "";
        string Authy2 = "";
        string Toki2 = "";
        string TokiExpiration = "";
        string TokiExpiration2 = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public DiscordRpcClient client;
        public string SpotifyRefreshToken = "";
        private string _clientId = "";
        private string _secretId = "";
        public string LyricCache = "";
        public string Lyrics2 = "";
        public string SP_DC = "";
        public async void PerformLyricShit()
        {

        }
        public async void Initialize()
        {

        }
        public async void RefreshToken() 
        {
            
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
