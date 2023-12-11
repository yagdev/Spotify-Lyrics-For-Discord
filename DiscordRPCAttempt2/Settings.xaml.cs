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
using System.ComponentModel;
using IWshRuntimeLibrary;
using Microsoft.VisualBasic.FileIO;
using static System.Net.Mime.MediaTypeNames;
using Notifications.Wpf;

namespace DiscordRPCAttempt2
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        string Toki = "";
        string TokiA = "";
        string TokiO = "";
        string TokiRefresh = "";
        string TokiRefresh2 = "";
        string DiscordID = "";
        string Authy = "";
        string Authy2 = "";
        string Toki2 = "";
        string TokiExpiration = "";
        string TimeStampSong = "";
        TimeSpan ts, ts2;
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public DiscordRpcClient client;
        string _clientId = "";
        string _secretId = "";
        string _clientId2 = "";
        int currenttimestamp = 0;
        int endtimestamp = 0;
        string _secretId2 = "";
        string LyricCache = "";
        string Lyrics2 = "";
        public string SP_DC = "";
        int startshit = 0;
        string filelocation = "AppID.txt";
        string filelocation2 = "SecretID.txt";
        string filelocation3 = "ClientID.txt";
        string filelocation2a = "SecretID2.txt";
        string filelocation3a = "ClientID2.txt";
        string filelocation4 = "SPDC.txt";
        string filelocationtoki = "refreshtoki.txt";
        string filelocationtoki2 = "refreshtokia.txt";
        string startup = "startup";
        string startup2 = "startup2";
        string Title = "";
        string Title2 = "";
        string AlbumName = "";
        string TimestampNewAlgo = "";
        string SongTitleReloadedAlgo = "";
        string AlbumCoverBase = "";
        string AlbumCoverBase2 = "";
        string ArtistBase = "";
        string ArtistBase2 = "";
        string Lyrics = "";
        string SongID = "";
        string SongIDCache = "";
        string timestamp = "";
        string timestamp2 = "";
        string code = "";
        string code2 = "";
        string unexpectedshutdown = "unexpectedshutdown";
        Uri icon = new Uri("/DiscordRPCAttempt2;component/icon.ico", UriKind.RelativeOrAbsolute);
        int albumline = 0;
        int artistline = 0;
        int ExpiresInMs = 0;
        int CalcTimeInt = 0;
        Uri BaseUri = new Uri("http://localhost:5543/callback");
        SocketsHttpHandler handler = new SocketsHttpHandler();
        HttpClient client2 = new HttpClient(new SocketsHttpHandler { ConnectTimeout = TimeSpan.FromSeconds(5), EnableMultipleHttp2Connections = false });
        SpotifyAPI.Web.PlayerCurrentlyPlayingRequest request2 = new SpotifyAPI.Web.PlayerCurrentlyPlayingRequest();
        Process proc = Process.GetCurrentProcess();

        public Settings()
        {
            InitializeComponent();
            
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                Environment.Exit(0);
            }
            if (System.IO.File.Exists(filelocation))
            {
                AppID.Text = System.IO.File.ReadAllText(filelocation);
            }
            if (System.IO.File.Exists(filelocation2))
            {
                ClientSecret.Text = System.IO.File.ReadAllText(filelocation2);
            }
            if (System.IO.File.Exists(filelocation3))
            {
                ClientID.Text = System.IO.File.ReadAllText(filelocation3);
            }
            if (System.IO.File.Exists(filelocation4))
            {
                SPDC.Text = System.IO.File.ReadAllText(filelocation4);
            }
            if (System.IO.File.Exists(filelocation2a))
            {
                ClientSecret2.Text = System.IO.File.ReadAllText(filelocation2a);
            }
            if (System.IO.File.Exists(filelocation3a))
            {
                ClientID2.Text = System.IO.File.ReadAllText(filelocation3a);
            }
            object shStartup = (object)"startup";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shStartup) + @"\Lyrics for Discord RPC.lnk";
            if (System.IO.File.Exists(shortcutAddress))
            {
                StartupCheck.IsChecked = true;
            }
            else
            {
                StartupCheck.IsChecked = false;
            }
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipText = "Lyrics for Discord RPC has been moved to the system tray.";
            m_notifyIcon.BalloonTipTitle = "Lyrics for Discord RPC";
            m_notifyIcon.Text = "Lyrics for Discord RPC";
            m_notifyIcon.Icon = new System.Drawing.Icon("icon.ico");
            m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
            if (System.IO.File.Exists(startup) || System.IO.File.Exists(unexpectedshutdown))
            {
                if (System.IO.File.Exists(unexpectedshutdown))
                {
                    System.IO.File.Delete(unexpectedshutdown);
                }
                StartBox.IsChecked = true;
                StartButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
                if (System.IO.File.Exists(filelocation) && System.IO.File.Exists(filelocation2) && System.IO.File.Exists(filelocation3) && System.IO.File.Exists(filelocation4))
                {
                    try
                    {
                        DiscordID = System.IO.File.ReadAllText(filelocation);
                        SP_DC = System.IO.File.ReadAllText(filelocation4);
                        _clientId = System.IO.File.ReadAllText(filelocation3);
                        _secretId = System.IO.File.ReadAllText(filelocation2);
                        if(System.IO.File.Exists(filelocation2a) && System.IO.File.Exists(filelocation3a))
                        {
                            _clientId2 = System.IO.File.ReadAllText(filelocation3a);
                            _secretId2 = System.IO.File.ReadAllText(filelocation2a);
                        }
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
                        Thread thread2a = new Thread(RefreshToken);
                        thread2a.Start();
                        Thread threada = new Thread(Initialize);
                        threada.Start();
                        startshit = 1;
                        StartButton.Content = "Stop";
                        StartButton.IsEnabled = false;
                        Thread.Sleep(2000);
                        StartButton.IsEnabled = true;
                    }
                    catch (Exception)
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
            else
            {
                StartBox.IsChecked = false;
            }
            Thread thread2 = new Thread(UpdateCheck);
            thread2.Start();
            if (System.IO.File.Exists(startup2))
            {
                MinimizedBox.IsChecked = true;
                this.WindowState = WindowState.Minimized;
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
                CheckTrayIcon();
            }
            else
            {
                MinimizedBox.IsChecked = false;
            }
        }
        public async void PerformLyricShit()
        {
            var notificationManager = new NotificationManager();
            //client2.Dispose();
            try
            {
                LyricCache = "";
                proc = Process.GetCurrentProcess();
                if(proc.PrivateMemorySize64 > 600000000)
                {
                    System.IO.File.Create(unexpectedshutdown);
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.Arguments = "/C taskkill /f /im DiscordRPCAttempt2.exe & DiscordRPCAttempt2.exe";
                    cmd.Start();
                    System.Windows.Forms.Application.Restart();
                    Environment.Exit(0);
                }
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
                                if (Title.Contains("https://api.spotify.com/v1/tracks/") && Title.Contains("\"is_playing\" : true"))
                                {
                                    AlbumCoverBase = Title;
                                    ArtistBase = Title;
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
                                        var reader4 = new StringReader(TimestampNewAlgo);
                                        string TimestampNewAlgo2 = "";
                                        string TimestampNewAlgo2a = "";
                                        TimestampNewAlgo2 = reader4.ReadLine();
                                    startchicanerynewprogressalgo:
                                        if (TimestampNewAlgo2.Contains("duration_ms"))
                                        {
                                            TimestampNewAlgo2 = TimestampNewAlgo2.Remove(0, 20);
                                            TimestampNewAlgo2 = TimestampNewAlgo2.Remove(TimestampNewAlgo2.Length - 1, 1);
                                            timestamp2 = TimestampNewAlgo2;
                                            reader4.Close();
                                        }
                                        else
                                        {
                                            if (TimestampNewAlgo2.Contains("progress_ms"))
                                            {
                                                TimestampNewAlgo2a = TimestampNewAlgo2;
                                                TimestampNewAlgo2a = TimestampNewAlgo2a.Remove(0, 18);
                                                TimestampNewAlgo2a = TimestampNewAlgo2a.Remove(TimestampNewAlgo2a.Length - 1, 1);
                                                timestamp = TimestampNewAlgo2a;
                                            }
                                            TimestampNewAlgo2 = reader4.ReadLine();
                                            goto startchicanerynewprogressalgo;
                                        }
                                        currenttimestamp = int.Parse(timestamp);
                                        ts = TimeSpan.FromMilliseconds(currenttimestamp);
                                        endtimestamp = int.Parse(timestamp2);
                                        ts2 = TimeSpan.FromMilliseconds(endtimestamp);
                                        if (SongID == SongIDCache)
                                        {
                                            try
                                            {
                                                timestamp = "";
                                                if (Lyrics.Contains("startTimeMs"))
                                                {
                                                    var reader2 = new StringReader(Lyrics);
                                                startchicanery:
                                                    Lyrics2 = reader2.ReadLine();
                                                    if (Lyrics2.Contains("startTimeMs"))
                                                    {

                                                        Lyrics2 = Lyrics2.Remove(0, 15);
                                                        Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                        int lyrictimestamp = int.Parse(Lyrics2);
                                                        Lyrics2 = reader2.ReadLine();
                                                        Lyrics2 = Lyrics2.Remove(0, 9);
                                                        Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                        if (Lyrics2.Contains("♪"))
                                                        {
                                                            Lyrics2 = Lyrics2 + "♪";
                                                        }
                                                    startchicanery2:
                                                        if (lyrictimestamp < currenttimestamp)
                                                        {
                                                            LyricCache = Lyrics2;
                                                            LyricCache = System.Text.RegularExpressions.Regex.Unescape(LyricCache);
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
                                            }
                                            catch (Exception oo)
                                            {
                                                notificationManager.Show(new NotificationContent
                                                {
                                                    Title = "Warning",
                                                    Message = oo.Message,
                                                    Type = NotificationType.Warning
                                                });
                                                oo.Data.Clear();
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
                                                    if (Lyrics.Contains("startTimeMs"))
                                                    {
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
                                                            

                                                            int lyrictimestamp = int.Parse(Lyrics2);
                                                            
                                                            Lyrics2 = reader2.ReadLine();
                                                            Lyrics2 = Lyrics2.Remove(0, 9);
                                                            Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                            if (Lyrics2.Contains("♪"))
                                                            {
                                                                Lyrics2 = Lyrics2 + "♪";
                                                            }
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
                                                    else
                                                    {
                                                        SongIDCache = SongID;
                                                    }
                                                }
                                                catch (Exception nn)
                                                {
                                                    nn.Data.Clear();
                                                    try
                                                    {
                                                        var url2 = "https://spotify-lyric-api-984e7b4face0.herokuapp.com/?trackid=" + Title2;
                                                        client2.DefaultRequestHeaders.Clear();
                                                        var response2 = client2.GetStringAsync(url2);
                                                        Lyrics = response2.Result.ToString();
                                                        timestamp = "";
                                                        if (Lyrics.Contains("startTimeMs"))
                                                        {
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

                                                                int lyrictimestamp = int.Parse(Lyrics2);
                                                                int currenttimestamp = int.Parse(timestamp);
                                                                Lyrics2 = reader2.ReadLine();
                                                                Lyrics2 = Lyrics2.Remove(0, 9);
                                                                Lyrics2 = Lyrics2.Remove(Lyrics2.Length - 2, 2);
                                                                if (Lyrics2.Contains("♪"))
                                                                {
                                                                    Lyrics2 = Lyrics2 + "♪";
                                                                }
                                                                SongIDCache = SongID;
                                                            startchicanery2:
                                                                if (lyrictimestamp < currenttimestamp)
                                                                {
                                                                    LyricCache = Lyrics2;
                                                                    LyricCache = System.Text.RegularExpressions.Regex.Unescape(LyricCache);
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
                                                        else
                                                        {
                                                            SongIDCache = SongID;
                                                        }
                                                    }
                                                    catch (Exception nn2)
                                                    {
                                                        nn2.Data.Clear();
                                                        LyricCache = "";
                                                        Lyrics = "";
                                                        SongIDCache = SongID;
                                                    }
                                                }
                                            }
                                        }
                                        try
                                        {
                                            albumline = 0;
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
                                                if (AlbumName.Contains("\\\""))
                                                {
                                                    AlbumName.Replace("\\\"", "\"");
                                                }
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
                                            System.Windows.MessageBox.Show(ab.Message);
                                            ab.Data.Clear();
                                            AlbumCoverBase2 = "https://cdn-icons-png.flaticon.com/512/8438/8438101.png";
                                        }
                                        try
                                        {
                                            artistline = 0;
                                            ArtistBase = ArtistBase.Replace("{", "");
                                            var reader3 = new StringReader(ArtistBase);
                                            ArtistBase = reader3.ReadLine();
                                        artistchicanery:
                                            artistline = artistline + 1;
                                            if (ArtistBase2.Contains("https://api.spotify.com/v1/artists/") & artistline > 10)
                                            {
                                                ArtistBase2 = reader3.ReadLine();
                                                ArtistBase2 = reader3.ReadLine();
                                                ArtistBase2 = ArtistBase2.Remove(0, 18);
                                                ArtistBase2 = ArtistBase2.Remove(ArtistBase2.Length - 2, 2);
                                                reader3.Close();
                                            }
                                            else
                                            {
                                                ArtistBase2 = reader3.ReadLine();
                                                goto artistchicanery;
                                            }
                                        }
                                        catch (Exception artist)
                                        {
                                            System.Windows.MessageBox.Show(artist.Message);
                                        }

                                        try
                                        {
                                            DateTime dt = DateTime.Now.Add(-ts);
                                            DateTime dt2 = DateTime.Now.Add((-ts) + ts2);
                                            if (SongTitleReloadedAlgo.Contains("\\\""))
                                            {
                                                SongTitleReloadedAlgo = SongTitleReloadedAlgo.Replace("\\\"","\"");
                                            }
                                            client.SetPresence(new RichPresence()
                                            {
                                                Details = SongTitleReloadedAlgo + " by " + ArtistBase2,
                                                State =  LyricCache,
                                                Timestamps = new Timestamps()
                                                {
                                                    Start = dt,
                                                    End = dt2
                                                },
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
                                            System.Windows.MessageBox.Show(ts.ToString());
                                            System.Windows.MessageBox.Show(aa.Message);
                                            aa.Data.Clear();
                                        }
                                    }
                                    else
                                    {
                                        goto start;
                                    }
                                }
                                else
                                {
                                    client.ClearPresence();
                                }
                            }
                            catch (Exception a)
                            {
                                notificationManager.Show(new NotificationContent
                                {
                                    Title = "Warning",
                                    Message = a.Message,
                                    Type = NotificationType.Warning
                                });
                                a.Data.Clear();
                            }
                        }
                        catch (Exception r)
                        {
                            notificationManager.Show(new NotificationContent
                            {
                                Title = "Warning",
                                Message = r.Message,
                                Type = NotificationType.Warning
                            });
                            r.Data.Clear();
                            throw new Exception();
                        }
                        //client2.Dispose();
                        Thread.Sleep(1000);
                        Thread thread2 = new Thread(PerformLyricShit);
                        thread2.Start();
                    }
                    catch (Exception ex)
                    {
                        notificationManager.Show(new NotificationContent
                        {
                            Title = "Warning",
                            Message = ex.Message,
                            Type = NotificationType.Warning
                        });
                        //System.Windows.MessageBox.Show(ex.Message + "Error 3");
                        ex.Data.Clear();
                        //client2.Dispose();
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {

                //System.Windows.MessageBox.Show(e.Message + "Error 4");
                notificationManager.Show(new NotificationContent
                {
                    Title = "Warning",
                    Message = e.Message,
                    Type = NotificationType.Warning
                });
                e.Data.Clear();
                startshit = 1;
                client2.CancelPendingRequests();
                //client2.Dispose();
                if (Toki == TokiO && TokiA != null)
                {
                    Toki = TokiA;
                }
                else
                {
                    Toki = TokiO;
                }
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
            var notificationManager = new NotificationManager();
            try
            {
                if (System.IO.File.Exists(filelocationtoki))
                {
                    TokiRefresh = System.IO.File.ReadAllText(filelocationtoki);
                    var newResponse = await new OAuthClient().RequestToken(new AuthorizationCodeRefreshRequest(_clientId, _secretId, TokiRefresh));
                    TokiO = newResponse.AccessToken;
                    Toki = TokiO;
                    Thread thread3 = new Thread(InitializeB);
                    thread3.Start();
                }
                else
                {
                    var config = SpotifyClientConfig.CreateDefault();
                    var server = new EmbedIOAuthServer(new Uri("http://localhost:5543/callback"), 5543);
                    server.AuthorizationCodeReceived += async (sender, response) =>
                    {
                        code = response.Code;
                        var tokenResponse = await new OAuthClient(config).RequestToken(new AuthorizationCodeTokenRequest(_clientId, _secretId, response.Code, BaseUri));
                        await server.Stop();
                        TokiO = tokenResponse.AccessToken;
                        using (StreamWriter sw = System.IO.File.CreateText(filelocationtoki))
                        {
                            TokiRefresh = tokenResponse.RefreshToken;
                            sw.Write(tokenResponse.RefreshToken);
                        }
                        if(System.IO.File.Exists(filelocation2a) && System.IO.File.Exists(filelocation3a))
                        {
                            Thread thread3 = new Thread(InitializeB);
                            thread3.Start();
                        }
                        else
                        {
                            Thread thread = new Thread(PerformLyricShit);
                            thread.Start();
                            Thread thread2 = new Thread(RefreshAPI);
                            thread2.Start();
                        }
                    };
                    await server.Start();
                    var loginRequest = new LoginRequest(server.BaseUri, _clientId, LoginRequest.ResponseType.Code)
                    {
                        Scope = new[] { Scopes.UserReadCurrentlyPlaying, Scopes.UserReadPlaybackState, Scopes.UserReadRecentlyPlayed }
                    };
                    BrowserUtil.Open(loginRequest.ToUri());
                }
                Toki = TokiO;
            }
            catch (Exception ea)
            {
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error. Retrying...",
                    Message = ea.Message,
                    Type = NotificationType.Error
                });
                //System.Windows.MessageBox.Show(ea.Message + "Error 5");
                this.Dispatcher.Invoke(() =>
                {
                    StartButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 56, 56));
                });
            }
            //client2.Dispose();
        }
        public async void InitializeB()
        {
            var notificationManager = new NotificationManager();
            //client2.Dispose();
            try
            {
                if (System.IO.File.Exists(filelocationtoki2))
                {
                    TokiRefresh2 = System.IO.File.ReadAllText(filelocationtoki2);
                    var newResponse = await new OAuthClient().RequestToken(new AuthorizationCodeRefreshRequest(_clientId2, _secretId2, TokiRefresh2));
                    TokiA = newResponse.AccessToken;
                    Thread thread = new Thread(PerformLyricShit);
                    thread.Start();
                    Thread thread2a = new Thread(RefreshAPI);
                    thread2a.Start();
                    Thread thread2 = new Thread(RefreshAPI2);
                    thread2.Start();
                }
                else
                {
                    var config = SpotifyClientConfig.CreateDefault();
                    var server = new EmbedIOAuthServer(new Uri("http://localhost:5543/callback"), 5543);
                    server.AuthorizationCodeReceived += async (sender, response) =>
                    {
                        code2 = response.Code;
                        var tokenResponse = await new OAuthClient(config).RequestToken(new AuthorizationCodeTokenRequest(_clientId2, _secretId2, response.Code, BaseUri));
                        await server.Stop();
                        TokiA = tokenResponse.AccessToken;
                        using (StreamWriter sw = System.IO.File.CreateText(filelocationtoki2))
                        {
                            TokiRefresh2 = tokenResponse.RefreshToken;
                            sw.Write(tokenResponse.RefreshToken);
                            Thread thread = new Thread(PerformLyricShit);
                            thread.Start();
                            Thread thread2a = new Thread(RefreshAPI);
                            thread2a.Start();
                            Thread thread2 = new Thread(RefreshAPI2);
                            thread2.Start();
                        }
                    };
                    await server.Start();
                    var loginRequest = new LoginRequest(server.BaseUri, _clientId2, LoginRequest.ResponseType.Code)
                    {
                        Scope = new[] { Scopes.UserReadCurrentlyPlaying, Scopes.UserReadPlaybackState, Scopes.UserReadRecentlyPlayed }
                    };
                    BrowserUtil.Open(loginRequest.ToUri());
                }
            }
            catch (Exception ea)
            {
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error. Retrying...",
                    Message = ea.Message,
                    Type = NotificationType.Error
                });
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
                    var notificationManager = new NotificationManager();
                    notificationManager.Show(new NotificationContent
                    {
                        Title = "Error. Retrying...",
                        Message = ej.Message,
                        Type = NotificationType.Error
                    });
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
                TokiO = newResponse.AccessToken;
                Thread.Sleep(newResponse.ExpiresIn * 1000);
                Thread thread2 = new Thread(RefreshAPI);
                thread2.Start();
            }
            catch (Exception en)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error. Retrying...",
                    Message = en.Message,
                    Type = NotificationType.Error
                });
                //System.Windows.MessageBox.Show(en.Message + "Error 7");
                en.Data.Clear();
                Thread.Sleep(30000);
                Thread thread2 = new Thread(RefreshAPI);
                thread2.Start();
            }
        }
        public async void RefreshAPI2()
        {
            try
            {
                var newResponse = await new OAuthClient().RequestToken(new AuthorizationCodeRefreshRequest(_clientId2, _secretId2, TokiRefresh2));
                TokiA = newResponse.AccessToken;
                Thread.Sleep(newResponse.ExpiresIn * 1000);
                Thread thread2 = new Thread(RefreshAPI2);
                thread2.Start();
            }
            catch (Exception en)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error. Retrying...",
                    Message = en.Message,
                    Type = NotificationType.Error
                });
                //System.Windows.MessageBox.Show(en.Message + "Error 7");
                en.Data.Clear();
                Thread.Sleep(30000);
                Thread thread2 = new Thread(RefreshAPI2);
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
            if (System.IO.File.Exists(filelocation))
            {
                System.IO.File.Delete(filelocation);
            }
            using (StreamWriter sw = System.IO.File.CreateText(filelocation))
            {
                sw.Write(SPDC.Text);
            }
        }
        private void Set2_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "ClientID.txt";
            if (System.IO.File.Exists(filelocation))
            {
                System.IO.File.Delete(filelocation);
            }
            if (System.IO.File.Exists(filelocationtoki))
            {
                System.IO.File.Delete(filelocationtoki);
            }
            using (StreamWriter sw = System.IO.File.CreateText(filelocation))
            {
                sw.Write(ClientID.Text);
            }
        }
        private void Set3_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "SecretID.txt";
            if (System.IO.File.Exists(filelocation))
            {
                System.IO.File.Delete(filelocation);
            }
            if (System.IO.File.Exists(filelocationtoki))
            {
                System.IO.File.Delete(filelocationtoki);
            }
            using (StreamWriter sw = System.IO.File.CreateText(filelocation))
            {
                sw.Write(ClientSecret.Text);
            }
        }
        private void Set4_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "AppID.txt";
            if (System.IO.File.Exists(filelocation))
            {
                System.IO.File.Delete(filelocation);
            }
            using (StreamWriter sw = System.IO.File.CreateText(filelocation))
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
                if (System.IO.File.Exists(filelocation) && System.IO.File.Exists(filelocation2) && System.IO.File.Exists(filelocation3) && System.IO.File.Exists(filelocation4))
                {
                    try
                    {
                        DiscordID = System.IO.File.ReadAllText(filelocation);
                        SP_DC = System.IO.File.ReadAllText(filelocation4);
                        _clientId = System.IO.File.ReadAllText(filelocation3);
                        _secretId = System.IO.File.ReadAllText(filelocation2);
                        if(System.IO.File.Exists(filelocation3a) && System.IO.File.Exists(filelocation2a))
                        {
                            _clientId2 = System.IO.File.ReadAllText(filelocation3a);
                            _secretId2 = System.IO.File.ReadAllText(filelocation2a);
                        }
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
                    catch (Exception err)
                    {
                        var notificationManager = new NotificationManager();
                        notificationManager.Show(new NotificationContent
                        {
                            Title = "Error. Retrying...",
                            Message = err.Message,
                            Type = NotificationType.Error
                        });
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
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            }
            else
                m_storedWindowState = WindowState;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        public async void UpdateCheck()
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://www.dropbox.com/scl/fi/3we6tm5sv3o1aisssi41g/release.txt?rlkey=ry6xif19s2bp8uk50p7aer9xa&dl=1");
            if (reply == "23.12")
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
                    StatusIcon.Source = new BitmapImage(new Uri(@"/warning.png", UriKind.RelativeOrAbsolute));
                    TitleLbl_Copy1.Content = TitleLbl_Copy1.Content + " (Update Available)";
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(startup))
            {
                System.IO.File.Delete(startup);
            }
            using (StreamWriter sw = System.IO.File.CreateText(startup))
            {
                sw.Write("LyricsForDiscordRPCSettingsElement");
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(startup))
            {
                System.IO.File.Delete(startup);
            }
        }
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        void OnClose(object sender, CancelEventArgs args)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }
        private WindowState m_storedWindowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            }
            else
                m_storedWindowState = WindowState;
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }
        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }

        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(startup2))
            {
                System.IO.File.Delete(startup2);
            }
            using (StreamWriter sw = System.IO.File.CreateText(startup2))
            {
                sw.Write("LyricsForDiscordRPCSettingsElement");
            }
        }

        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(startup2))
            {
                System.IO.File.Delete(startup2);
            }
        }

        private void StartupLaunchOn(object sender, RoutedEventArgs e)
        {
            object shStartup = (object)"startup";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shStartup) + @"\Lyrics for Discord RPC.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Lyrics for Discord RPC launch on startup object";
            shortcut.TargetPath = System.IO.Path.Combine(System.IO.Path.GetFullPath(Environment.ProcessPath.ToString()));
            shortcut.WorkingDirectory = System.IO.Path.Combine(System.IO.Path.GetFullPath(Environment.CurrentDirectory.ToString()));
            shortcut.Save();
        }

        private void StartupLaunchOff(object sender, RoutedEventArgs e)
        {
            object shStartup = (object)"startup";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shStartup) + @"\Lyrics for Discord RPC.lnk";
            if (System.IO.File.Exists(shortcutAddress))
            {
                System.IO.File.Delete(shortcutAddress);
            }
        }

        private void Set3a_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "SecretID2.txt";
            if (System.IO.File.Exists(filelocation))
            {
                System.IO.File.Delete(filelocation);
            }
            if (System.IO.File.Exists(filelocationtoki))
            {
                System.IO.File.Delete(filelocationtoki);
            }
            using (StreamWriter sw = System.IO.File.CreateText(filelocation))
            {
                sw.Write(ClientSecret2.Text);
            }
        }

        private void Set2a_Click(object sender, RoutedEventArgs e)
        {
            string filelocation = "ClientID2.txt";
            if (System.IO.File.Exists(filelocation))
            {
                System.IO.File.Delete(filelocation);
            }
            if (System.IO.File.Exists(filelocationtoki))
            {
                System.IO.File.Delete(filelocationtoki);
            }
            using (StreamWriter sw = System.IO.File.CreateText(filelocation))
            {
                sw.Write(ClientID2.Text);
            }
        }

        private void TextBox3a_GotFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit3_Copy.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
        }
        private void TextBox2a_GotFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit2_Copy.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 191, 255));
        }

        private void TextBox2a_LostFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit2_Copy.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(117, 117, 117));
        }

        private void TextBox3a_LostFocus(object sender, RoutedEventArgs e)
        {
            RectangleShit3_Copy.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(117, 117, 117));
        }
    }
}
