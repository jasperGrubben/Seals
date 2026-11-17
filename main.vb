AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\model.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\create.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\globals.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\paths.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\save.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\vault.vb"

Sub Main()
    Dim materials(4) As String
        materials(0) = "Perbunan-NBR-grey white"
        materials(1) = "Sillicone-Si-beige"
        materials(2) = "Sillicone-Si-blue"
        materials(3) = "Keltan-EPDM-black"
        materials(4) = "Vilton-FKM-red"

    Dim Seals(18) As Array
        Seals(0)= Dim parts(2) As Interger
            MaatA(0) = 81
            MaatB(1) = 93
            PipeDiaMeter(2) = 80
        Seals(1)= Dim parts(2) As Interger
            MaatA(0) = 103
            MaatB(1) = 151
            PipeDiaMeter(2) = 100
        Seals(2)= Dim parts(2) As Interger
            MaatA(0) = 123
            MaatB(1) = 135
            PipeDiaMeter(2) = 120
        Seals(3)= Dim parts(2) As Interger
            MaatA(0) = 139
            MaatB(1) = 151
            PipeDiaMeter(2) = 140
        Seals(4)= Dim parts(2) As Interger
            MaatA(0) = 153
            MaatB(1) = 165
            PipeDiaMeter(2) = 150
        Seals(5)= Dim parts(2) As Interger
            MaatA(0) = 163
            MaatB(1) = 175
            PipeDiaMeter(2) = 160
        Seals(6)= Dim parts(2) As Interger
            MaatA(0) = 178
            MaatB(1) = 190
            PipeDiaMeter(2) = 175
        Seals(7)= Dim parts(2) As Interger
            MaatA(0) = 203
            MaatB(1) = 215
            PipeDiaMeter(2) = 200
        Seals(8)= Dim parts(2) As Interger
            MaatA(0) = 223
            MaatB(1) = 235
            PipeDiaMeter(2) = 224
        Seals(9)= Dim parts(2) As Interger
            MaatA(0) = 253
            MaatB(1) = 265
            PipeDiaMeter(2) = 250
        Seals(10)= Dim parts(2) As Interger
            MaatA(0) = 280
            MaatB(1) = 292
            PipeDiaMeter(2) = 280
        Seals(11)= Dim parts(2) As Interger
            MaatA(0) = 303
            MaatB(1) = 315
            PipeDiaMeter(2) = 300
        Seals(12)= Dim parts(2) As Interger
            MaatA(0) = 315
            MaatB(1) = 327
            PipeDiaMeter(2) = 315
        Seals(13)= Dim parts(2) As Interger
            MaatA(0) = 353
            MaatB(1) = 365
            PipeDiaMeter(2) = 350
        Seals(14)= Dim parts(2) As Interger
            MaatA(0) = 403
            MaatB(1) = 415
            PipeDiaMeter(2) = 400
        Seals(15)= Dim parts(2) As Interger
            MaatA(0) = 450
            MaatB(1) = 470
            PipeDiaMeter(2) = 450
        Seals(16)= Dim parts(2) As Interger
            MaatA(0) = 500
            MaatB(1) = 516
            PipeDiaMeter(2) = 500
        Seals(17)= Dim parts(2) As Interger
            MaatA(0) = 560
            MaatB(1) = 578
            PipeDiaMeter(2) = 560
        Seals(18)= Dim parts(2) As Interger
            MaatA(0) = 632
            MaatB(1) = 648
            PipeDiaMeter(2) = 630

    for each Mater In materials
        'generate the materials

    Next

end sub

Private Function CreateTask(asm As AssemblyDocument,
                            model As Input,
                            OutputFolder As String,
                            PartName As String,
                            TemplatePath As String) As SealTask
    Return New SealTask With {
        .Asm = asm,
        .model = model
    }


End Function