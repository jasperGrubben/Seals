Imports Inventor

'veel toegepasde functies
Public Module SealGlobals
    Public ThisApp As Inventor.Application
    Public LogInfo As Action(Of String)
    Public LogError As Action(Of String)

    Public Sub InitLogger(info As Action(Of String), errorHandler As Action(Of String))
        LogInfo = info
        LogError = errorHandler
    End Sub

    Public Sub Show(message As String)
        System.Windows.Forms.MessageBox.Show(message)
    End Sub

    Public Sub MaterialLibrary()
        Public "Perbunan-NBR-grey white" as String 
        "Sillicone-Si-beige" as String
        "Sillicone-Si-blue" as String
        "Keltan-EPDM-black"as String
        "Vilton-FKM-red" as String
    End Sub
End Module
