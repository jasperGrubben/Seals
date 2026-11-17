AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\model.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\create.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\globals.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\paths.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\save.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\vault.vb"

Sub Main()
    Dim materials() As String = {
        "Perbunan-NBR-grey white", "Sillicone-Si-beige",
        "Sillicone-Si-blue", "Keltan-EPDM-black", "Vilton-FKM-red"}

    ' Seals(i, 0) = MaatA, Seals(i, 1) = MaatB, Seals(i, 2) = PipeDiaMeter
    Dim Seals(18, 2) As Integer
    Seals(0, 0) = 81  : Seals(0, 1) = 93  : Seals(0, 2) = 80
    Seals(1, 0) = 103 : Seals(1, 1) = 151 : Seals(1, 2) = 100
    Seals(2, 0) = 123 : Seals(2, 1) = 135 : Seals(2, 2) = 120
    Seals(3, 0) = 139 : Seals(3, 1) = 151 : Seals(3, 2) = 140
    Seals(4, 0) = 153 : Seals(4, 1) = 165 : Seals(4, 2) = 150
    Seals(5, 0) = 163 : Seals(5, 1) = 175 : Seals(5, 2) = 160
    Seals(6, 0) = 178 : Seals(6, 1) = 190 : Seals(6, 2) = 175
    Seals(7, 0) = 203 : Seals(7, 1) = 215 : Seals(7, 2) = 200
    Seals(8, 0) = 223 : Seals(8, 1) = 235 : Seals(8, 2) = 224
    Seals(9, 0) = 253 : Seals(9, 1) = 265 : Seals(9, 2) = 250
    Seals(10, 0) = 280 : Seals(10, 1) = 292 : Seals(10, 2) = 280
    Seals(11, 0) = 303 : Seals(11, 1) = 315 : Seals(11, 2) = 300
    Seals(12, 0) = 315 : Seals(12, 1) = 327 : Seals(12, 2) = 315
    Seals(13, 0) = 353 : Seals(13, 1) = 365 : Seals(13, 2) = 350
    Seals(14, 0) = 403 : Seals(14, 1) = 415 : Seals(14, 2) = 400
    Seals(15, 0) = 450 : Seals(15, 1) = 470 : Seals(15, 2) = 450
    Seals(16, 0) = 500 : Seals(16, 1) = 516 : Seals(16, 2) = 500
    Seals(17, 0) = 560 : Seals(17, 1) = 578 : Seals(17, 2) = 560
    Seals(18, 0) = 632 : Seals(18, 1) = 648 : Seals(18, 2) = 630

    For Each material As String In materials
        CreateTask()
    Next
End Sub

Private Function CreateTask(asm As AssemblyDocument,
                            model As Input,
                            OutputFolder As String,
                            PartName As String,
                            TemplatePath As String) As SealTask
    Return New SealTask With {
        .Asm = asm,
        .Model = model
    }
End Function