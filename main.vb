AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\model.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\create.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\globals.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\paths.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\save.vb"
AddVbFile "C:\Users\Gasteng5\Documents\ilogic2027\Seals\switchMaterials.vb"

Sub Main()
    SealGlobals.ThisApp = ThisApplication
    SealGlobals.InitLogger(AddressOf Logger.Info, AddressOf Logger.Error)

    Dim paths As New SealPaths()
    If Not paths.Validate() Then Return

    Dim doc As Document = ThisDoc.Document
    If TypeOf doc IsNot AssemblyDocument Then
        SealGlobals.Show("This rule must run from an assembly document.")
        Return
    End If
    Dim assemblyDoc As AssemblyDocument = CType(doc, AssemblyDocument)

    Dim materials() As String = {
        "Perbunan-NBR-grey white", "Sillicone-Si-beige",
        "Sillicone-Si-blue", "Keltan-EPDM-black", "Vilton-FKM-red"}

    ' Seals(i, 0) = MaatA, Seals(i, 1) = MaatB, Seals(i, 2) = PipeDiaMeter
    Dim seals(18, 2) As Integer
    seals(0, 0) = 81  : seals(0, 1) = 93  : seals(0, 2) = 80
    seals(1, 0) = 103 : seals(1, 1) = 151 : seals(1, 2) = 100
    seals(2, 0) = 123 : seals(2, 1) = 135 : seals(2, 2) = 120
    seals(3, 0) = 139 : seals(3, 1) = 151 : seals(3, 2) = 140
    seals(4, 0) = 153 : seals(4, 1) = 165 : seals(4, 2) = 150
    seals(5, 0) = 163 : seals(5, 1) = 175 : seals(5, 2) = 160
    seals(6, 0) = 178 : seals(6, 1) = 190 : seals(6, 2) = 175
    seals(7, 0) = 203 : seals(7, 1) = 215 : seals(7, 2) = 200
    seals(8, 0) = 223 : seals(8, 1) = 235 : seals(8, 2) = 224
    seals(9, 0) = 253 : seals(9, 1) = 265 : seals(9, 2) = 250
    seals(10, 0) = 280 : seals(10, 1) = 292 : seals(10, 2) = 280
    seals(11, 0) = 303 : seals(11, 1) = 315 : seals(11, 2) = 300
    seals(12, 0) = 315 : seals(12, 1) = 327 : seals(12, 2) = 315
    seals(13, 0) = 353 : seals(13, 1) = 365 : seals(13, 2) = 350
    seals(14, 0) = 403 : seals(14, 1) = 415 : seals(14, 2) = 400
    seals(15, 0) = 450 : seals(15, 1) = 470 : seals(15, 2) = 450
    seals(16, 0) = 500 : seals(16, 1) = 516 : seals(16, 2) = 500
    seals(17, 0) = 560 : seals(17, 1) = 578 : seals(17, 2) = 560
    seals(18, 0) = 632 : seals(18, 1) = 648 : seals(18, 2) = 630

    For Each material As String In materials
        Dim outputFolder As String = System.IO.Path.Combine(paths.OutputDir, material)
        If Not System.IO.Directory.Exists(outputFolder) Then
            System.IO.Directory.CreateDirectory(outputFolder)
        End If

        For i As Integer = 0 To seals.GetUpperBound(0)
            Dim model As New Input With {
                .MaatA = seals(i, 0),
                .MaatB = seals(i, 1),
                .PipeDiameter = seals(i, 2)
            }
            If Not model.IsValid Then
                SealGlobals.LogError("Invalid seal dimensions in row " & i & ".")
                Continue For
            End If

            For Each partName As String In paths.PartNames
                Dim task As SealTask = CreateTask(assemblyDoc, model, outputFolder,
                                                  material, partName, paths.TemplateFor(partName))
                If Not SealCreate.ProcessTask(task) Then Continue For
                ReplaceComponent(task)
            Next

            SealSave.SaveAssemblyCopy(assemblyDoc, outputFolder, model)
        Next
    Next

    SealGlobals.Show("All seal files have been generated.")
End Sub

Private Function CreateTask(asm As AssemblyDocument,
                            model As Input,
                            outputFolder As String,
                            material As String,
                            partName As String,
                            templatePath As String) As SealTask
    Return New SealTask With {
        .Asm = asm,
        .Model = model,
        .Material = material,
        .OutputFolder = outputFolder,
        .PartName = partName,
        .TemplatePath = templatePath
    }
End Function

Private Sub ReplaceComponent(task As SealTask)
    task.Occurrence.Replace(task.OutputPath, False)
End Sub
