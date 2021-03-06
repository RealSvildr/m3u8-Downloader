using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace m3u8_Downloader {
    public partial class Main : Form {
        private readonly string _mergeTS = "copy /b {0} [outputName].{1}"; // copy /b segment1_0_av.ts+segment2_0_av.ts+segment3_0_av.ts all.ts
        private readonly string _convertToMP4 = "ffmpeg -i {0} -acodec copy -vcodec copy {1}"; // ffmpeg -i all.ts -acodec copy -vcodec copy all.mp4

        private string _url = "";
        private string _baseURL = "";
        private string _thisURL = "";

        private string _extension = "";
        private string _videoMap = "";
        private List<string> _videoList = new List<string>();
        private List<M3U8> _m3u8List = new List<M3U8>();

        private string _downloadPath = Environment.CurrentDirectory;
        private string _basePath = "";
        private string _mergeFiles = "";
        private Thread _th;
        private bool _threadStatus = false;
        private bool _readMasterm3u8 = false;

        public Main() {
            InitializeComponent();
            lStatus.Text = "";
            progressBar.Hide();
            lStatus.Hide();
        }

        private void BDownload_Click(object sender, EventArgs e) {
            if (bDownload.Text == "Download")
                ThreadStart();
            else
                ThreadStop();
        }

        public void ThreadStart() {
            Lock();

            _url = tLink.Text;
            _th = new Thread(Execute);
            _th.IsBackground = true;
            _threadStatus = true;

            _th.Start();
        }

        public void ThreadStop() {
            _threadStatus = false; //Interrupt was not enough it still executed until de end
            Unlock();
        }

        public void Execute() {
            if (_threadStatus)
                SetBaseUrl(_url);

            if (_threadStatus)
                ReadM3u8(_url);

            if (_videoList.Count > 0 || _m3u8List.Count > 0) {

                if (_threadStatus)
                    if (_m3u8List.Count > 0) {
                        CheckM3u8List();
                        return;
                    } else
                        DownloadFiles();

                if (_threadStatus)
                    MergeFiles();

                if (_threadStatus)
                    ConvertToMP4();

                if (_threadStatus)
                    CleanUp();

                if (_threadStatus) {
                    if (cOpenFolder.Checked)
                        Process.Start("explorer.exe", Environment.CurrentDirectory);

                    UpdateStatus(0, $"Finished");
                    ThreadStop();
                }
            }
        }

        public void SetBaseUrl(string url) {
            UpdateStatus(0, "Setting Base Url");

            var _uArray = url.Split("/").ToList();

            while (_uArray[^1] == "")
                _uArray.RemoveAt(_uArray.Count - 1);

            if (!string.IsNullOrEmpty(tName.Text))
                _basePath = tName.Text;
            else {


                _basePath = _uArray[^1];

                if (_basePath.IndexOf(".m3u8") > -1)
                    _basePath = _basePath.Substring(0, _basePath.IndexOf(".m3u8"));
                else
                    _basePath = _basePath.Replace("?", "").Replace("hash=", "");

                if (_basePath.Length > 50 || _basePath.Contains("index"))
                    _basePath = Guid.NewGuid().ToString();
            }

            _downloadPath = Environment.CurrentDirectory + "\\" + FormatFileName(_basePath);

            _uArray.RemoveAt(_uArray.Count - 1);
            _thisURL = string.Join("/", _uArray) + "/";

            UpdateStatus(1);
        }

        public void CheckM3u8List() {
            UpdateStatus(0, "Reading master m3u8");

            if (_m3u8List.Count == 1)
                _url = _m3u8List[0].Url;
            else {
                var _s = new Selector();
                _s.SetList(_m3u8List);
                _s.ShowDialog();
                _url = _s.SelectedItem;
                _s.Dispose();
            }

            _readMasterm3u8 = true;
            Execute();
        }

        public void ReadM3u8(string url) {
            UpdateStatus(0, "Reading m3u8");

            _videoMap = "";
            _extension = "";
            _videoList = new List<string>();
            _m3u8List = new List<M3U8>();


            try {
                var fInfo = new FileInfo(url);

                if (fInfo.Exists) {
                    ReadFileStream(new StreamReader(url).BaseStream);
                } else {
                    WebRequest request = WebRequest.Create(url);
                    request.Credentials = CredentialCache.DefaultCredentials;
                    _baseURL = (request.RequestUri.Port == 443 ? "https://" : "http://") + request.RequestUri.Authority;

                    using (var response = (HttpWebResponse)request.GetResponse()) {
                        if ((new string[] { "application/x-mpegurl", "vnd.apple.mpegurl", "application/vnd.apple.mpegurl" }).Contains(response.ContentType.ToLower())) {
                            ReadFileStream(response.GetResponseStream());
                        } else {
                            Message("Wrong Url!");
                            ThreadStop();
                        }
                    }
                }

                if (_videoList.Count > 0)
                    _extension = _videoList[0].Contains(".m4s") ? "m4s" : _videoList[0].Contains(".mp4") ? "mp4" : "ts";

            } catch (Exception e) {
                if (e.Message.Contains("410"))
                    Message("Could not download m3u8 File");
                else if (e.Message.Contains("404"))
                    Message("File not found");
                else
                    Message("Could not read m3u8 File");

                ThreadStop();
            }

            UpdateStatus(1);
        }

        public void ReadFileStream(Stream str) {
            using (var _sr = new StreamReader(str)) {
                string line = "";
                string prevLine = "";
                while ((line = _sr.ReadLine()) != null) {
                    if (line.StartsWith("#EXT-X-MAP:URI=")) {
                        line = line.Replace("#EXT-X-MAP:URI=", "");
                        line = line.Trim('"');

                        if (line.StartsWith("/"))
                            line = _baseURL + line;
                        else if (!line.Contains("http"))
                            line = _thisURL + line;

                        _videoMap = line;
                    } else if (line.Contains(".m3u8")) {
                        if (line.StartsWith("/"))
                            line = _baseURL + line;
                        else if (!line.Contains("http"))
                            line = _thisURL + line;

                        var m3u8 = new M3U8() { Url = line };

                        foreach (var info in prevLine.Split(",")) {
                            if (info.ToLower().Contains("bandwidth=")) {
                                m3u8.Bandwidth = info.ToLower().Replace("bandwidth=", "");
                            } else if (info.ToLower().Contains("resolution=")) {
                                m3u8.Resolution = info.ToLower().Replace("resolution=", "");
                            } else if (info.ToLower().Contains("codecs=")) {
                                m3u8.Codecs = info.ToLower().Replace("codecs=", "");
                            } else if (info.ToLower().Contains("name=")) {
                                m3u8.Name = info.ToLower().Replace("name=", "");
                            }
                        }

                        _m3u8List.Add(m3u8);
                    } else if (line.Contains(".ts") || line.Contains(".m4s") || line.Contains("http")) {
                        if (line.StartsWith("/"))
                            line = _baseURL + line;
                        else if (!line.Contains("http"))
                            line = _thisURL + line;


                        _videoList.Add(line);
                    }

                    prevLine = line;
                }
            }
        }

        public void DownloadFiles() {
            if (!new DirectoryInfo(_downloadPath).Exists)
                new DirectoryInfo(_downloadPath).Create();

            try {
                if (!string.IsNullOrEmpty(_videoMap)) {
                    UpdateStatus(0, $"Downloading Map File");
                    using (var client = new WebClient())
                        client.DownloadFile(_videoMap, $"{_downloadPath}\\map.mp4");

                    UpdateStatus(1);
                }

                for (var i = 0; i < _videoList.Count; i++) {
                    if (!_threadStatus) return;

                    UpdateStatus(1, $"Downloading Files ({i + 1}/{_videoList.Count})");

                    if (i % 50 == 0) // Sleep Every 50 to hide from sites that block downloads
                        Thread.Sleep(1500);

                    var j = 0;
                    while (j < 3) {
                        try {
                            using (var client = new WebClient())
                                client.DownloadFile(_videoList[i], $"{_downloadPath}\\{i:00}.{_extension}");
                            j = 4;
                        } catch (Exception) {
                            UpdateStatus(0, $"Error on File ({i + 1}/{_videoList.Count}) - Waiting");
                            Thread.Sleep(10000); // You might have got catch let's pretend to be a browser

                            UpdateStatus(0, $"Retrying File ({i + 1}/{_videoList.Count})");
                            j++;
                        }
                    }

                    if (j == 3)
                        throw new Exception();
                }
            } catch (Exception) {
                Message("An error occoured while downloading the video files");
                ThreadStop();
            }
        }

        public void MergeFiles() {
            UpdateStatus(0, $"Merging TS Files");

            try {
                var _ext = !string.IsNullOrEmpty(_videoMap) ? "mp4" : _extension;

                if (_videoList.Count < 500) {
                    _mergeFiles = "";
                    if (!string.IsNullOrEmpty(_videoMap))
                        _mergeFiles += "map.mp4";

                    for (var i = 0; i < _videoList.Count; i++)
                        _mergeFiles += $"+{i:00}.{_extension}";

                    var _cmd = string.Format(_mergeTS, _mergeFiles.TrimStart('+'), _ext);
                    MergeFilesExecute(_cmd);
                } else {
                    var i = 0;
                    var counter = 500;
                    var mergeList = new List<string>();
                    var _cmd = "";

                    while (i != counter) {
                        _mergeFiles = "";

                        if (i == 0 && !string.IsNullOrEmpty(_videoMap))
                            _mergeFiles += "map.mp4";

                        for (var j = i; j < counter; j++)
                            _mergeFiles += $"+{j:00}.{_extension}";

                        _cmd = string.Format(_mergeTS, _mergeFiles.TrimStart('+'), _ext);
                        MergeFilesExecute(_cmd, "merge_" + i);
                        mergeList.Add("merge_" + i + "." + _ext);

                        i = counter;
                        counter = i + 500;
                        if (counter > _videoList.Count())
                            counter = _videoList.Count();
                    }

                    _mergeFiles = "";
                    for (i = 0; i < mergeList.Count; i++)
                        _mergeFiles += "+" + mergeList[i];

                    _cmd = string.Format(_mergeTS, _mergeFiles.TrimStart('+'), !string.IsNullOrEmpty(_videoMap) ? "mp4" : _extension);
                    MergeFilesExecute(_cmd);
                }

            } catch (Exception) {
                Message("Could not Merge the TS File, check the files inside the program folder");
                Process.Start("explorer.exe", _downloadPath);
                ThreadStop();
            }

            UpdateStatus(1);
        }
        private void MergeFilesExecute(string cmd, string fileName = "all") {
            var startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe",
                Arguments = "/C " + cmd.Replace("[outputName]", fileName),
                WorkingDirectory = _downloadPath
            };

            var process = new Process {
                StartInfo = startInfo
            };

            process.Start();
            process.WaitForExit();
        }

        public void ConvertToMP4() {
            var _ext = !string.IsNullOrEmpty(_videoMap) ? "mp4" : _extension;

            if (_extension != "ts")
                File.Move($"{_basePath}\\all.{_ext}", $"{Environment.CurrentDirectory}\\{_basePath}.mp4");
            else if (cConvert.Checked) {
                UpdateStatus(0, $"Converting to MP4");

                try {
                    var _cmd = "";

                    _cmd = string.Format(_convertToMP4, $"\"{_basePath}\\all.{_extension}\"", $"\"{_basePath}.mp4\"");

                    var startInfo = new ProcessStartInfo {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe",
                        Arguments = "/C " + _cmd
                    };

                    var process = new Process {
                        StartInfo = startInfo
                    };

                    process.Start();
                    process.WaitForExit();
                } catch (Exception) {
                    Message("It was not possible to convert to MP4, check the folder");
                    Process.Start("explorer.exe", _downloadPath);
                    ThreadStop();
                }

                UpdateStatus(1);
            } else {
                UpdateStatus(0, $"Moving File");
                File.Move($"{_basePath}\\all.{_extension}", $"{Environment.CurrentDirectory}\\{_basePath}.{_extension}");
                UpdateStatus(1);
            }
        }

        public void CleanUp() {
            UpdateStatus(0, $"Cleaning Up");

            // Move to Trash
            FileSystem.DeleteDirectory(
                _downloadPath,
                UIOption.OnlyErrorDialogs,
                RecycleOption.SendToRecycleBin
            );

            UpdateStatus(1);
        }

        public void Lock() {
            if (InvokeRequired) {
                try {
                    this.Invoke(new MethodInvoker(delegate { Lock(); }));
                } catch (Exception) { }
                return;
            }

            tName.Enabled = false;
            tLink.Enabled = false;
            cOpenFolder.Enabled = false;
            cConvert.Enabled = false;
            bDownload.Text = "Stop";

            progressBar.Value = 0;
            lStatus.Text = "";
            progressBar.Show();
            lStatus.Show();
        }

        public void Unlock() {
            if (InvokeRequired) {
                try {
                    this.Invoke(new MethodInvoker(delegate { Unlock(); }));
                } catch (Exception) { }
                return;
            }

            // To Reset Status Bar
            _readMasterm3u8 = false;
            _videoMap = "";

            tName.Enabled = true;
            tLink.Enabled = true;
            cConvert.Enabled = true;
            cOpenFolder.Enabled = true;
            bDownload.Text = "Download";

            progressBar.Value = 0;
            lStatus.Text = "";
            progressBar.Hide();
            lStatus.Hide();
        }

        public void UpdateStatus(int plus, string status = "") {
            if (InvokeRequired) {
                try {
                    this.Invoke(new MethodInvoker(delegate { UpdateStatus(plus, status); }));
                } catch (Exception) { }
                return;
            }

            var setBase = 1;
            var readM3u8 = 1;
            var downloadTS = (_videoList.Count == 0 ? 5 : _videoList.Count);
            var mergeTS = 1;
            var convertMP4 = 1;
            var cleanUp = 1;
            var readMaster = _readMasterm3u8 ? 2 : 0;
            var vMap = !string.IsNullOrEmpty(_videoMap) ? 1 : 0;

            var total = setBase + readM3u8 + downloadTS + mergeTS + convertMP4 + cleanUp + readMaster + vMap;

            progressBar.Maximum = total;
            progressBar.Value += plus;

            if (!string.IsNullOrEmpty(status))
                lStatus.Text = status;

        }

        public void Message(string msg) {
            if (InvokeRequired) {
                this.Invoke(new MethodInvoker(delegate { Message(msg); }));
                return;
            }

            MessageBox.Show(msg);
        }

        public string FormatFileName(string name) {
            if (string.IsNullOrEmpty(name))
                return "no-name";

            return name.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "");
        }

        private void bFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", Environment.CurrentDirectory);
        }
    }

    //# EXT-X-STREAM-INF:PROGRAM-ID=1,BANDWIDTH=155648,RESOLUTION=444x250,NAME="250p"
    public class M3U8 {
        public string Bandwidth { get; set; }
        public string Resolution { get; set; }
        public string Codecs { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
