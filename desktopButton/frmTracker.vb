
Imports System.Net.WebSockets
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class frmTracker
    'I'm using this in the createTextIcon sub to releases all of the resources that the icon/icons would have used.
    Public Declare Function DestroyIcon Lib "user32.dll" (ByVal hIcon As Int32) As Int32

    Private wsServer As Uri
    Dim fontToUse As Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular, GraphicsUnit.Pixel)
    Dim brushToUse As Brush
    Dim bitmapText As Bitmap = New Bitmap(16, 16)
    Dim g As Graphics = Drawing.Graphics.FromImage(bitmapText)
    Dim hIcon As IntPtr

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://www.reddit.com/r/thebutton")
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim sourcecode As String = sr.ReadToEnd()
        Dim pattern As String = "wss:\/\/(.+?)"""
        Dim m As Match = Regex.Match(sourcecode, pattern)
        wsServer = New Uri(m.Value.Trim(""""))

        niCountDown.Icon = New Icon("..\..\app.ico")
    End Sub

    Private Async Sub start()
        Dim secs As Integer
        Dim clr As Color
        Using ws As New ClientWebSocket()
            Dim result As WebSocketReceiveResult

            Await ws.ConnectAsync(wsServer, CancellationToken.None)

            While True
                Dim bytesReceived As New ArraySegment(Of Byte)(New Byte(1023) {})
                result = Await ws.ReceiveAsync(bytesReceived, CancellationToken.None)
                Dim s As String = Encoding.UTF8.GetString(bytesReceived.Array)
                Dim json As JObject = JObject.Parse(s)
                secs = CInt(json.SelectToken("payload").SelectToken("seconds_left"))

                Select Case secs
                    Case Is >= 52
                        clr = Color.Purple
                    Case Is >= 42
                        clr = Color.Blue
                    Case Is >= 32
                        clr = Color.Green
                    Case Is >= 22
                        clr = Color.Yellow
                    Case Is >= 12
                        clr = Color.Orange
                    Case Is >= 1
                        clr = Color.Red
                    Case 0
                        clr = Color.White
                End Select

                lblSecondsLeft.ForeColor = clr
                lblSecondsLeft.Text = secs.ToString
                lblParticipants.Text = json.SelectToken("payload").SelectToken("participants_text")

                createTextIcon(secs, clr)
            End While
        End Using
    End Sub

    Sub createTextIcon(seconds As Integer, clr As Color)
        Try
            g.Clear(Color.White)
            brushToUse = New SolidBrush(clr)
            g.DrawString(seconds.ToString, fontToUse, brushToUse, -2, -1)
            hIcon = (bitmapText.GetHicon)
            niCountDown.Icon = Drawing.Icon.FromHandle(hIcon)
            DestroyIcon(hIcon.ToInt32)
        Catch exc As Exception
            MessageBox.Show(exc.InnerException.ToString, "Somethings not right?", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        start()
    End Sub
End Class
