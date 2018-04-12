Public Class Sprocket
    Public Property XPosition As Integer
    Public Property YPosition As Integer
    Public Property RadiusValue As Integer

    Public Overrides Function ToString() As String
        Return $"{{ _
                X={XPosition}, Y={YPosition}, R={RadiusValue} _
                }}"
    End Function

End Class

