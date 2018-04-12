Option Explicit On
Option Strict On
Option Infer On
Option Compare Text
Imports System.IO
Module Program
    Const InputPath As String = "C:\Temp\gearinput.txt"
    'Public Delimiter As String = {"),"}
    Public myDelimiters As String = "{Environment.NewLine} ,)("

    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim lowBuffer As Integer = 10
        Dim coordinateArray() As Integer =
            File.ReadAllText(InputPath).Split(myDelimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries) _
            .Select(Function(i) Integer.Parse(i)).ToArray()

        Dim sprockets() As Sprocket =
            Enumerable.Range(0, (coordinateArray.Length \ 3)).
            Select(Function(i) New Sprocket With
                {
                .XPosition = coordinateArray(((i * 3) + 0)) + lowBuffer,
                .YPosition = coordinateArray(((i * 3) + 1)) + lowBuffer,
                .RadiusValue = coordinateArray(((i * 3) + 2))
                }).ToArray()

        Application.Run(New GearBox(sprockets))
    End Sub

End Module