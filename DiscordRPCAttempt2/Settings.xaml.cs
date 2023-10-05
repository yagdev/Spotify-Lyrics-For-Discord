using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Windows.Forms;
using System.Drawing;
using DiscordRPC;
using System.Threading;
using DiscordRpcDemo;
using DiscordRPC.Logging;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web;
using System.Net.Http;
using System.Diagnostics;
using System.Security.Policy;
using System.Reflection.Emit;
using SpotifyAPI.Web.Http;
using System.Net;

namespace DiscordRPCAttempt2
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        string Toki = "";
        string TokiRefresh = "";
        string DiscordID = "";
        string Authy = "";
        string Authy2 = "";
        string Toki2 = "";
        string TokiExpiration = "";
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public DiscordRpcClient client;
        string _clientId = "";
        string _secretId = "";
        string LyricCache = "";
        string Lyrics2 = "";
        public string SP_DC = "";
        int startshit = 0;
        string filelocation = "AppID.txt";
        string filelocation2 = "SecretID.txt";
        string filelocation3 = "ClientID.txt";
        string filelocation4 = "SPDC.txt";
        string Title = "";
        string Title2 = "";
        string AlbumName = "";
        string TimestampNewAlgo = "";
        string SongTitleReloadedAlgo = "";
        string AlbumCoverBase = "";
        string AlbumCoverBase2 = "";
        string Lyrics = "";
        string SongID = "";
        string SongIDCache = "";
        string timestamp = "";
        string code = "";
        int albumline = 0;
        int ExpiresInMs = 0;
        int CalcTimeInt = 0;
        Uri BaseUri = new Uri("http://localhost:5543/callback");
        SocketsHttpHandler handler = new SocketsHttpHandler();
        HttpClient client2 = new HttpClient(new SocketsHttpHandler { ConnectTimeout = TimeSpan.FromSeconds(5), EnableMultipleHttp2Connections = false });
        SpotifyAPI.Web.PlayerCurrentlyPlayingRequest request2 = new SpotifyAPI.Web.PlayerCurrentlyPlayingRequest();

        public Settings()
        {
            InitializeComponent();
            if (File.Exists(filelocation))
            {
                AppID.Text = File.ReadAllText(filelocation);
            }
            if (File.Exists(filelocation2))
            {
                ClientSecret.Text = File.ReadAllText(filelocation2);
            }
            if (File.Exists(filelocation3))
            {
                ClientID.Text = File.ReadAllText(filelocation3);
            }
            if (File.Exists(filelocation4))
            {
                SPDC.Text = File.ReadAllText(filelocation4);
            }
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("icon.ico");
            ni.Visible = true;
            ni.DoubleClick += delegate (object sender, EventArgs args)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };
            Thread thread2 = new Thread(UpdateCheck);
            thread2.Start();
        }
        public async void PerformLyricShit()
        {
            //client2.Dispose();
            try
            {
                if (startshit == 1)
                {
                    var spotify = new SpotifyClient(Toki);
                    var track = spotify.Player.GetCurrentlyPlaying(request2);
                    try
                    {
                        try
                        {
                            var url = "https://api.spotify.com/v1/me/player/currently-playing";
                            client2.DefaultRequestHeaders.Clear();
                            client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + Toki);
                            var response = client2.GetStringAsync(url);
                            try
                            {
                                Title = response.Result.ToString();
                                AlbumCoverBase = Title;
                                TimestampNewAlgo = Title;
                                var reader = new StringReader(Title);
                            start:
                                Title2 = reader.ReadLine();
                                if (Title2.Contains("https://api.spotify.com/v1/tracks/"))
                                {
                                    Title2 = reader.ReadLine();
                                    Title2 = Title2.Remove(0, 12);
                                    Title2 = Title2.Remove(22, 2);
                                    SongID = Title2;
                                    SongTitleReloadedAlgo = reader.ReadLine();
                                    SongTitleReloadedAlgo = reader.ReadLine();
                                    reader.Close();
                                    SongTitleReloadedAlgo = SongTitleReloadedAlgo.Remove(0, 14);
                                    SongTitleReloadedAlgo = SongTitleReloadedAlgo.Remove(SongTitleReloadedAlgo.Length - 2, 2);
                                    if (SongID == SongIDCache)
                                    {
                                        try
                                        {
                                            timestamp = "";
                                            var reader2 = new StringReader(Lyrics);
                                        startchicanery:
                                            Lyrics2 = reader2.ReadLine();
                                            if (Lyrics2.Contains("startTimeMs"))
                                            {
                                                    
                                                Lyrics2 = Lyrics2.Remove(0, 15);
                                                Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                string TimestampNewAlgo2 = "";
                                                var reader4 = new StringReader(TimestampNewAlgo);
                                                TimestampNewAlgo2 = reader4.ReadLine();
                                            startchicanerynewprogressalgo:
                                                if (TimestampNewAlgo2.Contains("progress_ms"))
                                                {
                                                    reader4.Close();
                                                    TimestampNewAlgo2 = TimestampNewAlgo2.Remove(0, 18);
                                                    TimestampNewAlgo2 = TimestampNewAlgo2.Remove(TimestampNewAlgo2.Length - 1, 1);
                                                    timestamp = TimestampNewAlgo2;
                                                }
                                                else
                                                {
                                                    TimestampNewAlgo2 = reader4.ReadLine();
                                                    goto startchicanerynewprogressalgo;
                                                }

                                                int lyrictimestamp = int.Parse(Lyrics2);
                                                int currenttimestamp = int.Parse(timestamp);
                                                Lyrics2 = reader2.ReadLine();
                                                Lyrics2 = Lyrics2.Remove(0, 9);
                                                Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);

                                            startchicanery2:
                                                if (lyrictimestamp < currenttimestamp)
                                                {
                                                    Lyrics2 = Lyrics2.Replace("\\u0027", "'");
                                                    Lyrics2 = Lyrics2.Replace("\\\"", "\"");
                                                    LyricCache = Lyrics2;
                                                    Lyrics2 = reader2.ReadLine();
                                                    goto startchicanery;
                                                }
                                            }
                                            else
                                            {
                                                goto startchicanery;
                                            }
                                            reader2.Close();
                                        }
                                        catch (Exception)
                                        {
                                            LyricCache = "";
                                        }
                                    }
                                    else
                                    {
                                        if (!Title.Contains("\"progress_ms\" : 0"))
                                        {
                                            try
                                            {
                                                var url2 = "https://spclient.wg.spotify.com/color-lyrics/v2/track/" + Title2;
                                                client2.DefaultRequestHeaders.Clear();
                                                client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + Toki2);
                                                client2.DefaultRequestHeaders.Add("accept", "application/json");
                                                client2.DefaultRequestHeaders.Add("app-platform", "Win32");
                                                var response2 = client2.GetStringAsync(url2);
                                                Lyrics = response2.Result.ToString();
                                                timestamp = "";
                                                Lyrics = Lyrics.Replace("},", "\n},\n");
                                                Lyrics = Lyrics.Replace("\",", "\",\n");
                                                Lyrics = Lyrics.Replace("{", "{\n");
                                                var reader2 = new StringReader(Lyrics);
                                                Lyrics2 = reader2.ReadLine();
                                            startchicanery:
                                                if (Lyrics2.Contains("startTimeMs"))
                                                {
                                                    Lyrics2 = Lyrics2.Remove(0, 15);
                                                    Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                    string TimestampNewAlgo2 = "";
                                                    var reader4 = new StringReader(TimestampNewAlgo);
                                                    TimestampNewAlgo2 = reader4.ReadLine();
                                                startchicanerynewprogressalgo:
                                                    if (TimestampNewAlgo2.Contains("progress_ms"))
                                                    {
                                                        TimestampNewAlgo2 = TimestampNewAlgo2.Remove(0, 18);
                                                        TimestampNewAlgo2 = TimestampNewAlgo2.Remove(TimestampNewAlgo2.Length - 1, 1);
                                                        timestamp = TimestampNewAlgo2;
                                                        reader4.Close();
                                                    }
                                                    else
                                                    {
                                                        TimestampNewAlgo2 = reader4.ReadLine();
                                                        goto startchicanerynewprogressalgo;
                                                    }

                                                    int lyrictimestamp = int.Parse(Lyrics2);
                                                    int currenttimestamp = int.Parse(timestamp);
                                                    Lyrics2 = reader2.ReadLine();
                                                    Lyrics2 = Lyrics2.Remove(0, 9);
                                                    Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                    SongIDCache = SongID;
                                                startchicanery2:
                                                    if (lyrictimestamp < currenttimestamp)
                                                    {
                                                        Lyrics2 = Lyrics2.Replace("\\u0027", "'");
                                                        Lyrics2 = Lyrics2.Replace("\\\"", "\"");
                                                        LyricCache = Lyrics2;
                                                        Lyrics2 = reader2.ReadLine();
                                                        goto startchicanery;
                                                    }
                                                    else
                                                    {
                                                        reader2.Close();
                                                    }
                                                }
                                                else
                                                {
                                                    if (Lyrics2 != "")
                                                    {
                                                        Lyrics2 = reader2.ReadLine();
                                                        goto startchicanery;
                                                    }
                                                }
                                            }
                                            catch (Exception nn)
                                            {
                                                nn.Data.Clear();
                                                LyricCache = "";
                                            }
                                        }
                                    }
                                    try
                                    {
                                        AlbumCoverBase = AlbumCoverBase.Replace("{", "");
                                        var reader3 = new StringReader(AlbumCoverBase);
                                        AlbumCoverBase2 = reader3.ReadLine();
                                    albumchicanery:
                                        albumline = albumline + 1;
                                        if (AlbumCoverBase2.Contains("https://api.spotify.com/v1/albums/") & albumline > 20)
                                        {
                                            AlbumCoverBase2 = reader3.ReadLine();
                                            AlbumCoverBase2 = reader3.ReadLine();
                                            AlbumCoverBase2 = reader3.ReadLine();
                                            AlbumCoverBase2 = reader3.ReadLine();
                                            AlbumCoverBase2 = AlbumCoverBase2.Remove(0, 17);
                                            AlbumCoverBase2 = AlbumCoverBase2.Remove(AlbumCoverBase2.Length - 2, 2);
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = reader3.ReadLine();
                                            AlbumName = AlbumName.Remove(0, 16);
                                            AlbumName = AlbumName.Remove(AlbumName.Length - 2, 2);
                                            if (AlbumName.Length < 2)
                                            { AlbumName = AlbumName + " (Album)"; }
                                            reader3.Close();
                                        }
                                        else
                                        {
                                            AlbumCoverBase2 = reader3.ReadLine();
                                            goto albumchicanery;
                                        }
                                    }
                                    catch (Exception ab)
                                    {
                                        ab.Data.Clear();
                                        AlbumCoverBase2 = "https://cdn-icons-png.flaticon.com/512/8438/8438101.png";
                                    }
                                    try
                                    {
                                        client.SetPresence(new RichPresence()
                                        {
                                            Details = SongTitleReloadedAlgo,
                                            State = LyricCache,
                                            Buttons = new DiscordRPC.Button[]
                                            {
                                                    new DiscordRPC.Button() { Label = "View on Spotify", Url = "https://open.spotify.com/track/" + SongID },
                                            },
                                            Assets = new Assets()
                                            {
                                                LargeImageKey = AlbumCoverBase2,
                                                LargeImageText = AlbumName,
                                                SmallImageKey = "mini_logo"
                                            }
                                        });
                                    }
                                    catch (Exception aa)
                                    {
                                        aa.Data.Clear();
                                        throw new Exception();
                                    }
                                }
                                else
                                {
                                    goto start;
                                }
                            }
                            catch (Exception a)
                            {
                                a.Data.Clear();
                                //System.Windows.MessageBox.Show(a.Message + "Error 1");
                                //client2.Dispose();
                                Thread.Sleep(30000);
                                Thread thread3 = new Thread(PerformLyricShit);
                                thread3.Start();
                            }
                        }
                        catch (Exception r)
                        {
                            r.Data.Clear();
                            //System.Windows.MessageBox.Show(r.Message + "Error 2");
                            //client2.Dispose();
                            Thread.Sleep(30000);
                            Thread thread3 = new Thread(PerformLyricShit);
                            thread3.Start();
                        }
                        //client2.Dispose();
                        Thread.Sleep(1000);
                        Thread thread2 = new Thread(PerformLyricShit);
                        thread2.Start();
                    }
                    catch (Exception ex)
                    {
                        //System.Windows.MessageBox.Show(ex.Message + "Error 3");
                        ex.Data.Clear();
                        //client2.Dispose();
                        Thread.Sleep(30000);
                        Thread thread3 = new Thread(PerformLyricShit);
                        thread3.Start();
                    }
                }
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show(e.Message + "Error 4");
                e.Data.Clear();
                startshit = 1;
                client2.CancelPendingRequests();
                //client2.Dispose();
                Thread.Sleep(30000);
                Thread thread3 = new Thread(PerformLyricShit);
                thread3.Start();
            }
            //client2.Dispose();
            albumline = 0;
        }
        public async void Initialize()
        {
            //client2.Dispose();
            try
            {
                var config = SpotifyClientConfig.CreateDefault();
                var server = new EmbedIOAuthServer(new Uri("http://localhost:5543/callback"), 5543);
                server.AuthorizationCodeReceived += async (sender, response) =>
                {
                    code = response.Code;
                    var tokenResponse = await new OAuthClient(config).RequestToken(new AuthorizationCodeTokenRequest(_clientId, _secretId, response.Code, BaseUri));
                    await server.Stop();
                    Toki = tokenResponse.AccessToken;
                    TokiRefresh = tokenResponse.RefreshToken;
                    Thread thread = new Thread(PerformLyricShit);
                    thread.Start();
                    Thread thread2 = new Thread(RefreshAPI);
                    thread2.Start();
                };
                await server.Start();
                var loginRequest = new LoginRequest(server.BaseUri, _clientId, LoginRequest.ResponseType.Code)
                {
                    Scope = new[] { Scopes.UserReadCurrentlyPlaying, Scopes.UserReadPlaybackState, Scopes.UserReadRecentlyPlayed }
                };
                BrowserUtil.Open(loginRequest.ToUri());
            }
            catch (Exception ea)
            {
                //System.Windows.MessageBox.Show(ea.Message + "Error 5");
                this.Dispatcher.Invoke(() =>
                {
                    StartButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 56, 56));
                });
            }
            //client2.Dispose();
        }
        public async void RefreshToken()
        {
            //client2.Dispose();
            if (startshit == 1)
            {
                try
                {
                    var url01 = "https://open.spotify.com/get_access_token?reason=transport&productType=web_player";
                    client2.DefaultRequestHeaders.Clear();
                    client2.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36");
                    client2.DefaultRequestHeaders.Add("App-platform", "WebPlayer");
                    client2.DefaultRequestHeaders.Add("cookie", "sp_dc=" + SP_DC);
                    var response01 = client2.GetStringAsync(url01);
                    Authy = response01.Result.ToString();
                    Authy = Authy.Replace("{", "{\n");
                    Authy = Authy.Replace("false", "\nfalse\n");
                    Authy = Authy.Replace("\",", "\",\n");
                    Authy = Authy.Remove(0, 50);
                    var reader2 = new StringReader(Authy);
                    Authy2 = reader2.ReadLine();
                    Authy2 = Authy2.Remove(0, 14);
                    Authy2 = Authy2.Remove(Authy2.Length - 2, 2);
                    Toki2 = Authy2;
                    TokiExpiration = reader2.ReadLine();
                    TokiExpiration = TokiExpiration.Remove(0, 35);
                    TokiExpiration = TokiExpiration.Remove(TokiExpiration.Length - 15, 15);
                    Int64 TokiExpirationInt = Convert.ToInt64(TokiExpiration);
                    long LocalTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    Int64 LocalTimeInt = Convert.ToInt64(LocalTime);
                    Int64 CalcTime = TokiExpirationInt - LocalTimeInt;
                    CalcTimeInt = Convert.ToInt32(CalcTime + 10000);
                    reader2.Close();
                    if (CalcTimeInt > 0)
                    {
                        Thread.Sleep(CalcTimeInt);
                    }
                    Thread thread2 = new Thread(RefreshToken);
                    thread2.Start();
                    //client2.Dispose();
                }
                catch (Exception ej)
                {
                    //System.Windows.MessageBox.Show(ej.Message + "Error 6");
                    ej.Data.Clear();
                    //client2.Dispose();
                    Thread.Sleep(1300);
                    Thread thread2 = new Thread(RefreshToken);
                    thread2.Start();
                }
            }
            //client2.Dispose();
        }
        public async void RefreshAPI()
        {
            try
            {
                var newResponse = await new OAuthClient().RequestToken(new AuthorizationCodeRefreshRequest(_clientId, _secretId, TokiRefresh));
                Toki = newResponse.AccessToken;
                Thread.Sleep(newResponse.ExpiresIn * 1000);
                Thread thread2 = new Thread(RefreshAPI);
                thread2.Start();
            }
            catch (Exception en)
            {
                //System.Windows.MessageBox.Show(en.Message + "Error 7");
                en.Data.Clear();
                Thread.Sleep(2000);
                Thread thread2 = new Thread(RefreshAPI);
                thread2.Start();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/yagdev/Spotify-Lyrics-For-Discord/wiki/User-Guides#getting-sp_dc", UseShellExecute = true });
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit1.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit1.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(117, 117, 117));
        }
        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit2.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
        }
        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit2.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(117, 117, 117));
        }
        private void TextBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit3.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
        }
        private void TextBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit3.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(117, 117, 117));
        }
        private void TextBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit4.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
        }
        private void TextBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit4.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(117, 117, 117));
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/yagdev/Spotify-Lyrics-For-Discord/wiki/User-Guides#getting-client-id--client-secret", UseShellExecute = true });
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/yagdev/Spotify-Lyrics-For-Discord/wiki/User-Guides#getting-discord-application-id", UseShellExecute = true });
        }
        private void Set1_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "SPDC.txt";
            if(File.Exists(filelocation))
            {
                File.Delete(filelocation);
            }
            using (StreamWriter sw = File.CreateText(filelocation))
            {
                sw.Write(SPDC.Text);
            }
        }
        private void Set2_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "ClientID.txt";
            if (File.Exists(filelocation))
            {
                File.Delete(filelocation);
            }
            using (StreamWriter sw = File.CreateText(filelocation))
            {
                sw.Write(ClientID.Text);
            }
        }
        private void Set3_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "SecretID.txt";
            if (File.Exists(filelocation))
            {
                File.Delete(filelocation);
            }
            using (StreamWriter sw = File.CreateText(filelocation))
            {
                sw.Write(ClientSecret.Text);
            }
        }
        private void Set4_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "AppID.txt";
            if (File.Exists(filelocation))
            {
                File.Delete(filelocation);
            }
            using (StreamWriter sw = File.CreateText(filelocation))
            {
                sw.Write(AppID.Text);
            }
        }
        private void Start(object sender, RoutedEventArgs e)
        {
            StartButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
            if (startshit == 1)
            {
                startshit = 0;
                StartButton.Content = "Start";
                StartButton.IsEnabled = false;

                Thread.Sleep(2000);
                StartButton.IsEnabled = true;
                client.ClearPresence();
            }
            else
            {
                if (File.Exists(filelocation) && File.Exists(filelocation2) && File.Exists(filelocation3) && File.Exists(filelocation4))
                {
                    try
                    {
                        DiscordID = File.ReadAllText(filelocation);
                        SP_DC = File.ReadAllText(filelocation4);
                        _clientId = File.ReadAllText(filelocation3);
                        _secretId = File.ReadAllText(filelocation2);
                        client = new DiscordRpcClient(DiscordID);
                        client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
                        client.OnReady += (sender, e) =>
                        {
                            Console.WriteLine("Received Ready from user {0}", e.User.Username);
                        };
                        client.OnPresenceUpdate += (sender, e) =>
                        {
                            Console.WriteLine("Received Update! {0}", e.Presence);
                        };
                        client.Initialize();
                        Thread thread2 = new Thread(RefreshToken);
                        thread2.Start();
                        Thread thread = new Thread(Initialize);
                        thread.Start();
                        startshit = 1;
                        StartButton.Content = "Stop";
                        StartButton.IsEnabled = false;
                        Thread.Sleep(2000);
                        StartButton.IsEnabled = true;
                    }
                    catch(Exception)
                    {
                        StartButton.Content = "Error (Check the fields above)";
                        StartButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 56, 56));
                    }
                }
                else
                {
                    StartButton.Content = "Please fill the fields above first";
                    StartButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 56, 56));
                }
            }
        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();
            base.OnStateChanged(e);
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C taskkill /f /im DiscordRPCAttempt2.exe";
            process.StartInfo = startInfo;
            process.Start();
        }
        public async void UpdateCheck()
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://www.dropbox.com/scl/fi/3we6tm5sv3o1aisssi41g/release.txt?rlkey=ry6xif19s2bp8uk50p7aer9xa&dl=1");
            if (reply == "23.10.5")
            {
                this.Dispatcher.Invoke(() =>
                {
                    UpdateButton.Visibility = Visibility.Hidden;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    UpdateButton.Visibility = Visibility.Visible;
                });
            }
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            string path = "https://www.dropbox.com/scl/fi/uqrjyh0fc7hap1hqwk95k/release.zip?rlkey=9a3wvahgui1vjr9n7f4kqiiev&dl=1";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(path, "release.zip");
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.Arguments = "/C mkdir Update & move * Update & cd Update & move AppID.txt ../ & move ClientID.txt ../ & move SecretID.txt ../ & move SPDC.txt ../ & move release.zip ../ & cd .. & tar -xf release.zip & del /f /q release.zip & taskkill /f /im DiscordRPCAttempt2.exe & timeout 1 & rmdir /s /q Update & DiscordRPCAttempt2.exe";
                cmd.Start();
            }
        }
    }
}
