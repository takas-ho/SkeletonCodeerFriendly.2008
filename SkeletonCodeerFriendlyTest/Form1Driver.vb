Imports Codeer.Friendly.Windows
Imports Codeer.Friendly.Windows.Grasp
Imports System.IO

Public Class Form1Driver : Implements IDisposable

    Public ReadOnly App As WindowsAppFriend
    Public ReadOnly MainForm As WindowControl

    Public Shared Function Start() As Form1Driver
#If DEBUG Then
        Dim targetPath As String = "..\..\..\SkeletonCodeerFriendly\bin\Debug\SkeletonCodeerFriendly.exe"
#Else
        Dim targetPath As String = "..\..\..\SkeletonCodeerFriendly\bin\Release\SkeletonCodeerFriendly.exe"
#End If
        Return New Form1Driver(Path.GetFullPath(targetPath))
    End Function

    Private Sub New(ByVal path As String)
        Dim aProcess As Process = Process.Start(path)
        App = New WindowsAppFriend(aProcess)
        MainForm = WindowControl.FromZTop(App)
        'mainForm = app("System.Windows.Forms.Control.FromHandle")(Process.GetProcessById(aProcess.Id).MainWindowHandle)
        WindowsAppExpander.LoadAssemblyFromFile(App, Me.GetType.Assembly.Location)
    End Sub

    Public Sub New(ByVal app As WindowsAppFriend, ByVal mainForm As WindowControl)
        Me.App = app
        Me.MainForm = mainForm
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If App Is Nothing Then
            Return
        End If

        App.Dispose()
        Dim aProcess As Process = Process.GetProcessById(App.ProcessId)
        aProcess.CloseMainWindow()
    End Sub

    Public Sub Close()
        MainForm("Close")()
    End Sub

End Class
