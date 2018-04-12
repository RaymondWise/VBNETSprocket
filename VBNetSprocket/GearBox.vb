
Public Class GearBox
    Inherits Form

    Private ReadOnly sprockets() As Sprocket

    Public Sub New(sprockets() As Sprocket)

        InitializeComponent() 'auto insert
        Dim highBuffer As Integer = 20

        If sprockets Is Nothing Then Throw New ArgumentNullException(NameOf(sprockets))

        Me.sprockets = sprockets

        Dim maxHeight = Me.sprockets.Max(Function(n) n.YPosition + n.RadiusValue) + highBuffer
        Dim maxWidth = Me.sprockets.Max(Function(n) n.XPosition + n.RadiusValue) + highBuffer

        With Me
            .SetStyle(ControlStyles.AllPaintingInWmPaint Or
                      ControlStyles.UserPaint Or
                      ControlStyles.OptimizedDoubleBuffer, True)
            .Text = "Gear Box"
            .AutoScaleMode = AutoScaleMode.Font
            .ClientSize = New Size(maxWidth, maxHeight)
        End With

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e) 'auto insert

        e.Graphics.Clear(Me.BackColor)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        Dim diameter As Integer
        Dim chain As New Pen(Color.Gray, 3)
        Dim drawRectangle As Rectangle
        'Dim targetSprocket As Sprocket
        'Dim x1 As Integer
        'Dim y1 As Integer
        'Dim x2 As Integer
        'Dim y2 As Integer


        For Each targetSprocket As Sprocket In Me.sprockets
            'targetSprocket = sprockets(i)
            diameter = (targetSprocket.RadiusValue * 2)
            drawRectangle = New Rectangle(targetSprocket.XPosition, targetSprocket.YPosition, diameter, diameter)
            e.Graphics.FillEllipse(Brushes.Black, drawRectangle)

        Next

        'For i As Integer = 0 To Me.sprockets.Length
        'x1 = targetSprocket.XPosition + targetSprocket.RadiusValue
        'y1 = targetSprocket.YPosition + targetSprocket.RadiusValue
        'If i < Me.sprockets.Length Then
        '    x2 = sprockets(i + 1).XPosition + sprockets(i + 1).RadiusValue
        '    y2 = sprockets(i + 1).YPosition + sprockets(i + 1).RadiusValue
        'Else
        '    x2 = sprockets(0).XPosition + sprockets(0).RadiusValue
        '    y2 = sprockets(0).YPosition + sprockets(0).RadiusValue
        'End If
        ' e.Graphics.DrawLine(chain, x1, y1, x2, y2)


    End Sub

    Private Sub GearBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class